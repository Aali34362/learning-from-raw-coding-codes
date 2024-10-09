namespace AbstractFactory.AbstractFactoryPattern;

public abstract class Element
{
    protected abstract Button CreateButton();
    public Element() => CreateButton();
}
