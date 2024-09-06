using Dumpify;

namespace IEnumerableGenerator;

public static class IEnumerableProgram
{
    public static void IEnumerableProgramMain()
    {
        get().Dump();
        //
        var enumerable = get();
        enumerable.Dump();
        enumerable.Dump();
        //
        var enumerables = get();
        var count = enumerables.Count();
        count.Dump("Count");
        foreach (var e in enumerables)
        {
            e.Dump("value from enumerable");
        }
        //
        var list = get().ToList();
        var countList = list.Count;
        countList.Dump("CountList");
        foreach (var e in list)
        {
            e.Dump("value from list");
        }
        //
        get()
            .Where(num => num.Dump("Where") < 10)
            .Select(num => num);

        //
        get()
            .Where(num => num.Dump("Where") < 10)
            .Select(num => num)
            .Count();
    }
    public static IEnumerable<int> get()
    {
        "1".Dump();
        yield return 1;
        "2".Dump();
        yield return 2;
        "3".Dump();
    }
}
