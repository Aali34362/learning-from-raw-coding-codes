using Dumpify;
using IEnumerableGenerator;

IEnumerableProgram.IEnumerableProgramMain();

MySimpleGen simpleGen = new MySimpleGen();
while (simpleGen.HasValue())
{
    var value = simpleGen.Value;
    value.Dump("value");
}