namespace Builder.SourceMaking;

public static class PizzaBuilderDemo
{
    public static void PizzaBuilderMain()
    {
        Waiter waiter = new Waiter();
        PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
        PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();

        waiter.setPizzaBuilder(hawaiianPizzaBuilder);
        waiter.constructPizza();

        Pizza pizzaHawaiian = waiter.getPizza();
        Console.WriteLine("Hawaiian Pizza Built:");
        Console.WriteLine(pizzaHawaiian);

        waiter.setPizzaBuilder(spicyPizzaBuilder);
        waiter.constructPizza();

        Pizza pizzaSpicy = waiter.getPizza();
        Console.WriteLine("\nSpicy Pizza Built:");
        Console.WriteLine(pizzaSpicy);
    }
}
