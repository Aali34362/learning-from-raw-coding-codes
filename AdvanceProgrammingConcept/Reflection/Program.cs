using Reflection;
using System.Reflection;

// Get the type of the class 'Example'
Type type = typeof(Example);

// Create an instance of the class 'Example' using reflection
object instance = Activator.CreateInstance(type)!;

// Set the 'Name' property using reflection
PropertyInfo nameProperty = type.GetProperty("Name")!;
nameProperty!.SetValue(instance, "Reflection Example");

// Invoke the 'PrintName' method using reflection
MethodInfo printMethod = type.GetMethod("PrintName")!;
printMethod!.Invoke(instance, null);

//
ReflectionProgram.ReflectionProgramMain();

String studentName = "Jack";
// get the current type of studentName
Type studentNameType = studentName.GetType();
Console.WriteLine("Type is: " + studentNameType);

// get typeof the Program class and load it to Type variable t     
Type t = typeof(Program);
// get Assembly of variable t using the Assembly property
Console.WriteLine(t.Assembly);

// get typeof Enumerable and load it to Type variable t     
Type t1 = typeof(Enumerable);
// the Type class properties return information about the Enumerable Type 
Console.WriteLine("Name : {0}", t1.Name);
Console.WriteLine("Namespace : {0}", t1.Namespace);
Console.WriteLine("Base Type : {0}", t1.BaseType);

// get typeof String and load it to Type variable t     
Type t2 = typeof(String);
// the Type class properties return information about the String Type 
Console.WriteLine("Name : {0}", t2.Name);
Console.WriteLine("Namespace : {0}", t2.Namespace);
Console.WriteLine("Base Type : {0}", t2.BaseType);

