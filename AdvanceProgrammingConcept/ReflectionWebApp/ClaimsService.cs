using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

namespace ReflectionWebApp;

public class ClaimsService
{
    public IEnumerable<string> Claims()
    {
        var authAttr = typeof(AuthorizeAttribute);
        var anonAttr = typeof(AllowAnonymousAttribute);

        return typeof(Program).Assembly.GetTypes()
            .Where(x => x.Name.EndsWith("Controller"))
            .SelectMany(x => x.GetMethods()
                .Where(m => m.DeclaringType!.Equals(x)))
            .Where(x => x.GetCustomAttribute(authAttr) != null
                || x.DeclaringType!.GetCustomAttribute(authAttr) != null)
            .Where(x => x.GetCustomAttribute(anonAttr) == null)
            .Select(x => string.Concat(x.DeclaringType!.ToString(),
                ".", x.ToString()!.Split(" ").Last()));
    }
}
