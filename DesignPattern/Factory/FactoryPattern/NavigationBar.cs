using Dumpify;

namespace Factory.FactoryPattern;

public class NavigationBar
{
    public NavigationBar() => ButtonFactory.CreateButton();
}
