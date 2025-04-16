## StringComparisons

| Method                                        | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-----:|-------:|----------:|------------:|
| StringEquals_OrdinalIgnoreCase_SameIgnoreCase |  0.0020 ns | 0.0050 ns | 0.0047 ns |  0.0000 ns |     ? |       ? |    1 |      - |         - |           ? |
| StringEquals_OrdinalIgnoreCase_Different      |  0.0128 ns | 0.0164 ns | 0.0154 ns |  0.0084 ns |     ? |       ? |    1 |      - |         - |           ? |
| ToLowerInvariant_Different                    | 12.6559 ns | 0.2825 ns | 0.3469 ns | 12.6351 ns |     ? |       ? |    2 | 0.0045 |      56 B |           ? |
| ToUpperInvariant_Different                    | 12.7825 ns | 0.2856 ns | 0.5570 ns | 12.8122 ns |     ? |       ? |    2 | 0.0044 |      56 B |           ? |
| ToUpper_Different                             | 14.1640 ns | 0.2696 ns | 0.2522 ns | 14.1481 ns |     ? |       ? |    3 | 0.0044 |      56 B |           ? |
| ToLowerInvariant_SameIgnoreCase               | 14.8318 ns | 0.3252 ns | 0.6716 ns | 14.6915 ns |     ? |       ? |    3 | 0.0044 |      56 B |           ? |
| ToLower_Different                             | 15.0654 ns | 0.3247 ns | 0.3739 ns | 14.9746 ns |     ? |       ? |    3 | 0.0044 |      56 B |           ? |
| ToLower_SameIgnoreCase                        | 16.5013 ns | 0.3476 ns | 0.7408 ns | 16.4958 ns |     ? |       ? |    4 | 0.0044 |      56 B |           ? |
| ToUpperInvariant_SameIgnoreCase               | 28.1605 ns | 0.5955 ns | 1.3197 ns | 28.0614 ns |     ? |       ? |    5 | 0.0089 |     112 B |           ? |
| ToUpper_SameIgnoreCase                        | 31.7584 ns | 0.6512 ns | 0.5773 ns | 31.6717 ns |     ? |       ? |    6 | 0.0089 |     112 B |           ? |

// * Warnings *
ZeroMeasurement
StringComparisons.StringEquals_OrdinalIgnoreCase_SameIgnoreCase: Default -> The method duration is indistinguishable from the empty method duration
StringComparisons.StringEquals_OrdinalIgnoreCase_Different: Default      -> The method duration is indistinguishable from the empty method duration


## StringFormat

| Method        | Mean       | Error     | StdDev    | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|-------------- |-----------:|----------:|----------:|------:|--------:|-----:|-------:|----------:|------------:|
| Interpolation |  0.4472 ns | 0.0235 ns | 0.0209 ns |  1.00 |    0.06 |    1 |      - |         - |          NA |
| Concat        | 19.2632 ns | 0.3358 ns | 0.3141 ns | 43.16 |    2.10 |    2 | 0.0044 |      56 B |          NA |
| Format        | 44.2375 ns | 0.8986 ns | 0.8406 ns | 99.12 |    4.90 |    3 | 0.0044 |      56 B |          NA |

## StringConcat

| Method        | Mean     | Error    | StdDev   | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|-------------- |---------:|---------:|---------:|------:|--------:|-----:|-------:|----------:|------------:|
| StringBuilder | 230.9 ns |  4.56 ns |  6.55 ns |  1.00 |    0.04 |    1 | 0.1018 |   1.25 KB |        1.00 |
| Loop          | 688.9 ns | 13.22 ns | 30.10 ns |  2.99 |    0.15 |    2 | 0.4539 |   5.56 KB |        4.45 |

## SealedVsUnsealed

| Method    | Mean      | Error     | StdDev    | Ratio | RatioSD | Rank | Allocated | Alloc Ratio |
|---------- |----------:|----------:|----------:|------:|--------:|-----:|----------:|------------:|
| Sealed    | 0.0322 ns | 0.0096 ns | 0.0090 ns |  0.14 |    0.04 |    1 |         - |          NA |
| NonSealed | 0.2459 ns | 0.0340 ns | 0.0487 ns |  1.03 |    0.27 |    2 |         - |          NA |

## DateTimeNow

| Method | Mean      | Error    | StdDev   | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|------- |----------:|---------:|---------:|------:|--------:|-----:|-------:|----------:|------------:|
| UtcNow |  90.60 ns | 1.862 ns | 1.742 ns |  1.00 |    0.03 |    1 | 0.0050 |      64 B |        1.00 |
| Now    | 145.75 ns | 2.796 ns | 2.479 ns |  1.61 |    0.04 |    2 | 0.0050 |      64 B |        1.00 |
