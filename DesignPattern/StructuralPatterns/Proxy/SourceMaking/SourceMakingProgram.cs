namespace Proxy.SourceMaking;

public static class SourceMakingProgram
{
    public static void SourceMakingMain(string[] args)
    {
        ISocketInterface socket = new SocketProxy("127.0.0.1", 8080, args[0].Equals("first") ? true : false);
        string str;
        bool skip = true;

        while (true)
        {
            if (args[0].Equals("second") && skip)
            {
                skip = !skip;
            }
            else
            {
                str = socket.ReadLine();
                Console.WriteLine("Receive - " + str);
                if (str == null)
                {
                    break;
                }
            }

            Console.Write("Send ---- ");
            str = Console.ReadLine()!;
            socket.WriteLine(str);
            if (str.Equals("quit"))
            {
                break;
            }
        }
        socket.Dispose();
    }
}
