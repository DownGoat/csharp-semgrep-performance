// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Benchmarks;
using Benchmarks.Strings;

// var summary = BenchmarkRunner.Run<StringComparisons>();
// var summary = BenchmarkRunner.Run<StringFormat>();
// var summary = BenchmarkRunner.Run<StringConcat>();
// var summary = BenchmarkRunner.Run<SealedVsUnsealed>();
// var summary = BenchmarkRunner.Run<DateTimeNow>();
// var summary = BenchmarkRunner.Run<SubstringBenchmark>();
var summary = BenchmarkRunner.Run<StringsTranscoding>();
Console.WriteLine(summary);