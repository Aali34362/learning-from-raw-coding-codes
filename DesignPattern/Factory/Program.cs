using Factory.FactoryPattern;
using Factory.geeksforgeeks;
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
