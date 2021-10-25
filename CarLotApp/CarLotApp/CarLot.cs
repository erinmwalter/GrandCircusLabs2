using System;
using System.Collections.Generic;
using System.Text;

namespace CarLotApp
{
    class CarLot
    {
        public List<Car> CarsList {get;set;} = new List<Car>();

        //admin password
        private string password = "admin@2021$";

        //adds 6 default cars when initialized
        public CarLot()
        {
            CarsList.Add(new Car("Ford", "Explorer", 2021, 65000.75));
            CarsList.Add(new Car("GMC", "Traverse", 2022, 55000.25));
            CarsList.Add(new Car("Chevrolet", "Malibu", 2021, 31999.99));
            CarsList.Add(new UsedCar("Jeep", "Wrangler", 2015, 15000.99, 60000.50));
            CarsList.Add(new UsedCar("Kia", "Telluride", 2018, 17599.99, 35000.99));
            CarsList.Add(new UsedCar("Toyota", "Camry", 2010, 8199.99, 71999.99));
        }

        //displays all cars in car lot
        public void DisplayCars()
        {
            for(int i = 0; i <CarsList.Count; i++)
            {
                Console.WriteLine($"{i+1}: {CarsList[i]}");
            }
        }

        //this is input validation
        //as well as returns a car once input is parsed to int successfully and validated
        public Car SelectCar(string choice)
        {
            Car selectedCar = new Car();
            while(true) 
            {
                try
                {
                    int validChoice = int.Parse(choice);
                    selectedCar = CarsList[validChoice-1];
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Invalid Car Choice, must be between 1 and {CarsList.Count}. Try Again.");
                    choice = Program.GetInput("Enter New Choice: ");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Invalid entry, please enter 1 - {CarsList.Count}, q, or a. Try Again.");
                    choice = Program.GetInput("Enter New Choice: ");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Invalid entry, please enter 1 - {CarsList.Count}, q, or a. Try Again.");
                    choice = Program.GetInput("Enter New Choice: ");
                    continue;
                }
            }
            Console.WriteLine($"You have selected {selectedCar}");
            return selectedCar;
        }

        //removes a car from the car list
        public void RemoveCar()
        {
            DisplayCars();
            Console.Write("Which car to remove?");
            int carToRemove = int.Parse(Console.ReadLine());

            CarsList.Remove(CarsList[carToRemove-1]);
        }

        //asks user if they would like to purchase the car they chose.
        public void PurchaseCar(Car chosenCar)
        {
            bool purchaseCar = Continue("Would you like to purchase this car? ");
            if (purchaseCar)
            {
                Console.WriteLine($"Purchased {chosenCar.Year} {chosenCar.Make} {chosenCar.Model} for ${chosenCar.Price}");
                CarsList.Remove(chosenCar);
            }
            else
            {
                Console.WriteLine("Car not purchased, returning to main menu...");
            }
        }

        //bool asking if user would like to continue/if would like to purchase car.
        public bool Continue(string prompt)
        {
            Console.Write(prompt);
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice == "y")
            {
                return true;
            }
            else if (choice == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid entry, type y or n. Try Again.");
                return Continue(prompt);
            }
        }

        //method to add new or used car
        public void AddCar()
        {
            bool isNew = Continue("Is this a new car? (y/n): ");
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Make: ");
            string make = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine());
            if (isNew)
            {
                CarsList.Add(new Car(make, model, year, price));
            }
            else
            {
                Console.Write("Mileage: ");
                double mileage = double.Parse(Console.ReadLine());
                CarsList.Add(new UsedCar(make, model, year, price, mileage));
            }
        }


        //if password is correct will be unlocked and give admin ability
        //to add, remove, or edit existing cars. 
        public void AdminMode()
        {
            Console.WriteLine("Enter Password: ");
            string login = Console.ReadLine();
            if (login == password)
            {
                Console.WriteLine("Welcome Admin.");
                while (true)
                {
                    string choice = GetAdminChoice();
                    if (choice == "1")
                    {
                        AddCar();
                    }
                    else if (choice == "2")
                    {
                        RemoveCar();
                    }
                    else if (choice == "3")
                    {
                        DisplayCars();
                        Console.Write("Choose a car: ");
                        string chosenCar = Console.ReadLine();
                        Car carToEdit = SelectCar(chosenCar);
                        carToEdit.EditCarMenu();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("I'm sorry, invalid password. Returning to main menu.");
            }
        }

        //Admin menu choice
        private string GetAdminChoice()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add Car");
            Console.WriteLine("2. Remove Car");
            Console.WriteLine("3. Edit Existing Car");
            Console.WriteLine("4. Exit to Main Menu");
            Console.Write("Make your selection: ");
            return Console.ReadLine();
        }
    }
}
