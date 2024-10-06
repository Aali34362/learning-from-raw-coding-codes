using AbstractFactory.AbstractFactoryPattern;
using AbstractFactory.geeksforgeeks;
using AbstractFactory.RefactoringGuru;


new NavigationBar(new Apple());
new DropDownMenu(new Apple());

new NavigationBarFactoryMethod();
new AndroidNavigationBar();
new DropDownMenuFactoryMethod();
new AndroidDropDownMenu();

CarFactoryClient.CarFactoryClientMain();

ClientAbstractFactoryProgram.ClientProgramMain();