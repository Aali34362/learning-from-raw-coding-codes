namespace Prototype.PrototypePattern;

internal class NumberBlock : IBlock
{
    public int Number { get; set; }
    public IBlock Clone() => new NumberBlock { Number = Number };

    public string Render => Number.ToString();
}