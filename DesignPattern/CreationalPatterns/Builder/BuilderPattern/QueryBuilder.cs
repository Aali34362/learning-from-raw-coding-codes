using System.Text;

namespace Builder.BuilderPattern;

internal class QueryBuilder : IKeyValueCollectionBuilder
{
    private StringBuilder _queryStringBuilder = new StringBuilder();

    public IKeyValueCollectionBuilder Add(string key, string value)
    {
        _queryStringBuilder.Append(_queryStringBuilder.Length == 0 ? "?" : "&");
        _queryStringBuilder.Append(key);
        _queryStringBuilder.Append('=');
        _queryStringBuilder.Append(Uri.EscapeDataString(value));
        return this;
    }

    public string Build()
    {
        return _queryStringBuilder.ToString();
    }
}
