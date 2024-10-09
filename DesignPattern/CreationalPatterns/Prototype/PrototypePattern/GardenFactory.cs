namespace Prototype.PrototypePattern;

public class GardenFactory
{
    Seed _seed1;
    Seed _seed2;
    Seed _seed3;

    public GardenFactory(
        Seed seed1,
        Seed seed2,
        Seed seed3
    )
    {
        _seed1 = seed1;
        _seed2 = seed2;
        _seed3 = seed3;
    }
    internal Seed CreatePlant1() => _seed1.Copy();
    internal Seed CreatePlant2() => _seed2.Copy();
    internal Seed CreatePlant3() => _seed3.Copy();
}
