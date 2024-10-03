using Dumpify;

namespace Factory.FactoryPattern;

public class ButtonFactory
{
    public static Button CreateButton()
    {
        return new Button { Type = "Default Button" }.Dump();
    }
}
