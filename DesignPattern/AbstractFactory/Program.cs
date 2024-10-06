using AbstractFactory.AbstractFactoryPattern;
using AbstractFactory.geeksforgeeks;

//new NavigationBar(new Apple());
//new DropDownMenu(new Apple());

new NavigationBar();
new AndroidNavigationBar();
new DropDownMenu();
new AndroidDropDownMenu();

CarFactoryClient.CarFactoryClientMain();

