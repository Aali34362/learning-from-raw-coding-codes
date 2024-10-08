namespace Builder.BuilderPattern;

public class CarBuilder : ICarBuilder
{
    private Car _car = new Car();

    public ICarBuilder setMake(string make)
    {
        _car.Make = make;
        return this;
    }

    public ICarBuilder setColor(string color)
    {
        _car.Colour = color;
        return this;
    }

    public ICarBuilder setManufactureDate(DateTime date)
    {
        _car.ManifactureDate = date.ToString("dd/MM/yyyy");
        return this;
    }

    public Car Build() => _car;
}