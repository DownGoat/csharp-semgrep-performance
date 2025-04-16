using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringFormat
{
    private const string Left = "Left";
    private const string Right = "Right";
    private const string Middle = "Middle";

    [Benchmark]
    public string Format()
    {
        return string.Format("{0} {1} {2}", Left, Right, Middle);
    }

    [Benchmark(Baseline = true)]
    public string Interpolation()
    {
        return $"{Left} {Right} {Middle}";
    }

    [Benchmark]
    public string Concat()
    {
        return string.Concat(Left, " ", Right, " ", Middle);
    }
}