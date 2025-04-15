using System;
using System.Collections.Generic;
using System.Linq;

namespace SemgrepClosureTests
{
    public class SemgrepClosureTestCases
    {
        // Helper methods and properties to use in examples
        private List<int> GetNumbers() => new List<int> { 1, 2, 3, 4, 5 };
        private List<string> GetStrings() => new List<string> { "a", "b", "c", "d", "e" };
        private int SomeCondition() => new Random().Next(100) > 50 ? 1 : 0;

        // Test 1: Basic closure in for loop (should trigger: csharp-closure-capture-in-for-loop)
        public void ClosureInForLoop()
        {
            var actions = new List<Action>();
            
            for (var i = 0; i < 10; i++)
            {
                var closure = () => {
                    Console.WriteLine(i);  // Captures loop variable i
                };
                
                actions.Add(closure);
            }
            
            // When executed, all actions will print 10, not 0,1,2...9 as might be expected
            foreach (var action in actions)
            {
                action();
            }
        }
        
        // Test 2: Basic closure in foreach loop (should trigger: csharp-closure-capture-in-foreach-loop)
        public void ClosureInForeachLoop()
        {
            var actions = new List<Action>();
            var numbers = GetNumbers();
            
            foreach (var item in numbers)
            {
                var closure = () => {
                    Console.WriteLine(item);  // Captures loop variable item
                };
                
                actions.Add(closure);
            }
            
            // When executed, all actions will print the last item
            foreach (var action in actions)
            {
                action();
            }
        }
        
        // Test 3: Local function in loop (should trigger: csharp-closure-capture-local-function)
        public void LocalFunctionInLoop()
        {
            var actions = new List<Action>();
            var strings = GetStrings();
            
            foreach (var s in strings)
            {
                void LocalFunction()
                {
                    Console.WriteLine(s);  // Captures loop variable s
                }
                
                actions.Add(LocalFunction);
            }
        }
        
        // Test 4: LINQ Where in for loop capturing loop variable (should trigger: csharp-linq-closure-in-for-loop)
        public void LinqWhereInForLoop()
        {
            var numbers = GetNumbers();
            
            for (var i = 0; i < 5; i++)
            {
                var filtered = numbers.Where(x => x > i);  // Captures loop variable i
                Console.WriteLine($"Numbers greater than {i}: {string.Join(", ", filtered)}");
            }
        }
        
        // Test 5: LINQ Select in foreach loop capturing loop variable (should trigger: csharp-linq-select-closure-in-foreach-loop)
        public void LinqSelectInForeachLoop()
        {
            var numbers = GetNumbers();
            var multipliers = new[] { 1, 2, 3 };
            
            foreach (var multiplier in multipliers)
            {
                var multiplied = numbers.Select(n => n * multiplier);  // Captures loop variable multiplier
                Console.WriteLine($"Numbers multiplied by {multiplier}: {string.Join(", ", multiplied)}");
            }
        }
        
        // Test 6: Generic LINQ method in while loop (should trigger: csharp-linq-any-closure-in-while)
        public void LinqMethodInWhileLoop()
        {
            var strings = GetStrings();
            var counter = 0;
            
            while (counter < 5)
            {
                var result = strings.OrderBy(s => s.Length + counter);  // Captures local variable counter
                Console.WriteLine($"Iteration {counter}: {string.Join(", ", result)}");
                counter++;
            }
        }
        
        // Test 7: Multiple LINQ operations in for loop (should trigger: csharp-lambda-in-hot-path)
        public void MultipleLinqInForLoop()
        {
            var strings = GetStrings();
            
            for (var i = 0; i < 10; i++)
            {
                var result = strings.Where(s => s.Length > 0)  // New delegate allocation on each iteration
                                    .Select(s => s.ToUpper())   // New delegate allocation on each iteration
                                    .ToList();
                
                Console.WriteLine($"Iteration {i}: {string.Join(", ", result)}");
            }
        }
        
        // Test 8: LINQ Any in foreach loop with captured variable (should trigger: csharp-linq-any-closure-in-foreach)
        public void LinqAnyInForeachLoop()
        {
            var numberSets = new List<List<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 },
                new List<int> { 7, 8, 9 }
            };
            
            foreach (var threshold in new[] { 2, 5, 8 })
            {
                foreach (var set in numberSets)
                {
                    bool hasNumbersAboveThreshold = set.Any(n => n > threshold);  // Captures outer loop variable
                    Console.WriteLine($"Set {string.Join(",", set)} has numbers above {threshold}: {hasNumbersAboveThreshold}");
                }
            }
        }
        
        // Common fix for closure in loop issues - creating a local copy
        public void ClosureInLoopFix()
        {
            var actions = new List<Action>();
            
            for (var i = 0; i < 10; i++)
            {
                int localI = i;  // Create a local copy that's unique per iteration
                var closure = () => {
                    Console.WriteLine(localI);  // Captures local variable, not loop variable
                };
                
                actions.Add(closure);
            }
            
            // This will correctly print 0,1,2...9
            foreach (var action in actions)
            {
                action();
            }
        }
        
        // Moving LINQ lambdas outside loops
        public void LinqOutsideLoopFix()
        {
            var numbers = GetNumbers();
            
            // Create the delegate once, outside the loop
            Func<int, bool> predicate = x => x > 3;
            
            for (var i = 0; i < 5; i++)
            {
                // Reuse the same delegate instead of creating a new one each iteration
                var filtered = numbers.Where(predicate);
                Console.WriteLine($"Iteration {i}: {string.Join(", ", filtered)}");
            }
        }
    }
}