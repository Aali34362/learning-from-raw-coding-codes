namespace Builder.SourceMaking;

public class HawaiianPizzaBuilder : PizzaBuilder
{
    public override void buildDough()
    {
        pizza!.setDough("cross");
    }

    public override void buildSauce()
    {
        pizza!.setSauce("mild");
    }

    public override void buildTopping()
    {
        pizza!.setTopping("ham+pineapple");
    }
}
