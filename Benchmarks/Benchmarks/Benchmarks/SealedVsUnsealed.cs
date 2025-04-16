///
/// From https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#%E2%80%9Cpeanut-butter%E2%80%9D
/// 
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class SealedVsUnsealed
{
    private SealedType _sealed = new();
    private NonSealedType _nonSealed = new();

    [Benchmark(Baseline = true)]
    public int NonSealed() => _nonSealed.M() + 42;

    [Benchmark]
    public int Sealed() => _sealed.M() + 42;
}

public class BaseType
{
    public virtual int M() => 1;
}

public class NonSealedType : BaseType
{
    public override int M() => 2;
}

public sealed class SealedType : BaseType
{
    public override int M() => 2;
}