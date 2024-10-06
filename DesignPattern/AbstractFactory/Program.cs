using AbstractFactory.AbstractFactoryPattern;
using AbstractFactory.geeksforgeeks;
using AbstractFactory.RefactoringGuru;

//new NavigationBar(new Apple());
//new DropDownMenu(new Apple());

new NavigationBar();
new AndroidNavigationBar();
new DropDownMenu();
new AndroidDropDownMenu();

CarFactoryClient.CarFactoryClientMain();

ClientAbstractFactoryProgram.ClientProgramMain();