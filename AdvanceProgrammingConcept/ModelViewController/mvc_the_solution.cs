using Dumpify;
using System.Reflection;
using System.Text.Json;
using System.Web;

namespace ModelViewController;

public class mvc_the_solution
{
    public void MVCSolutionMain()
    {
        var container = new MvcContainer();
        //
        var uri = new Uri("http://localhost/home/index?msg=HelloWorld&count=1");
        var result = container.Resolve(uri);
        result.Dump();

        //FromQuery Attribute
        var uriFromQuery = new Uri("http://localhost/home/bindingindex?msg=HelloWorld");
        var resultFromQuery = container.ResolveModelBindingAttribute(uriFromQuery, string.Empty);
        resultFromQuery.Dump();

        //FromBody Attribute
        var uriFromBody = new Uri("http://localhost/home/create");
        var requestBody = "{\"Name\":\"Laptop\",\"Price\":999.99}";
        var resultFromBody = container.ResolveModelBindingAttribute(uriFromBody, requestBody);
        resultFromBody.Dump();

        //Without Model
        var uriTest = new Uri("http://localhost/home/test");
        var resultTest = container.ResolveModelBindingAttribute(uriTest, string.Empty);
        resultTest.Dump();

        //Without Attribute
        var uriTestBind = new Uri("http://localhost/home/testbind?msg=TestBind&count=1");
        var resultTestBind = container.ResolveModelBindingAttribute(uriTestBind, string.Empty);
        resultTestBind.Dump();
    }
}
#region Reflection Code
public class MvcContainer
{
    //Reflection solve the problem by making things Dynamic
    List<Type> controllerTypes = [];
    public MvcContainer()
    {
        //Extracting Controllers which extends Controller
        var controllerType = typeof(Controller);
        controllerTypes = controllerType.Assembly.GetTypes()
            .Where(type => !type.IsAbstract && controllerType.IsAssignableFrom(type)).ToList();
        controllerTypes.Dump("Fetching all existing Controllers in Assembly");
        //controllerTypes.AddRange(controllerTypes);
    }
    public object Resolve(Uri uri)
    {
        var controller = getController(uri);
        controller.Dump("Fetch Controller From URI");
        var action = getAction(controller, uri);
        var parameter = getParameter(action, uri);
        return action.Invoke(controller, parameter)!;
    }
    public object ResolveModelBindingAttribute(Uri uri, string requestBody = null!)
    {
        var controller = getController(uri);
        controller.Dump("Fetch Controller From URI");
        var action = getAction(controller, uri);
        var parameter = getActionParameters(action, uri, requestBody);
        return action.Invoke(controller, parameter)!;
    }
    private Controller getController(Uri uri) =>
              (Controller)Activator.CreateInstance(controllerTypes
                            .FirstOrDefault(x => uri.AbsolutePath
                                .StartsWith($"/{x.Name.Replace("Controller", "")}",
                                    StringComparison.InvariantCultureIgnoreCase)) ?? throw new Exception("Controller not found."), null)!;

    private MethodInfo getAction(Controller controller, Uri uri) => 
        controller.GetType().GetMethods()
        .FirstOrDefault(x => x.Name.Equals(uri.AbsolutePath.Split('/').Last().Dump("Fetching Action Name from Uri Absolute"), 
            StringComparison.InvariantCultureIgnoreCase))! ?? throw new Exception("Action method not found.");
    ////{
    //controller.GetType().DeclaringMethod.Dump();
    ////var action = uri.AbsolutePath.Split('/').Last().Dump("Fetching Action Name from Uri Absolute");
    ////controller
    ////    .GetType()
    ////    .GetMembers()
    ////    .FirstOrDefault(x => x.Name.Equals(uri.AbsolutePath.Split('/').Last().Dump("Fetching Action Name from Uri Absolute"), StringComparison.InvariantCultureIgnoreCase))
    ////    .Dump("Fetching Action Method from Controller Class comparing with Uri Action");

    ////return controller
    ////    .GetType()
    ////    .GetMethods()
    ////    .FirstOrDefault(x => x.Name.Equals(uri.AbsolutePath.Split('/').Last().Dump("Fetching Action Name from Uri Absolute"), StringComparison.InvariantCultureIgnoreCase))! ?? throw new Exception("Action method not found.");
    ////}
    private object[] getParameter(MethodInfo methodInfo, Uri uri)
    {
        var parameterInfos = methodInfo.GetParameters().ToList().Dump("Fetching the parameter of Action");
        if (parameterInfos.Count == 0)
            return null!;

