<Query Kind="Program">
  <Reference Relative="..\ReflectionWebApp\bin\Debug\net8.0\ReflectionWebApp.dll">F:\Programming\Asp\AspCore\v8\Raw Coding\learning-from-raw-coding-codes\AdvanceProgrammingConcept\ReflectionWebApp\bin\Debug\net8.0\ReflectionWebApp.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
  <IncludeLinqToSql>true</IncludeLinqToSql>
  <DisableMyExtensions>true</DisableMyExtensions>
  <CopyLocal>true</CopyLocal>
  <CreateRuntimesFolder>true</CreateRuntimesFolder>
</Query>

//Code is Data too. Extract Data from Code or Work with Code for data manipulation is Different
void Main()
{
 var a = 1 + 2 * 3;
//
 Func<int> five =() => { return 5; };
 five().Dump();
//
 Expression<Func<int>> five_exp =() => 5 + 3;
  five_exp.Dump();
//
 string url = "http://example.com/users";
 CreateUrl(url, "name", "age");
 CreateUrl(url, u => u.Name!, u => u.Age).Dump("2");
//
 var user = new User();
Expression<Func<User, object>> expressionName = user => user.Name!;
var nameBody = expressionName.Body.Dump();
Expression<Func<User, object>> expressionAge = user => user.Age!;
var ageBody = expressionAge.Body.Dump();
if(nameBody is MemberExpression me)
{
	me.Member.Name.ToLower().Dump();
}
if(ageBody is UnaryExpression ue)
{
	((MemberExpression)ue.Operand).Member.Name.ToLower().Dump();
}
//
var selectProperty = "number";
var someClass = new SomeClass()
{
    Word = "Hello World",
    Number = 1234
};
if (selectProperty == "number")
{
    someClass.Number.Dump();
}
else if (selectProperty == "word")
{
    someClass.Word.Dump();
}

}

private string CreateUrl(string url, params string[] fields)
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

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class SomeClass
{
    public string Word { get; set; }
    public int Number { get; set; }
}