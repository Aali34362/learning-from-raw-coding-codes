namespace Prototype.GPTExample;

public static class GPTExampleProgram
{
    public static void GPTExampleMain()
    {
        // Create an instance of the ShapePrototypeRegistry
        var shapeRegistry = new ShapePrototypeRegistry();

        // Create and add shapes to the registry
        var circle = new Circle { Id = "1", Radius = 10 };
        var rectangle = new Rectangle { Id = "2", Width = 20, Height = 30 };

        shapeRegistry.AddShape(circle.Id, circle);
        shapeRegistry.AddShape(rectangle.Id, rectangle);

        // Clone the shapes from the registry
        var clonedCircle = shapeRegistry.GetShape("1");
        var clonedRectangle = shapeRegistry.GetShape("2");

        // Print the original and cloned shapes
        Console.WriteLine("Original Circle: " + circle);
        Console.WriteLine("Cloned Circle: " + clonedCircle);

        Console.WriteLine("\nOriginal Rectangle: " + rectangle);
        Console.WriteLine("Cloned Rectangle: " + clonedRectangle);

        // Modify the cloned circle's radius
        var anotherClonedCircle = (Circle)clonedCircle.Clone();
        anotherClonedCircle.Radius = 15;
        anotherClonedCircle.Id = "3"; // Assign a new ID for the modified clone

        Console.WriteLine("\nAnother Cloned Circle with Modified Radius: " + anotherClonedCircle);

    }
}
