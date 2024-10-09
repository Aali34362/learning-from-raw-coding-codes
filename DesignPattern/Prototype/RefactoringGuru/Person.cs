using System.Runtime;

namespace Prototype.RefactoringGuru;

public class Person
{
    public int Age;
    public DateTime BirthDate;
    public string? Name;
    public IdInfo? IdInfo;

    public Person DeepCopy()
    {
        Person clone = (Person)this.MemberwiseClone();
        clone.Age = this.Age;
        clone.BirthDate = this.BirthDate;
        clone.Name = this.Name;

        return clone;
    }

    public Person ShallowCopy()
    {
        return (Person)this.MemberwiseClone();
    }
}
