namespace Prototype.GPTExample;

public class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle()
    {
        Type = "Rectangle";
    }
    // Implement the Clone method
    public override Shape Clone() => (Shape)this.MemberwiseClone();    
    public override string ToString() => $"Rectangle [Id: {Id}, Type: {Type}, Width: {Width}, Height: {Height}]";    
}
