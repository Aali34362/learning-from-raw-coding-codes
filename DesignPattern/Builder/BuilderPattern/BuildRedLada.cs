using Dumpify;

namespace Builder.BuilderPattern;

public static class BuildRedLada
{
    public static void BuildRedLadaMain()
    {
        var builder = new CarBuilder();
        BuildRedLada1980(builder);
        builder.Build().Dump();
    }

    private static void BuildRedLada1980(ICarBuilder builder)
    {
        builder
            .setMake("lada")
            .setColor("red")
            .setManufactureDate(DateTime.UtcNow);
    }

}
