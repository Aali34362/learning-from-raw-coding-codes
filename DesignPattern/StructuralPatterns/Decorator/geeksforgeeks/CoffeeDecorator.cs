namespace Decorator.geeksforgeeks;

public abstract class CoffeeDecorator : Coffee
{
    protected Coffee decoratedCoffee;
    public CoffeeDecorator(Coffee decoratedCoffee)
    {
        this.decoratedCoffee = decoratedCoffee;
    }
    public double getCost() => decoratedCoffee.getCost();
    public string getDescription() => decoratedCoffee.getDescription();
}
