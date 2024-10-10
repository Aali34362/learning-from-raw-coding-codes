namespace Adapter.SourceMaking;

public class LineAdapter : IShape
{
    private Line adaptee;
    public LineAdapter(Line line)
    {
        this.adaptee = line;
    }

    public void draw(int x, int y, int z, int j)
    {
        adaptee.draw(x, y, x, y);
    }
}
