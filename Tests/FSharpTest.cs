using Fody;
using Xunit;
#pragma warning disable 618

public class FSharpTest
{
    TestResult testResult;

    public FSharpTest()
    {
        var weavingTask = new ModuleWeaver();
        testResult = weavingTask.ExecuteTestRun("AssemblyFSharp.dll", runPeVerify: false);
    }

    [Fact]
    public void SimpleClass()
    {
        var instance = testResult.GetInstance("Namespace.ClassWithProperties");
        EventTester.TestProperty(instance, false);
    }
}