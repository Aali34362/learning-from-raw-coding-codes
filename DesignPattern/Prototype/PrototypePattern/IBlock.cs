namespace Prototype.PrototypePattern;

public interface IBlock
{
    string Render { get; }
    IBlock Clone();
}
