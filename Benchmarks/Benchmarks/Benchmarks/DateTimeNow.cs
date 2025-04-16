using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class DateTimeNow
{
    [Benchmark]
    public string Now()
    {
        return DateTime.Now.AddYears(1).ToString();
    }

    [Benchmark(Baseline = true)]
    public string UtcNow()
    {
        return DateTime.UtcNow.AddYears(1).ToString();

    }
}