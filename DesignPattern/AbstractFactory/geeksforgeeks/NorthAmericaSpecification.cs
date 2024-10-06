namespace AbstractFactory.geeksforgeeks;

// Concrete Product for North America Car Specification
public class NorthAmericaSpecification : ICarSpecification
{
    public void display()
    {
        Console.WriteLine("North America Car Specification: Safety features compliant with local regulations.");
    }
}
