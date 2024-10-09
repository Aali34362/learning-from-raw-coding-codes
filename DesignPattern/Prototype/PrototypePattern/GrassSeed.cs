namespace Prototype.PrototypePattern;

public class GrassSeed : Seed
{
    public string Type { get; }

    public GrassSeed(string type) => Type = type;

    public override Seed Copy() => new GrassSeed(Type);
}
