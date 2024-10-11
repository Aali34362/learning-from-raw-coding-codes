namespace Decorator.geeksforgeeks;

internal class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(Coffee decoratedCoffee) : base(decoratedCoffee)
    {
    }
    public String getDescription() => decoratedCoffee.getDescription() + ", Sugar";
    public double getCost() => decoratedCoffee.getCost() + 0.2;
}