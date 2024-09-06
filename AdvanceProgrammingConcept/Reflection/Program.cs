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
