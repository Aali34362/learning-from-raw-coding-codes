namespace Builder.BuilderPattern;

public interface ICarBuilder
{
    public ICarBuilder setMake(string make);
    public ICarBuilder setColor(string color);
    public ICarBuilder setManufactureDate(DateTime date);
}
