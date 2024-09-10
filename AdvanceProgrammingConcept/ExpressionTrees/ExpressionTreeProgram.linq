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
}