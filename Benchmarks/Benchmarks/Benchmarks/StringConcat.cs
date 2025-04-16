using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringConcat
{
    [Benchmark]
    public string Loop()
    {
        var result = "Can be found on page: ";
        for (var i = 0; i < 20; i++)
        {
            result += $"Page({i + 1}) ";
        }
        
        return result;
    }

    [Benchmark(Baseline = true)]
    public string StringBuilder()
    {
        var sb = new StringBuilder();
        sb.Append("Can be found on page: ");
        for (var i = 0; i < 20; i++)
        {
            sb.Append($"Page({i + 1}) ");
        }
        
        return sb.ToString();
    }
}