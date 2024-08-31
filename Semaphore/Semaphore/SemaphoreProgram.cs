using Dumpify;

namespace SemaphoreCode;

public static class SemaphoreProgram
{
    static SemaphoreSlim gate = new(0);
    static SemaphoreSlim gate1 = new(1);
    static SemaphoreSlim gate2 = new(10);

    public static async Task SemaphoreProgramMain()
    {
        //Checking for other process to get through Gate with initial count as 1 also using release gate
        for (int i = 0; i < 10; i++)
        {
            $"Start for gate1 in loop of {i}".Dump();
            await gate1.WaitAsync();
            $"Do Some Work for gate1 in loop of {i}".Dump();
            gate1.Release();
            $"Finish for gate1 in loop of {i}".Dump();
            Console.WriteLine();
            //now we have one gate when a process comes and uses the gate until it release other process wont be able to access the gate
            //so we use gate.Release() to release the process and let other process to use the gate.
        }

        //Checking with many Gate entries for other process to get through Gate with initial count as 10
        for (int i = 0; i < 10; i++)
        {
            $"Start for gate2 in loop of {i}".Dump();
            await gate2.WaitAsync();
            $"Do Some Work for gate2 in loop of {i}".Dump();
            $"Finish for gate2 in loop of {i}".Dump();
            Console.WriteLine();
            //Every process got their gate to process but this not good
            //because we dont know how many process will come and enter through the gate
            //so we cant make static value define for initial value
        }

        //Checking for other process to get through Gate with initial count as 1
        for (int i = 0; i < 10; i++)
        {
            $"Start for gate1 in loop of {i}".Dump();
            await gate1.WaitAsync();
            $"Do Some Work for gate1 in loop of {i}".Dump();
            $"Finish for gate1 in loop of {i}".Dump();
            Console.WriteLine();
            //because of limit when second process is started to process the gate limit got decremented to 0
            //so its trying to get which is impossible until first process release the gate
            //or we have to increment number of gate from 1 to n.
        }

        //Checking for Gate with initial count as 1
        "Start for gate1".Dump();
        await gate1.WaitAsync();
        "Do Some Work for gate1".Dump();
        "Finish for gate1".Dump();
        Console.WriteLine();

        //Checking for Gate with initial count as 0
        "Start for gate".Dump();
        await gate.WaitAsync();
        "Do Some Work for gate".Dump();
        "Finish for gate".Dump();
        Console.WriteLine();
    }
}
