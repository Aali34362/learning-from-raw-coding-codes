namespace Prototype.GPTExample;

public class Circle : Shape
{
    public int Radius { get; set; }

    public Circle()
    {
        Type = "Circle";
    }
    
    // Implement the Clone method
    public override Shape Clone() => (Shape)this.MemberwiseClone();
    
    public override string ToString() => $"Circle [Id: {Id}, Type: {Type}, Radius: {Radius}]";
    
}
