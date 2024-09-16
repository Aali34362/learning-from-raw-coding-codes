// Expression: (a, b) => a + b
using Dumpify;
using ExpressionTrees;
using System.Linq.Expressions;

ParameterExpression paramA = Expression.Parameter(typeof(int), "a");
ParameterExpression paramB = Expression.Parameter(typeof(int), "b");

BinaryExpression body = Expression.Add(paramA, paramB);

// Compile into a delegate
var addFunction = Expression.Lambda<Func<int, int, int>>(body, paramA, paramB).Compile();

// Execute the function
Console.WriteLine(addFunction(10, 20));  // Output: 30

var user = new User();
Expression<Func<User, object>> expressionName = user => user.Name!;
var nameBody = expressionName.Body.Dump();
Expression<Func<User, object>> expressionAge = user => user.Age!;
var ageBody = expressionAge.Body.Dump();
if (nameBody is MemberExpression me)
{
    me.Member.Name.ToLower().Dump();
}

if (ageBody is UnaryExpression ue)
{
    ((MemberExpression)ue.Operand).Member.Name.ToLower().Dump();
}


UrlCreation.UrlCreationMain();