using Dumpify;

namespace AbstractFactory.AbstractFactoryPattern;

public class NavigationBar
{
    //public navigationbar(apple factory) => factory.createbutton();
    public NavigationBar(IUIFactory factory) => factory.CreateButton();
}

public class NavigationBarFactoryMethod : Element
{
    protected override Button CreateButton()
    {
        return new Button { Type = "Default Button".Dump() };
    }
}

public class AndroidNavigationBar : Element
{
    protected override Button CreateButton()
    {
        return new Button { Type = "Android Button".Dump() };
    }
}
