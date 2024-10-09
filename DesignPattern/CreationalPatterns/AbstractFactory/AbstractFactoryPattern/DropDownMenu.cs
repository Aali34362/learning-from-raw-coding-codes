using Dumpify;

namespace AbstractFactory.AbstractFactoryPattern;

public class DropDownMenu
{
    //public DropDownMenu(Apple factory) => factory.CreateButton();
    public DropDownMenu(IUIFactory factory) => factory.CreateButton();
}

public class DropDownMenuFactoryMethod : Element
{
    protected override Button CreateButton()
    {
        return new Button { Type = "Default Button".Dump() };
    }
}

public class AndroidDropDownMenu : Element
{
    protected override Button CreateButton()
    {
        return new Button { Type = "Android Button".Dump() };
    }
}