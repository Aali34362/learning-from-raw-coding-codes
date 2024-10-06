using Dumpify;

namespace AbstractFactory.AbstractFactoryPattern;

public class Android : IUIFactory
{
    public Button CreateButton()
    {
        return new Button { Type = "Android Button".Dump() };
    }
}
