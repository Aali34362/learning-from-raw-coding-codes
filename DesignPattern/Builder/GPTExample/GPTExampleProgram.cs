using Builder.GPTExample.Model;

namespace Builder.GPTExample;

public static class GPTExampleProgram
{
    public static void GPTExampleMain()
    {
        ICarBuilder builder = new CarBuilder();

        // Use the builder to create a sports car
        var director = new Director();
        director.ConstructSportsCar(builder);
        Car sportsCar = builder.Build();
        Console.WriteLine("Sports Car Built:");
        Console.WriteLine(sportsCar);

        // Use the builder to create an SUV
        builder = new CarBuilder(); // Reset the builder
        director.ConstructSUV(builder);
        Car suvCar = builder.Build();
        Console.WriteLine("\nSUV Built:");
        Console.WriteLine(suvCar);

        // Custom Car built directly without director
        builder = new CarBuilder();
        Car customCar = builder.SetModel("Custom Car")
                               .SetEngine("Hybrid")
                               .SetNumberOfSeats(4)
                               .SetTransmission("Automatic")
                               .SetGPS(true)
                               .Build();
        Console.WriteLine("\nCustom Car Built:");
        Console.WriteLine(customCar);
    }
}
