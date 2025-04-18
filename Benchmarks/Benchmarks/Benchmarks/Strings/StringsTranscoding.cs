using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Strings;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringsTranscoding
{
    [Benchmark]
    public byte[] Encoder()
    {
        return Encoding.UTF8.GetBytes("ThIs A StRiNG");
    }

    [Benchmark(Baseline = true)]
    public byte[] U8ToArray()
    {
        return "ThIs A StRiNG"u8.ToArray();
    }
}