        //parameterInfos.Dump();
        var results = new object[parameterInfos.Count];
        //uri.Query.Dump();
        var query = HttpUtility.ParseQueryString(uri.Query).Dump();
        //query["msg"].Dump();

        for (int i = 0; i < parameterInfos.Count; i++)
        {
            var info = parameterInfos[i].Dump();
            var type = parameterInfos[i].ParameterType.Dump();
            var value = query[info.Name].Dump("value");
            if (type == typeof(string))
                results[i] = value!;
            //if(type == typeof(DateTime)))
            if (type == typeof(Int32))
                results[i] = Int32.Parse(value!);
        }
        return results;
    }
    private object[] getActionParameters(MethodInfo action, Uri uri, string requestBody = null!)
    {
        var parametersInfo = action.GetParameters();
        var parameters = new object[parametersInfo.Length];

        // Parse the query string into a dictionary
        var queryParameters = HttpUtility.ParseQueryString(uri.Query);
        var queryDict = queryParameters.AllKeys.ToDictionary(k => k!, k => queryParameters[k]);

        // For simplicity, assuming route data is part of the URI path
        var pathSegments = uri.AbsolutePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var routeDict = new Dictionary<string, string>();
        if (pathSegments.Length >= 2)
        {
            // Example: /Home/Index -> { "controller": "Home", "action": "Index" }
            routeDict["controller"] = pathSegments[0];
            routeDict["action"] = pathSegments[1];
        }

        for (int i = 0; i < parametersInfo.Length; i++)
        {
            var param = parametersInfo[i];
            var bindingAttribute = param.GetCustomAttribute<BindingSourceAttribute>();

            if (bindingAttribute is FromQueryAttribute)
            {
                if (queryDict.TryGetValue(param.Name!, out var value))
                {
                    parameters[i] = Convert.ChangeType(value, param.ParameterType)!;
                }
                else
                {
                    parameters[i] = GetDefault(param.ParameterType);
                }
            }
            else if (bindingAttribute is FromRouteAttribute)
            {
                if (routeDict.TryGetValue(param.Name!, out var value))
                {
                    parameters[i] = Convert.ChangeType(value, param.ParameterType);
                }
                else
                {
                    parameters[i] = GetDefault(param.ParameterType);
                }
            }
            else if (bindingAttribute is FromBodyAttribute)
            {
                if (!string.IsNullOrEmpty(requestBody))
                {
                    parameters[i] = JsonSerializer.Deserialize(requestBody, param.ParameterType)!;
                }
                else
                {
                    parameters[i] = GetDefault(param.ParameterType);
                }
            }
            else
            {
                // Default binding (e.g., query)
                if (queryDict.TryGetValue(param.Name!, out var value))
                {
                    parameters[i] = Convert.ChangeType(value, param.ParameterType)!;
                }
                else
                {
                    parameters[i] = GetDefault(param.ParameterType);
                }
            }
        }
        return parameters;
    }
    private object GetDefault(Type type)
    {
        if (type.IsValueType)
            return Activator.CreateInstance(type)!;
        return null!;
    }
    //
}
#endregion
#region Models
public class Product
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
}
#endregion
#region Controllers
public abstract class Controller { }
public class HomeController : Controller
{
    public string Index(string msg, int count)
    {
        return $"{msg}: {count}";
        //return "Home Controller";
    }
    public string Test()
    {
        return "Home Controller";
    }
    // Example of binding from query string
    public string BindingIndex([FromQuery] string msg)
    {
        return $"Home Controller received message: {msg}";
    }
    public string Create([FromBody] Product product)
    {
        return $"Product Created: {product.Name}, Price: {product.Price}";
    }
    public string TestBind(string msg, int count)
    {
        return $"Home Controller : {msg} - {count}";
    }
}
public class MasterController : Controller
{
    public string Index()
    {
        return "Master Controller";
    }
}
#endregion
#region Attribute
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
public abstract class BindingSourceAttribute : Attribute { }
public class FromQueryAttribute : BindingSourceAttribute { }
public class FromBodyAttribute : BindingSourceAttribute { }
public class FromRouteAttribute : BindingSourceAttribute { }
#endregion