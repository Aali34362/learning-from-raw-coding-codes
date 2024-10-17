using System.Net;
using System.Net.Sockets;

namespace Proxy.SourceMaking;

public class SocketProxy : ISocketInterface
{
    private Socket socket;
    private StreamReader reader;
    private StreamWriter writer;

    public SocketProxy(string host, int port, bool wait)
    {
        try
        {
            if (wait)
            {
                TcpListener listener = new TcpListener(IPAddress.Parse(host), port);
                listener.Start();
                socket = listener.AcceptSocket();
            }
            else
            {
                TcpClient client = new TcpClient(host, port);
                socket = client.Client;
            }
            NetworkStream stream = new NetworkStream(socket);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public string ReadLine()
    {
        try
        {
            return reader.ReadLine()!;
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
            return null!;
        }
    }

    public void WriteLine(string str)
    {
        writer.WriteLine(str);
    }

    public void Dispose()
    {
        try
        {
            socket.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
