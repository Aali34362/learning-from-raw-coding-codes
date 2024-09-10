<Query Kind="Program">
  <Reference Relative="..\ReflectionWebApp\bin\Debug\net8.0\ReflectionWebApp.dll">F:\Programming\Asp\AspCore\v8\Raw Coding\learning-from-raw-coding-codes\AdvanceProgrammingConcept\ReflectionWebApp\bin\Debug\net8.0\ReflectionWebApp.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
  <IncludeLinqToSql>true</IncludeLinqToSql>
  <DisableMyExtensions>true</DisableMyExtensions>
  <CopyLocal>true</CopyLocal>
  <CreateRuntimesFolder>true</CreateRuntimesFolder>
</Query>

void Main()
{
 var a = 1 + 2 * 3;
 
 Func<int> five =() => { return 5; };
 five().Dump();
 
 Expression<Func<int>> five_exp =() => 5 + 3;
  five_exp.Dump();
  
 string url = "http://example.com/users";
 CreateUrl(url, "name", "age");
 //CreateUrl(url, ???);
}

public string CreateUrl(string url, params string[] fields)
{
    var selectFields = string.Join(",", fields);
    return string.Concat(url, "?fields=",selectFields);
}

//public string CreateUrl(string url, ???)
//{
//    return string.Concat(url, "?fields=", ???);
//}

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}