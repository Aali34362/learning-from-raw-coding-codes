using Dumpify;
using System.Reflection;

namespace ModelViewController;

public class mvc_the_solution
{
    public void MVCSolutionMain()
    {
        var uri = new Uri("http://localhost/home/index?msg=HelloWorld");
        var container = new MvcContainer();
        var result = container.Resolve(uri);
        result.Dump();
    }
}

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
        return action.Invoke(controller, null)!;
    }
    private Controller getController(Uri uri)
    {
        var controllerType = controllerTypes
                            .FirstOrDefault(x => uri.AbsolutePath
                                .StartsWith($"/{x.Name.Replace("Controller","")}", 
                                    StringComparison.InvariantCultureIgnoreCase));
        return (Controller)Activator.CreateInstance(controllerType!, null)!;
    }
    private MethodInfo getAction(Controller controller, Uri uri)
    {
        //controller.GetType().DeclaringMethod.Dump();
        var action = uri.AbsolutePath.Split('/').Last().Dump("Fetching Action Name from Uri Absolute");
        controller
            .GetType()
            .GetMembers()
            .FirstOrDefault(x => x.Name.Equals(action, StringComparison.InvariantCultureIgnoreCase))
            .Dump("Fetching Action Method from Controller Class comparing with Uri Action");

        return controller
            .GetType()
            .GetMethods()
            .FirstOrDefault(x => x.Name.Equals(action, StringComparison.InvariantCultureIgnoreCase))!;
    }
    //
}

public abstract class Controller { }
public class HomeController : Controller 
{
    public string Index()
    {
        return "Home Controller";
    }
    public string Test()
    {
        return "Home Controller";
    }
}
public class MasterController : Controller
{
    public string Index()
    {
        return "Master Controller";
    }
}
