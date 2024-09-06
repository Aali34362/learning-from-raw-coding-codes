using Dumpify;

namespace ModelViewController;

public class mvc_the_solution
{
    public void MVCSolutionMain()
    {
        var uri = new Uri("http://localhost/home/index");
        var container = new MvcContainer();
        container.Resolve(uri);
    }
}

public class MvcContainer
{
    List<Type> controllerTypes = [];
    public MvcContainer()
    {
        //Extracting Controllers which extends Controller
        var controllerType = typeof(Controller);
        var controllerTypes = controllerType.Assembly.GetTypes()
            .Where(type => !type.IsAbstract && controllerType.IsAssignableFrom(type)).ToList();
        controllerTypes.Dump();
        controllerTypes.AddRange(controllerTypes);
    }
    public object Resolve(Uri uri)
    {
        var controller = getController(uri);
        return null;
    }
    public Controller getController(Uri uri)
    {
        return null;
    }
}

public abstract class Controller { }
public class HomeController : Controller 
{
    public string Index()
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
