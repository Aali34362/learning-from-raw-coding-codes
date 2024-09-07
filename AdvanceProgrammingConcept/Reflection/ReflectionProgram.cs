using Dumpify;

namespace Reflection;

public static class ReflectionProgram
{
    public static void ReflectionProgramMain()
    {
        "Hello World".Dump();
        
        "Hello World Split".Split(" ").Dump();
        
        "{ \"prop\" : \"Hello World Json\" }".Dump();
        
        string json = "{ \"prop\" : \"Hello World Json\" }";
        A obj = System.Text.Json.JsonSerializer.Deserialize<A>(json)!;
        obj.Dump();
        obj.prop.Dump();
        
        //
        "public class A { public string? prop { get; set; } }".Dump();

        

    }
}

public class A
{
    public string? prop { get; set; }
}