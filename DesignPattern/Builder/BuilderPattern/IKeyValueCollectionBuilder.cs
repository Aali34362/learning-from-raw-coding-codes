namespace Builder.BuilderPattern;

public interface IKeyValueCollectionBuilder
{
    IKeyValueCollectionBuilder Add(string key, string value);
}
