using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemgrepClosureTests
{
    public class SemgrepClosureTestCases
    {
        public void Foo(string left, string right) {
            var x = string.Format("{0}/{1}", left, right);

            // Should match these
            string.Format("{0}", value);
            string.Format("{0}/{1}", left, right);
            string.Format("Hello, {0}!", name);
            String.Format("Requires: {0} {1} {2}", name, version, architecture); 
            String.Format("http://{0}:{1}", server, port);
            string.Format(@"{0}\{1}", left, right); 

            // Should not matche these
            string.Format("{0:3N}", value); // Has format specifier
            string.Format("The value will be {0:3N} (or {1:P}) on {2:MMMM yyyy gg}", x, y, theDate); // Complex formatting
        }

        // RULE 1: csharp-string-concat-in-for-loop
        // This method will trigger the rule
        public string StringConcatInForLoop(int count)
        {
            string result = "";
            for (var i = 0; i < count; i++)
            {
                result = result + i.ToString();
            }
            return result;
        }

        // Correct implementation using StringBuilder
        public string StringConcatInForLoopFixed(int count)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                sb.Append(i.ToString());
            }
            return sb.ToString();
        }

        // RULE 2: csharp-string-concat-plus-equals-in-for-loop
        // This method will trigger the rule
        public string StringConcatPlusEqualsInForLoop(int count)
        {
            string result = "";
            for (var i = 0; i < count; i++)
            {
                result += i.ToString();
            }
            return result;
        }

        // Correct implementation using StringBuilder
        public string StringConcatPlusEqualsInForLoopFixed(int count)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                sb.Append(i.ToString());
            }
            return sb.ToString();
        }

        // RULE 3: csharp-string-concat-in-foreach-loop
        // This method will trigger the rule
        public string StringConcatInForeachLoop(IEnumerable<string> items)
        {
            string result = "";
            foreach (var item in items)
            {
                result = result + item;
            }
            return result;
        }

        // Correct implementation using StringBuilder
        public string StringConcatInForeachLoopFixed(IEnumerable<string> items)
        {
            var sb = new StringBuilder();
            foreach (var item in items)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

        // RULE 4: csharp-string-concat-plus-equals-in-foreach-loop
        // This method will trigger the rule
        public string StringConcatPlusEqualsInForeachLoop(IEnumerable<string> items)
        {
            string result = "";
            foreach (var item in items)
            {
                result += item;
            }
            return result;
        }

        // Correct implementation using StringBuilder
        public string StringConcatPlusEqualsInForeachLoopFixed(IEnumerable<string> items)
        {
            var sb = new StringBuilder();
            foreach (var item in items)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

        // RULE 5: csharp-string-concat-in-while-loop
        // This method will trigger the rule
        public string StringConcatInWhileLoop(int count)
        {
            string result = "";
            int i = 0;
            while (i < count)
            {
                result = result + i.ToString();
                i++;
            }
            return result;
        }

        // Correct implementation using StringBuilder
        public string StringConcatInWhileLoopFixed(int count)
        {
            var sb = new StringBuilder();
            int i = 0;
            while (i < count)
            {
                sb.Append(i.ToString());
                i++;
            }
            return sb.ToString();
        }

        // RULE 6: csharp-string-concat-plus-equals-in-while-loop
        // This method will trigger the rule
        public string StringConcatPlusEqualsInWhileLoop(int count)
        {
            string result = "";
            int i = 0;
            while (i < count)
            {
                result += i.ToString();
                i++;
            }
            return result;
        }

        // Correct implementation using StringBuilder
        public string StringConcatPlusEqualsInWhileLoopFixed(int count)
        {
            var sb = new StringBuilder();
            int i = 0;
            while (i < count)
            {
                sb.Append(i.ToString());
                i++;
            }
            return sb.ToString();
        }

        // Additional test case: Do-While loop with string concatenation
        public string StringConcatInDoWhileLoop(int count)
        {
            string result = "";
            int i = 0;
            do
            {
                result = result + i.ToString();
                i++;
            } while (i < count);
            return result;
        }

        // Additional test case: Nested loops with string concatenation
        public string StringConcatInNestedLoops(int rows, int cols)
        {
            string result = "";
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    result += $"({i},{j}) ";
                }
                result += Environment.NewLine;
            }
            return result;
        }

        // Correct implementation of nested loops using StringBuilder
        public string StringConcatInNestedLoopsFixed(int rows, int cols)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    sb.Append($"({i},{j}) ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        // Edge case: Single iteration loop (still inefficient)
        public string SingleIterationLoop(string[] items)
        {
            string result = "";
            foreach (var item in items.Take(1))
            {
                result += item;
            }
            return result;
        }
    }
}