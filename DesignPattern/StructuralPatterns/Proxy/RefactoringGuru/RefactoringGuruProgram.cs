namespace Proxy.RefactoringGuru;

public static class RefactoringGuruProgram
{
    public static void RefactoringGuruMain()
    {
        Client client = new Client();

        Console.WriteLine("Client: Executing the client code with a real subject:");
        RealSubject realSubject = new RealSubject();
        client.ClientCode(realSubject);

        Console.WriteLine();

        Console.WriteLine("Client: Executing the same client code with a proxy:");
        ProxySubject proxy = new ProxySubject(realSubject);
        client.ClientCode(proxy);
    }
}
