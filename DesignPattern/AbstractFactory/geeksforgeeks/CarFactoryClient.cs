namespace AbstractFactory.geeksforgeeks;

public static class CarFactoryClient
{
    public static void CarFactoryClientMain()
    {
        // Creating cars for North America
        ICarFactory northAmericaFactory = new NorthAmericaCarFactory();
        ICarSpecification northAmericaCarSpecification = northAmericaFactory.createSpecification();
        ICar northAmericaCar = northAmericaFactory.createCar();
        northAmericaCar.assemble();
        northAmericaCarSpecification.display();

        // Creating cars for Europe
        ICarFactory europeFactory = new EuropeCarFactory();
        ICar europeCar = europeFactory.createCar();
        ICarSpecification europeSpec = europeFactory.createSpecification();
        europeCar.assemble();
        europeSpec.display();
    }
}
