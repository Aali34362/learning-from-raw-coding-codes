namespace Decorator.DecoratorPattern;

public class InjectedFunctionality : BaseDecorator
{
    // supply original known object as parameter enables composability
    public InjectedFunctionality(IDumbData data) : base(data) { }

    public override string Name
    {
        get => data.Name;
        set
        {
            data.Name = value;
            EmitEvent(value);
        }
    }

    private void EmitEvent(string name)
    {
        // added functionality/responsiblity is not know to the outside, 
        // in favour of ability to pick decoration at runtime
        Console.WriteLine($"Event emitted: Name changed to '{name}'");
    }
}
