using Dumpify;

namespace Factory.FactoryPattern;

public class DropDownMenu
{
    public DropDownMenu() => ButtonFactory.CreateButton();
}
