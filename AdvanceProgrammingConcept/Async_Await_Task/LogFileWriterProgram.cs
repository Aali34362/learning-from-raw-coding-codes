namespace Async_Await_Task;

public class LogFileWriterProgram
{
    private static Mutex fileMutex = new Mutex(false, "LogFileMutex");
    public void WriteLog(string message)
    {
        fileMutex.WaitOne(); // Acquire the mutex
        try
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
        finally
        {
            fileMutex.ReleaseMutex(); // Release the mutex
        }
    }
}
