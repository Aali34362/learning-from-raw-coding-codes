namespace AbstractFactory.geeksforgeeks;

// Concrete Factory for North America Cars
public class NorthAmericaCarFactory : ICarFactory
{
    public ICar createCar()
    {
        return new Sedan();
    }

    public ICarSpecification createSpecification()
    {
        return new NorthAmericaSpecification();
    }
}
