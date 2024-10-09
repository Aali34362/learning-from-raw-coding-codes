using Dumpify;

namespace AbstractFactory.AbstractFactoryPattern;

public class Apple : IUIFactory
{
    public Button CreateButton()
    {
        return new Button { Type = "iOS Button".Dump() };
    }
}
