using Dumpify;

namespace Decorator.DecoratorPattern;

public class AnotherThing : IDoSomething
{
    protected IDoSomething _doSomething;

    public AnotherThing(IDoSomething doSomething) => _doSomething = doSomething;

    public void Something()
    {
        _doSomething.Something();
        "Another Thing".Dump();
    }
}
