namespace Prototype.PrototypePattern;

internal class TreeSeed : Seed
{
    public string Type { get; }

    public TreeSeed(string type) => Type = type;

    public override Seed Copy() => new TreeSeed(Type);
}