namespace Decorator.geeksforgeeks;

public static class GeeksForGeeksProgram
{
    public static void GeeksForGeeksMain()
    {
        // Plain Coffee
        Coffee coffee = new PlainCoffee();
        Console.WriteLine("Description: " + coffee.getDescription());
        Console.WriteLine("Cost: $" + coffee.getCost());

        // Coffee with Milk
        Coffee milkCoffee = new MilkDecorator(new PlainCoffee());
        Console.WriteLine("\nDescription: " + milkCoffee.getDescription());
        Console.WriteLine("Cost: $" + milkCoffee.getCost());

        // Coffee with Sugar and Milk
        Coffee sugarMilkCoffee = new SugarDecorator(new MilkDecorator(new PlainCoffee()));
        Console.WriteLine("\nDescription: " + sugarMilkCoffee.getDescription());
        Console.WriteLine("Cost: $" + sugarMilkCoffee.getCost());
    }
}
