using BenchmarkDotNet.Attributes;

namespace Benchmarks.Strings;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class SubstringBenchmark
{
    [Benchmark(Baseline = true)]
    public string Substring()
    {
        return "this is my wonderful string".Substring("this".Length);
    }

    [Benchmark]
    public ReadOnlySpan<char> AsSpan()
    {
        return "this is my wonderful string".AsSpan("this".Length);
    }
    
    [Benchmark]
    public string RangeIndex()
    {
        return "this is my wonderful string"["this".Length..];
    }
}