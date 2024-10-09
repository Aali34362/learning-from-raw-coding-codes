using Builder.GPTExample.Model;

namespace Builder.GPTExample;


//Implement the Concrete CarBuilder
//The concrete CarBuilder class implements the ICarBuilder interface,
//providing definitions for each step in building a car.
public class CarBuilder : ICarBuilder
{
    private Car _car = new Car();

    public Car Build()
    {
        return _car;
    }

    public ICarBuilder SetEngine(string engineType)
    {
        _car.EngineType = engineType;
        return this;
    }

    public ICarBuilder SetGPS(bool hasGPS)
    {
        _car.HasGPS = hasGPS;
        return this;
    }

    public ICarBuilder SetModel(string model)
    {
        _car.Model = model;
        return this;
    }

    public ICarBuilder SetNumberOfSeats(int seats)
    {
        _car.NumberOfSeats = seats;
        return this;
    }

    public ICarBuilder SetTransmission(string transmission)
    {
        _car.Transmission = transmission;
        return this;
    }
}
