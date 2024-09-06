using System.Collections;

namespace IEnumerableGenerator.StackOverFlow;

// Collection of Person objects. This class
// implements IEnumerable so that it can be used
// with ForEach syntax.
public class People : IEnumerable
{
    private Person[] _people;
    public People(Person[] pArray)
    {
        _people = new Person[pArray.Length];

        for (int i = 0; i < pArray.Length; i++)
        {
            _people[i] = pArray[i];
        }
    }
    // Implementation for the GetEnumerator method.
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    public PeopleEnum GetEnumerator()
    {
        return new PeopleEnum(_people);
    }
}
