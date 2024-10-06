namespace AbstractFactory.geeksforgeeks;

// Concrete Factory for Europe Cars
public class EuropeCarFactory : ICarFactory
{
    public ICar createCar()
    {
        return new HatchBack();
    }

    public ICarSpecification createSpecification()
    {
        return new EuropeSpecification();
    }
}
