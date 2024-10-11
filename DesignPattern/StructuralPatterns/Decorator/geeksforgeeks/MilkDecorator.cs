namespace Decorator.geeksforgeeks;

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(Coffee decoratedCoffee) : base(decoratedCoffee)
    {
    }
    public String getDescription() => decoratedCoffee.getDescription() + ", Milk";
    public double getCost() => decoratedCoffee.getCost() + 0.5;
}
