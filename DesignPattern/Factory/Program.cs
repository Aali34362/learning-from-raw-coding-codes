using Factory.FactoryPattern;
using Factory.geeksforgeeks.ProblemOriented;
using Factory.RefactoringGuru;

new NavigationBar();
new DropDownMenu();

new Client().Main();


ClientBuyer pClient = new ClientBuyer(1);
Vehicle pVehicle = pClient.getVehicle();
if (pVehicle != null)
{
    pVehicle.printVehicle();
}
pClient.cleanup();

/*
What are the problems with the above design? 
In the above code design:
Tight Coupling: The client class Client directly instantiates the concrete classes (TwoWheeler and FourWheeler) based on the input type provided during its construction. This leads to tight coupling between the client and the concrete classes, making the code difficult to maintain and extend.
Violation of Single Responsibility Principle (SRP): The Client class is responsible not only for determining which type of vehicle to instantiate based on the input type but also for managing the lifecycle of the vehicle object (e.g., cleanup). This violates the Single Responsibility Principle, which states that a class should have only one reason to change.
Limited Scalability: Adding a new type of vehicle requires modifying the Client class, which violates the Open-Closed Principle. This design is not scalable because it cannot accommodate new types of vehicles without modifying existing code.

How do we avoid the problem?
Define Factory Interface: Create a VehicleFactory interface or abstract class with a method for creating vehicles.
Implement Concrete Factories: Implement concrete factory classes (TwoWheelerFactory and FourWheelerFactory) that implement the VehicleFactory interface and provide methods to create instances of specific types of vehicles.
Refactor Client: Modify the Client class to accept a VehicleFactory instance instead of directly instantiating vehicles. The client will request a vehicle from the factory, eliminating the need for conditional logic based on vehicle types.
Enhanced Flexibility: With this approach, adding new types of vehicles is as simple as creating a new factory class for the new vehicle type without modifying existing client code.
 */
