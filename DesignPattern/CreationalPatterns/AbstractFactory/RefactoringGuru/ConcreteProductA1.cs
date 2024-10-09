namespace AbstractFactory.RefactoringGuru;

// Concrete Products are created by corresponding Concrete Factories.
public class ConcreteProductA1 : IAbstractProductA
{
    public string UsefulFunctionA()
    {
        return "The result of the product A1.";
    }
}
