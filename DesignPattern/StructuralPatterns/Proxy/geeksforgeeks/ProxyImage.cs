namespace Proxy.geeksforgeeks;

public class ProxyImage : Image
{
    private RealImage realImage;
    private String filename;

    public ProxyImage(String filename)
    {
        this.filename = filename;
    }

    public void display()
    {
        if (realImage == null)
        {
            realImage = new RealImage(filename);
        }
        realImage.display();
    }
}
