// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Benchmarks;

// var summary = BenchmarkRunner.Run<StringComparisons>();
// var summary = BenchmarkRunner.Run<StringFormat>();
// var summary = BenchmarkRunner.Run<StringConcat>();
// var summary = BenchmarkRunner.Run<SealedVsUnsealed>();
// var summary = BenchmarkRunner.Run<DateTimeNow>();
var summary = BenchmarkRunner.Run<SubstringBenchmark>();
Console.WriteLine(summary);