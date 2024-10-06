namespace AbstractFactory.geeksforgeeks;

// Concrete Product for Sedan Car
public class Sedan : ICar
{
    public void assemble()
    {
        Console.WriteLine("Assembling Sedan car.");
    }
}
