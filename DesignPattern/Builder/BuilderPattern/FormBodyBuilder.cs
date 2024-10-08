using System.Text;

namespace Builder.BuilderPattern;

public class FormBodyBuilder : IKeyValueCollectionBuilder
{
    private StringBuilder _queryStringBuilder = new StringBuilder();

    public IKeyValueCollectionBuilder Add(string key, string value)
    {
        _queryStringBuilder.Append(key);
        _queryStringBuilder.Append('=');
        _queryStringBuilder.Append(value);
        _queryStringBuilder.AppendLine();
        return this;
    }

    public string Build()
    {
        return _queryStringBuilder.ToString();
    }
}