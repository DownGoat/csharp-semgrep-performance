using System;
using System.Collections.Generic;
using System.Linq;

namespace SemgrepClosureTests;
public class SemgrepClosureTestCases
{

    private string _stringField = "Hello, World!";
    private string _classItem = "Hello, World!";


    // https://github.com/stephentoub/runtime/blob/ddf3b96b5768543bec00bbb20dd53f83d857d25b/src/libraries/System.ComponentModel.Annotations/src/System/ComponentModel/DataAnnotations/ValidationContext.cs
    public ValidationContext(object instance, IServiceProvider? serviceProvider, IDictionary<object, object?>? items)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }

        if (serviceProvider != null)
        {
            var foo = InitializeServiceProvider(serviceType => serviceProvider.GetService(serviceType));
        }

        _items = items != null ? new Dictionary<object, object?>(items) : new Dictionary<object, object?>();
        ObjectInstance = instance;
    }

    public void ExternalInLambdaThatCanUseLoopParameterLocalVar(string item) {
        var externalVar = string.Empty;

        var list = new List<string> { "a", "b", "c" };

        externalVar = list.Find(s => s.Equals(item));
    }

    public void ExternalInLambdaThatCanUseLoopParameterClassField(string item) {
        var list = new List<string> { "a", "b", "c" };

        _stringField = list.Find(s => s.Equals(item));
    }

    public void ExternalInLambdaThatCanUseLoopParameterLocalVar() {
        var externalVar = string.Empty;

        var list = new List<string> { "a", "b", "c" };

        externalVar = list.Find(s => s.Equals(_classItem));
    }

    public void ExternalInLambdaThatCanUseLoopParameterClassField() {
        var list = new List<string> { "a", "b", "c" };

        _stringField = list.Find(s => s.Equals(_classItem));
    }
}