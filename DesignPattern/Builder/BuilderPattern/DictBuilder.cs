namespace Builder.BuilderPattern;

public class DictBuilder : IKeyValueCollectionBuilder
{
    private Dictionary<string, string> Dictionary = new Dictionary<string, string>();

    public IKeyValueCollectionBuilder Add(string key, string value)
    {
        Dictionary[key] = value;
        return this;
    }

    public Dictionary<string, string> Build()
    {
        return Dictionary;
    }
}
