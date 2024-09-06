using Dumpify;
using IEnumerableGenerator;
using IEnumerableGenerator.StackOverFlow;

//
IEnumerableProgram.IEnumerableProgramMain();
//
MySimpleGen simpleGen = new MySimpleGen();
while (simpleGen.HasValue())
{
    var value = simpleGen.Value;
    value.Dump("value");
}
//
var actualGen = new MyActualGen();
foreach (var v in actualGen)
{
    v.Dump("value");
}

//
Person[] peopleArray = new Person[3]
{
    new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
};

People peopleList = new People(peopleArray);
foreach (Person p in peopleList)
    Console.WriteLine(p.firstName + " " + p.lastName);