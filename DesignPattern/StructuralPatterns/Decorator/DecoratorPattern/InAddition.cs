using Dumpify;

namespace Decorator.DecoratorPattern;

public class InAddition : IDoSomething
{
    protected IDoSomething _doSomething;

    public InAddition(IDoSomething doSomething) => _doSomething = doSomething;

    public void Something()
    {
        _doSomething.Something();
        "In Addition".Dump();
    }
}