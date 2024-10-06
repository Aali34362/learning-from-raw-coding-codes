namespace AbstractFactory.geeksforgeeks;

// Concrete Product for Europe Car Specification
public class EuropeSpecification : ICarSpecification
{
    public void display()
    {
        Console.WriteLine("Europe Car Specification: Fuel efficiency and emissions compliant with EU standards.");
    }
}
