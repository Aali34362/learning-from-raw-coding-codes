using Dumpify;

namespace Channels;

public static class ChannelProgram
{
    public static void ChannelProgramMain()
    {
        ProcessSendNotificationUsingFireAndForget();
        ProcessSendNotification();
    }

    public static void ProcessSendNotificationUsingFireAndForget()
    {
        //using Fire and Forget Task
        for (int i = 0; i < 10; i++)
        {
            i.Dump();
            Task.Run(() => SendNotification(i));
        }
    }

    public static void ProcessSendNotification()
    {
        for (int i = 0; i < 10; i++)
        {
            i.Dump();
            SendNotification(i);
        }
    }

    public static void SendNotification(int i)
    {
        //blocking operation
        Task.Delay(1000).GetAwaiter().GetResult();
        $"Complete : {i}".Dump();
    }
}
