// Expression: (a, b) => a + b
using System.Linq.Expressions;

ParameterExpression paramA = Expression.Parameter(typeof(int), "a");
ParameterExpression paramB = Expression.Parameter(typeof(int), "b");

BinaryExpression body = Expression.Add(paramA, paramB);

// Compile into a delegate
var addFunction = Expression.Lambda<Func<int, int, int>>(body, paramA, paramB).Compile();

// Execute the function
Console.WriteLine(addFunction(10, 20));  // Output: 30
