using Dumpify;
using System.Collections;

namespace IEnumerableGenerator;

public class MyActualGen : IEnumerable<int>, IEnumerator<int>
{
    int _value = 1;
    public int Current => _value++;
    object IEnumerator.Current => Current;
    public void Dispose() { }
    public IEnumerator<int> GetEnumerator() => this;
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();    
    public bool MoveNext()
    {
        _value.Dump();
        if (_value > 2)
            return false;
        return true;
    }
    public void Reset() => _value = 1;
}
