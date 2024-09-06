using System.Collections;

namespace IEnumerableGenerator.StackOverFlow;

public class PeopleEnum(Person[] list) : IEnumerator
{
    public Person[] _people = list;
    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;
    public bool MoveNext()
    {
        position++;
        return (position < _people.Length);
    }
    public void Reset() => position = -1;
    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }
    public Person Current
    {
        get
        {
            try
            {
                return _people[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
