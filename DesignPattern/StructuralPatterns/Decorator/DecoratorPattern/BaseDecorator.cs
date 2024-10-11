namespace Decorator.DecoratorPattern;

public abstract class BaseDecorator : IDumbData
{
    protected IDumbData data;

    public BaseDecorator(IDumbData data) => this.data = data;

    public virtual int Id { get => data.Id; set => data.Id = value; }
    public virtual string Name { get => data.Name; set => data.Name = value; }
    public virtual string Description { get => data.Description; set => data.Description = value; }
}
