using Dumpify;
using System.Linq.Expressions;

namespace ExpressionTrees;

public static class UrlCreation
{
    public static void UrlCreationMain()
    {
        string url = "http://example.com/users";
        CreateUrl(url, "name", "age").Dump("1");
        CreateUrl(url, u => u.Name!, u => u.Age).Dump("2");
    }
    private static string CreateUrl(string url, params string[] fields)
    {
        var selectFields = string.Join(",", fields);
        return string.Concat(url, "?fields=",selectFields);
    }

    private static string CreateUrl(string url, params Expression<Func<User, object>>[] fieldSelectors)
    {
        var fields = new List<string>();
        foreach(var selector in fieldSelectors)
        {
            var body = selector.Body.Dump();
            if (body is MemberExpression me)
            {
                fields.Add(me.Member.Name.ToLower());
                me.Member.Name.ToLower().Dump();
            } else if (body is UnaryExpression ue)
            {
                fields.Add(((MemberExpression)ue.Operand).Member.Name.ToLower());
                ((MemberExpression)ue.Operand).Member.Name.ToLower().Dump();
            }
        }
        var selectedFields = string.Join(',', fields);
        return string.Concat(url, "?fields=", selectedFields);
    }
}
