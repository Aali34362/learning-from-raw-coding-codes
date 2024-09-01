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
    }

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
