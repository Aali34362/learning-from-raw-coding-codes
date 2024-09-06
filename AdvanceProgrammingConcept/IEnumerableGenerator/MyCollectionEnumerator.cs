using System.Collections;

namespace IEnumerableGenerator;

internal class MyCollectionEnumerator : IEnumerator<int>
{
    private int[] numbers = { 1, 2, 3, 4, 5 };
    private int position = -1;
    public bool MoveNext()
    {
        position++;
        return (position < numbers.Length);
    }
    public int Current
    {
        get
        {
            if (position < 0 || position >= numbers.Length)
                throw new InvalidOperationException();
            return numbers[position];
        }
    }
    object IEnumerator.Current => Current;
    public void Reset() => position = -1;
    public void Dispose() { }
}
