namespace Builder.BuilderPattern;

public static class ConstructionProcessProgram
{
    public static void ConstructionProcessMain()
    {
        QueryBuilder builder = new QueryBuilder();

        ConstructionProcess(builder);
        builder.Build().Dump();
    }
    private static void ConstructionProcess(IKeyValueCollectionBuilder builder)
    {
        builder.Add("make", "chocolate")
            .Add("color", "red")
            .Add("year", 1990.ToString());
    }
}
