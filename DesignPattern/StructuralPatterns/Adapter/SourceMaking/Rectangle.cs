namespace Adapter.SourceMaking;

public class Rectangle
{
    public void draw(int x, int y, int width, int height)
    {
        Console.WriteLine("Rectangle with coordinate left-down point (" + x + ";" + y + "), width: " + width
                + ", height: " + height);
    }
}
