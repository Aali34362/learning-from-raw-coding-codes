using Builder.GPTExample.Model;
using System.IO;

namespace Builder.GPTExample;


//Create the CarBuilder Interface
//The ICarBuilder interface defines the blueprint for building various parts of the car.
//Each method returns the builder itself, allowing us to chain method calls (fluent interface).

public interface ICarBuilder
{
    ICarBuilder SetModel(string model);
    ICarBuilder SetEngine(string engineType);
    ICarBuilder SetNumberOfSeats(int seats);
    ICarBuilder SetTransmission(string transmission);
    ICarBuilder SetGPS(bool hasGPS);
    Car Build();
}
