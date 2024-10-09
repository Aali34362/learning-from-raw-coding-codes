namespace AbstractFactory.geeksforgeeks;

public interface ICarFactory
{
    ICar createCar();
    ICarSpecification createSpecification();
}
