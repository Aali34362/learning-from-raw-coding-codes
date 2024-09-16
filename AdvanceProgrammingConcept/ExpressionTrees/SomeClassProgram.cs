using Dumpify;
using System.Linq.Expressions;

namespace ExpressionTrees;

public static class SomeClassProgram
{
    public static void SomeClassProgramMain()
    {
        var selectProperty = "number";
        var someClass = new SomeClass()
        {
            Word = "Hello World",
            Number = 1234
        };
        if (selectProperty == "number")
        {
            someClass.Number.Dump();
        }
        else if (selectProperty == "word")
        {
            someClass.Word.Dump();
        }

        //Expression.
    }
}
