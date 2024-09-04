namespace Async_Await_Task;

public class TrafficLightProgram
{
    private object trafficLock = new object();
    public void PassCar(string carName)
    {
        Monitor.Enter(trafficLock);
        try
        {
            Console.WriteLine($"{carName} is passing through the traffic light...");
            Thread.Sleep(1000); // Simulate the time it takes to pass the intersection
        }
        finally
        {
            Monitor.Exit(trafficLock);
            Console.WriteLine($"{carName} has passed the traffic light.");
        }
    }
}
