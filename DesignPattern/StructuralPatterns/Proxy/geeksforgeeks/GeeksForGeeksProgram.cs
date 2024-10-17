namespace Proxy.geeksforgeeks;

public static class GeeksForGeeksProgram
{
    public static void GeeksForGeeksMain()
    {
        Image image = new ProxyImage("example.jpg");

        // Image will be loaded from disk only when display() is called
        image.display();

        // Image will not be loaded again, as it has been cached in the Proxy
        image.display();
    }
}
