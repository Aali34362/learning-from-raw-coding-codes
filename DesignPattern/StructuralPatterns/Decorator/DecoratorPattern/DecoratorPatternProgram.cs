using Dumpify;

namespace Decorator.DecoratorPattern;

public static class DecoratorPatternProgram
{
    public static void DecoratorPatternMain()
    {
        // Create the base object
        IDumbData myData = new DumbData
        {
            Id = 1,
            Name = "Original Name",
            Description = "This is a description"
        };

        Console.WriteLine($"Before Decoration: Name = {myData.Name}");

        // Create a decorator to inject additional functionality
        IDumbData decoratedData = new InjectedFunctionality(myData);

        // Change the name - the decorator will add extra behavior
        decoratedData.Name = "New Decorated Name";

        Console.WriteLine($"After Decoration: Name = {decoratedData.Name}");
        Console.WriteLine($"Original Object's Name: {myData.Name}"); // Name is changed in the original object as well

        //Another Example
        var d = new Doer();
        d.Something();
        "---".Dump();

        var atd = new AnotherThing(d);
        atd.Something();
        "---".Dump();

        var iad = new InAddition(d);
        iad.Something();
        "---".Dump();

        var iaatd = new InAddition(atd);
        iaatd.Something();
        "---".Dump();

        var atiad = new AnotherThing(iad);
        atiad.Something();
    }
}
