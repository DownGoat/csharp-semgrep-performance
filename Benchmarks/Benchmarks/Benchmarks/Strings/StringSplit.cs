using BenchmarkDotNet.Attributes;

namespace Benchmarks.Strings;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringSplit
{
    private const string Input = "apple,banana,cherry,dragonfruit";
    private const string Item = "cherry";
    [Benchmark(Baseline = true)]
    public bool ListContainsItemUsingStringSplit()
    {
        string[] segments = Input.Split(',');
        foreach (string segment in segments)
        {
            if (segment == Item)
            {
                return true;
            }
        }
    
        return false;
    }
    
    [Benchmark]
    public bool ListContainsItemUsingSpanSplit()
    {
        var span = Input.AsSpan();
        foreach (Range segment in span.Split(','))
        {
            if (span[segment].SequenceEqual(Item))
            {
                return true;
            }
        }
    
        return false;
    }
}