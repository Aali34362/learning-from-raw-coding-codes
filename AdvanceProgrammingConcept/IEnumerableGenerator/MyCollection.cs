using System.Collections;

namespace IEnumerableGenerator;

public class MyCollection : IEnumerable<int>
{
    private int[] numbers = { 1, 2, 3, 4, 5 };

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            yield return numbers[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() // Non-generic implementation
    {
        return GetEnumerator();
    }
}
