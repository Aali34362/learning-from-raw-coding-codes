<Query Kind="Program">
  <Reference Relative="..\ReflectionWebApp\bin\Debug\net8.0\ReflectionWebApp.dll">F:\Programming\Asp\AspCore\v8\Raw Coding\learning-from-raw-coding-codes\AdvanceProgrammingConcept\ReflectionWebApp\bin\Debug\net8.0\ReflectionWebApp.dll</Reference>
  <Namespace>Microsoft.AspNetCore.Authorization</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
  <IncludeLinqToSql>true</IncludeLinqToSql>
  <DisableMyExtensions>true</DisableMyExtensions>
  <CopyLocal>true</CopyLocal>
  <CreateRuntimesFolder>true</CreateRuntimesFolder>
</Query>

using Microsoft.AspNetCore.Authorization;
using System.Reflection;
void Main()
{
	//
	var program = new Program();
	program.Dump();
	program.GetType().Dump();
	program.GetType().GetType().Dump();
	//
	typeof(Program).Assembly.GetTypes()
		.Where(x=> x.Name.EndsWith("Controller"))		
		.Dump();
	//
	typeof(Program).Assembly.GetTypes()
		.Where(x=> x.Name.EndsWith("Controller"))
		.Select(x=> x.GetMethods())
		.Dump();
	//	
	typeof(Program).Assembly.GetTypes()
	.Where(x=> x.Name.EndsWith("Controller"))
	.Select(x=> x.GetMethods().Where(m=>m.DeclaringType.Equals(x)))
	.Dump();
	//
	var authAttr = typeof(AuthorizeAttribute);
	typeof(Program).Assembly.GetTypes()
	.Where(c=> c.Name.EndsWith("Controller"))
	.SelectMany(x=> x.GetMethods()
		.Where(m=>m.DeclaringType.Equals(x)))
	.Where(a=> a.GetCustomAttribute(authAttr) != null)
	.Dump();
	//
	typeof(Program).Assembly.GetTypes()
	.Where(c=> c.Name.EndsWith("Controller"))
	.SelectMany(x=> x.GetMethods()
		.Where(m=>m.DeclaringType.Equals(x)))
	.Where(a=> a.GetCustomAttribute(authAttr) != null
	|| a.DeclaringType.GetCustomAttribute(authAttr)!= null)
	.Dump();
	//
	var anonAttr = typeof(AllowAnonymousAttribute);
	typeof(Program).Assembly.GetTypes()
	.Where(c=> c.Name.EndsWith("Controller"))
	.SelectMany(x=> x.GetMethods()
		.Where(m=>m.DeclaringType.Equals(x)))
	.Where(a=> a.GetCustomAttribute(authAttr) != null
	|| a.DeclaringType.GetCustomAttribute(authAttr)!= null)
	.Where(x=> x.GetCustomAttribute(anonAttr) == null)
	.Dump();
	//	
	typeof(Program).Assembly.GetTypes()
	.Where(c=> c.Name.EndsWith("Controller"))
	.SelectMany(x=> x.GetMethods()
		.Where(m=>m.DeclaringType.Equals(x)))
	.Where(a=> a.GetCustomAttribute(authAttr) != null
	|| a.DeclaringType.GetCustomAttribute(authAttr)!= null)
	.Where(x=> x.GetCustomAttribute(anonAttr) == null)
	.Select(x=> x.Dump().ToString())
	.Dump();
	//	
	typeof(Program).Assembly.GetTypes()
	.Where(c=> c.Name.EndsWith("Controller"))
	.SelectMany(x=> x.GetMethods()
		.Where(m=>m.DeclaringType.Equals(x)))
	.Where(a=> a.GetCustomAttribute(authAttr) != null
	|| a.DeclaringType.GetCustomAttribute(authAttr)!= null)
	.Where(x=> x.GetCustomAttribute(anonAttr) == null)
	.Select(x=> string.Concat(x.DeclaringType.ToString(),".", x.ToString().Split(" ").Last()))
	.Dump();
	//
	
	
}

// You can define other methods, fields, classes and namespaces here
