namespace Prototype.PrototypePattern;

public class DateTimeBlock : IBlock
{
    public DateTime DateTime { get; set; }
    public string? Format { get; set; }
    public IBlock Clone() => new DateTimeBlock
    {
        Format = Format,
        DateTime = DateTime
    };

    public string Render => DateTime.ToString(Format);
}