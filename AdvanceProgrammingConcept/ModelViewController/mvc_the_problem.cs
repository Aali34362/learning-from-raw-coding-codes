using Dumpify;

namespace ModelViewController;

public static class mvc_the_problem
{
    public static void MVCProblemMain()
    {
        var uri = new Uri("http://localhost/home/index");
        uri.AbsolutePath.Dump();
        uri.AbsolutePath.Split("/").Skip(1).Dump();
        if (uri.AbsolutePath.StartsWith("/home/index"))
        {
            //execute some logic
        }
    }    
}
