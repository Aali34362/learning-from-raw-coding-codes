using Dumpify;

namespace Prototype.PrototypePattern;

public static class SeedPrototypeProgram
{
    public static void SeedPrototypeMain()
    {
        var garden = new GardenFactory(
        new TreeSeed("Apple"),
        new GrassSeed("Red"),
        new FlowerSeed("Roses")
    );

        garden.CreatePlant1().Dump();
        garden.CreatePlant2().Dump();
        garden.CreatePlant3().Dump();
    }
}
