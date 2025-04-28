using System;
using System.Collections.Generic;
using System.Linq;

namespace SemgrepClosureTests;
public class MemoryStreamTestCases
{
    public void ExternalInLambdaThatCanUseLoopParameterLocalVar(string item) {
        using MemoryStream ms = new MemoryStream();

        ms.ToArray();
    }
}