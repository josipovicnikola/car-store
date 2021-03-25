using CarClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Store s = new Store();
            string welcomeMessage = "Welcome!";
            Console.WriteLine(welcomeMessage);

            int action = chooseAction();

            while (action != 0)
            {
                Console.WriteLine("You choose an action " + action);
                switch (action)
                {
                    case 1:
                        Console.WriteLine("You choose to add a  new car to the inventory");
                        string carMake = "";
                        string carModel = "";
                        decimal carPrice = 0.00M;

                        Console.WriteLine("What is the car make? ford, gm, nissan etc.");
                        carMake = Console.ReadLine();

                        Console.WriteLine("What is the car model? corvette, focus, ranger etc.");
                        carModel = Console.ReadLine();

                        Console.WriteLine("What is the car price?");
                        carPrice = decimal.Parse(Console.ReadLine());

                        Car newCar = new Car(carMake, carModel, carPrice);

                        s.CarList.Add(newCar);

                        printInventory(s);

                        break;
                    case 2:
                        Console.WriteLine("You choose to add a car to your shopping cart");
                        printInventory(s);
                        Console.WriteLine("Which item would you like to buy? (number)");
                        int carChosen = int.Parse(Console.ReadLine());

                        s.ShoppingList.Add(s.CarList[carChosen]);
                        printShoppingCart(s);
                        break;
                    case 3:
                        printShoppingCart(s);
                        Console.WriteLine("The total cost of your items is : " + s.Checkout());
                        break;
                    default:
                        break;
                }
                action = chooseAction();
            }
        }

        private static void printShoppingCart(Store s)
        {
            Console.WriteLine("Cars you have chosen to buy");
            for (int i = 0; i < s.ShoppingList.Count; i++)
            {
                Console.WriteLine("Car: #" + i + " " + s.ShoppingList[i]);
            }
        }

        private static void printInventory(Store s)
        {
            for(int i=0;i<s.CarList.Count; i++)
            {
                Console.WriteLine("Car: #" + i + " " + s.CarList[i]);
            }
        }

        static public int chooseAction()
        {
            int choice = 0;
            Console.WriteLine("Choose an action \n(0) to quit \n(1) to add a new car to inventory \n(2) add car to cart \n(3) checkout ");

            choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}
