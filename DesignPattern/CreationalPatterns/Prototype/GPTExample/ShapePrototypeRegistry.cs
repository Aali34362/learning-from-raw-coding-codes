namespace Prototype.GPTExample;

public class ShapePrototypeRegistry
{
    private Dictionary<string, Shape> _shapeRegistry = new Dictionary<string, Shape>();
    
    // Add prototypes to the registry
    public void AddShape(string shapeId, Shape shape) => _shapeRegistry[shapeId] = shape;

    // Retrieve a clone of the registered prototype
    public Shape GetShape(string shapeId)
    {
        if (_shapeRegistry.ContainsKey(shapeId))
        {
            return _shapeRegistry[shapeId].Clone();
        }
        throw new ArgumentException("Shape ID not found in the registry");
    }
}
