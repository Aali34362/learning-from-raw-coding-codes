using Dumpify;
using IEnumerableGenerator;

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