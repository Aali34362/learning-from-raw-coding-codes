using Dumpify;

namespace Prototype.PrototypePattern;

public class ExcelOperationProgram
{
    public static void ExcelOperationMain()
    {
        List<IBlock> grid = new List<IBlock>();
        grid.Add(BlockFactory.Create("Hello World"));
        grid.Add(BlockFactory.Create("3"));
        grid.Add(BlockFactory.Create("11/02/1980"));
        grid.Dump();

        var block3 = (DateTimeBlock)grid[2].Clone();
        block3.Format = "MM/dd/yyyy";
        grid.Add(block3);

        var block4 = (DateTimeBlock)grid[3].Clone();
        block4.DateTime = DateTime.UtcNow;
        grid.Add(block4);
        grid.Dump();
    }
}
