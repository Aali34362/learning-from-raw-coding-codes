namespace Proxy.geeksforgeeks;

internal class RealImage : Image
{
    private String filename;

    public RealImage(String filename)
    {
        this.filename = filename;
        loadImageFromDisk();
    }

    private void loadImageFromDisk()
    {
        Console.WriteLine("Loading image: " + filename);
    }

    public void display()
    {
        Console.WriteLine("Displaying image: " + filename);
    }
}
