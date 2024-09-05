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
        /*
         * So the problem with fire and forget is, it is in the scope
         * So lets say the above code may be in service and usually we resolve services
         * is we implement or inject Dependency Injection
         * So SendNotification will be consume by one of the services that was injected
         * because we exit this scope before the notification is actually finished sending
         * the DI is going to dispose of that service that was injected 
         * Once that service is disposed when the sudden send notification is gonna try to consume it 
         * that's when the trouble gonna arise and this gonna crash like service no longer exist.
         * So this is where we might use channel where we say put a message what you wanna send in a channel and when a service is ready you can pick it up
         * Another problem with this solution is :
         * when we are running it on one processor machine and we have 100 user one day and they all generated 10 notifications each 
         * because it's may be a slow processor it might take one second to send a notification 
         * we are essentially flooding the task you with these fire and forget task and at some point server is gonna be slow to respond
         * So we might want to limit our amount of task that get processed at the same time 
         */
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
