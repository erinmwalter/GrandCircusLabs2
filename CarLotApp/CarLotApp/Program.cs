using System;

namespace CarLotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Car chosenCar;
            CarLot myLot = new CarLot();
            Console.WriteLine("Welcome to Erin's Car Lot!\n");

            while (true)
            {
                //displays menu gets selection in string form
                DisplayMenu(myLot);
                string choice = GetInput("Make Your Selection: ").Trim().ToLower();
                if (choice == "q")
                {
                    //quit option
                    break;
                }
                else if (choice == "a")
                {
                    //admin login
                    myLot.AdminMode();
                }
                else
                {
                    //sends input to be validated in SelectCar and parsed to int value
                    //then asks if user would like to purchase that vehicle
                    chosenCar = myLot.SelectCar(choice);
                    myLot.PurchaseCar(chosenCar);
                }
            }

            Console.WriteLine("Program Exited. Goodbye!");

        }

        //gets string input from user
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        //displays main menu and all cars in lot
        public static void DisplayMenu(CarLot displayLot)
        {
            Console.WriteLine("Select a Car to Purchase:");
            displayLot.DisplayCars();
            Console.WriteLine("[a] Admin Login.");
            Console.WriteLine("[q] Quit.");
        }
    }
}
