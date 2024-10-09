namespace Prototype.PrototypePattern;

public class FlowerSeed : Seed
{
    public string Type { get; }

    public FlowerSeed(string type) => Type = type;

    public override Seed Copy() => new FlowerSeed(Type);
}