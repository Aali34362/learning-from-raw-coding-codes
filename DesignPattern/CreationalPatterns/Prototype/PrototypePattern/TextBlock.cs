namespace Prototype.PrototypePattern;

public class TextBlock : IBlock
{
    public string? Content { get; set; }
    public IBlock Clone() => new TextBlock { Content = Content };

    public string Render => Content;
}
