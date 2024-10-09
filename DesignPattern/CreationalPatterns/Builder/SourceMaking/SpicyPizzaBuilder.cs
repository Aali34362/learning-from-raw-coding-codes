namespace Builder.SourceMaking;

public class SpicyPizzaBuilder : PizzaBuilder
{
    public override void buildDough()
    {
        pizza!.setDough("pan baked");
    }

    public override void buildSauce()
    {
        pizza!.setSauce("hot");
    }

    public override void buildTopping()
    {
        pizza!.setTopping("pepperoni+salami");
    }
}
