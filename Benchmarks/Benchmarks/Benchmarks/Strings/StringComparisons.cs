using BenchmarkDotNet.Attributes;

namespace Benchmarks.Strings;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringComparisons
{
    private const string TestString1 = "ThIs Is A StRiNG";
    private const string TestString2 = "some other string";
    private const string TestString3 = "this is a string"; // Same as TestString1 but lowercase

    [Benchmark]
    public bool ToLower_Different()
    {
        return TestString1.ToLower().Equals(TestString2);
    }

    [Benchmark]
    public bool ToLowerInvariant_Different()
    {
        return TestString1.ToLowerInvariant().Equals(TestString2);
    }

    [Benchmark]
    public bool ToUpper_Different()
    {
        return TestString1.ToUpper().Equals(TestString2);
    }

    [Benchmark]
    public bool ToUpperInvariant_Different()
    {
        return TestString1.ToUpperInvariant().Equals(TestString2);
    }

    [Benchmark]
    public bool StringEquals_OrdinalIgnoreCase_Different()
    {
        return string.Equals(TestString1, TestString2, StringComparison.OrdinalIgnoreCase);
    }

    [Benchmark]
    public bool ToLower_SameIgnoreCase()
    {
        return TestString1.ToLower().Equals(TestString3);
    }

    [Benchmark]
    public bool ToLowerInvariant_SameIgnoreCase()
    {
        return TestString1.ToLowerInvariant().Equals(TestString3);
    }

    [Benchmark]
    public bool ToUpper_SameIgnoreCase()
    {
        return TestString1.ToUpper().Equals(TestString3.ToUpper());
    }

    [Benchmark]
    public bool ToUpperInvariant_SameIgnoreCase()
    {
        return TestString1.ToUpperInvariant().Equals(TestString3.ToUpperInvariant());
    }

    [Benchmark(Baseline = true)]
    public bool StringEquals_OrdinalIgnoreCase_SameIgnoreCase()
    {
        return string.Equals(TestString1, TestString3, StringComparison.OrdinalIgnoreCase);
    }
}