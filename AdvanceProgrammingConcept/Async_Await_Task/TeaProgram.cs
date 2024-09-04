using Dumpify;

namespace Async_Await_Task;

public static class TeaProgram
{
    public static async Task TeaProgramMain()
    {
        ////MakeTea();
        ////Console.WriteLine();
        ////await MakeTeaAsync();
        ////Console.WriteLine();
        await MakeTeaWithOtherProcessAsync();
        await MakeTeaWithOnlyTaskAsync();
    }

    private static Task<string> MakeTeaWithOnlyTaskAsync()
    {
        var boilingWater = BoilWaterWithOnlyTaskAsync();

        "take the cups out".Dump();

        int a = 0;
        for (int i = 0; i < 100_000_00; i++) { a += i; }

        "put tea in cups".Dump();

        var water = boilingWater;

        var tea = $"pour {water} in cups".Dump();

        return Task.FromResult(tea);
    }
    private async static Task<string> BoilWaterWithOnlyTaskAsync()
    {
        "Start the kettle".Dump();

        "Waiting for the Kettle".Dump();

        await Task.Delay(100);

        "Kettle finished boiling".Dump();

        return "water";
    }
/*
How It Works:
Start Boiling Water: 
BoilWaterWithOnlyTaskAsync starts, but because you never await the result, the method continues immediately.
No Pause: 
The method does not wait for the water to finish boiling. 
Instead, it immediately proceeds to the next lines of code, including the for-loop and the final return statement.

Execution Flow:
"Start the kettle"
"take the cups out"
"Waiting for the Kettle"
Other work continues (like the for-loop and "put tea in cups")
Final Return: The method tries to return the result before the kettle has finished boiling.
 */

    private static async Task<string> MakeTeaWithOtherProcessAsync()
    {
        var boilingWater = BoilWaterWithOtherProcessAsync();

        "take the cups out".Dump();

        int a = 0;
        for (int i = 0; i < 100_000_00; i++) { a += i;  }

        "put tea in cups".Dump();

        var water = await boilingWater;

        var tea = $"pour {water} in cups".Dump();

        return tea;
    }
    private async static Task<string> BoilWaterWithOtherProcessAsync()
    {
        "Start the kettle".Dump();

        "Waiting for the Kettle".Dump();

        await Task.Delay(100);

        "Kettle finished boiling".Dump();

        return "water";
    }
    /*
    How It Works:
    Start Boiling Water: 
    BoilWaterWithOtherProcessAsync starts, and the kettle begins boiling water asynchronously.
    Proceed with Other Work: 
    The method immediately continues to the next line, allowing other work (like taking the cups out and preparing the tea)
    to be done concurrently while the water is boiling.
    Await Completion: 
    The await keyword is used to pause the method execution at that point until the water is boiled. 
    Once the kettle finishes boiling, the method resumes, and the water is poured into the cups.

    Execution Flow:
        "Start the kettle"
        "take the cups out"
        "Waiting for the Kettle"
        Other work continues (like the for-loop and "put tea in cups")
        "Kettle finished boiling"
        Finally, pour the water into the cups
    */

/*
Key Differences:
Concurrency: 
The MakeTeaWithOtherProcessAsync method allows for asynchronous execution and correctly 
waits for the water to finish boiling before proceeding. 
In contrast, MakeTeaWithOnlyTaskAsync does not wait for the boiling to complete, leading to an incorrect sequence of operations.
Final Output: 
In MakeTeaWithOnlyTaskAsync, the boilingWater variable will not hold the correct result
because it doesn't wait for the water to finish boiling. 
It will try to use a Task<string> directly, which will lead to an incorrect result.

Conclusion:
You will not get the same result with these two methods. 
The async/await pattern in MakeTeaWithOtherProcessAsync ensures that the asynchronous operations are properly awaited, 
leading to a correct and expected flow of operations. 
The second version, MakeTeaWithOnlyTaskAsync, does not wait for the tasks to complete, 
which breaks the expected sequence and will likely produce an incorrect result.
*/

    private static async Task<string> MakeTeaAsync()
    {
        var boilingWater = BoilWaterAsync();

        "take the cups out".Dump();

        "put tea in cups".Dump();

        var water = await boilingWater;

        var tea = $"pour {water} in cups".Dump();

        return tea;
    }
    private async static Task<string> BoilWaterAsync()
    {
        "Start the kettle".Dump();

        "Waiting for the Kettle".Dump();

        await Task.Delay(2000);

        "Kettle finished boiling".Dump();

        return "water";
    }

    private static string MakeTea()
    {
        var water = BoilWater();

        "take the cups out".Dump();

        "put tea in cups".Dump();

        var tea = $"pour {water} in cups".Dump();

        return tea;
    }
    private static string BoilWater()
    {
        "Start the kettle".Dump();

        "Waiting for the Kettle".Dump();

        Task.Delay(2000).GetAwaiter().GetResult();

        "Kettle finished boiling".Dump();

        return "water";
    }
}
