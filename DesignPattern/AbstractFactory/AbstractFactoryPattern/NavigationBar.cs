using Dumpify;

namespace AbstractFactory.AbstractFactoryPattern;

////public class NavigationBar
////{
////    //public NavigationBar(Apple factory) => factory.CreateButton();
////    public NavigationBar(IUIFactory factory) => factory.CreateButton();
////}

public class NavigationBar : Element
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
