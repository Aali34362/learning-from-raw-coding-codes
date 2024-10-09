namespace Prototype.GPTExample;

public abstract class Shape
{
    public string? Id { get; set; }
    public string? Type { get; set; }

    // Abstract Clone method to be implemented by concrete classes.
    public abstract Shape Clone();

    public override string ToString() => $"Shape [Id: {Id}, Type: {Type}]";
    
}
