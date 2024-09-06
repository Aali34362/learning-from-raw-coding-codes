using Dumpify;

namespace IEnumerableGenerator;

public class MySimpleGen
{
    public int _value = 1;
    public int Value => _value;
    public static void MySimpleGenMain()
    {
        
    }
    public bool HasValue()
    {
        _value.Dump();
        if (_value > 2)
            return false;
        return true;
    }
}
