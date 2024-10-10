namespace Adapter.SourceMaking;

public class RectangleAdapter : IShape
{
    private Rectangle adaptee;
    public RectangleAdapter(Rectangle rectangle)
    {
        this.adaptee = rectangle;
    }

    public void draw(int x1, int y1, int x2, int y2)
    {
        int x = Math.Min(x1, x2);
        int y = Math.Min(y1, y2);
        int width = Math.Abs(x2 - x1);
        int height = Math.Abs(y2 - y1);
        adaptee.draw(x, y, width, height);
    }
}
