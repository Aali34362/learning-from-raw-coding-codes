namespace Factory.RefactoringGuru;

// Concrete Creators override the factory method in order to change the resulting product's type.
public class ConcreteCreator1 : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct1();
    }
}
