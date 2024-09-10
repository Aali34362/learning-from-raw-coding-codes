namespace ExpressionTrees;

public static class UrlCreation
{
    public static void UrlCreationMain()
    {
        string url = "http://example.com/users";
        CreateUrl(url, "name", "age");
        ////CreateUrl(url, ???);
    }
    public static string CreateUrl(string url, params string[] fields)
    {
        var selectFields = string.Join(",", fields);
        return string.Concat(url, "?fields=",selectFields);
    }

    ////public static string CreateUrl(string url, ???)
    ////{
    ////    return string.Concat(url, "?fields=", ???);
    ////}
}
