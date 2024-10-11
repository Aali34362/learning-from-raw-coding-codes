using Dumpify;

namespace Decorator.DecoratorPattern;

public class Doer : IDoSomething
{
    public void Something() => "Something".Dump();
}
