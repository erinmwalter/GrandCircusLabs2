using System;
using System.Collections.Generic;
using System.Text;

namespace CarLotApp
{
    class UsedCar : Car
    {
        public double Mileage { get; set; }

        //base constructor with default values
        public UsedCar()
        {
            this.Make = "None";
            this.Model = "None";
            this.Year = 1900;
            this.Price = 0.00;
            this.Mileage = 100000;
        }

        //overloaded constructor
        public UsedCar(string Make, string Model, int Year, double Price, double Mileage) : base(Make, Model, Year, Price)
        {
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.Price = Price;
            this.Mileage = Mileage;
        }

        //overridden to string with mileage added in for used car
        public override string ToString()
        {
            return base.ToString() + $" Mileage: {Mileage,9} (used)";
        }

        //overridden make edit menu with option added in to edit mileage
        public override void MakeEdit(string choice)
        {
            base.MakeEdit(choice);
            if (choice == "5")
            {
                Mileage = double.Parse(GetInput("Enter New Mileage: "));
                Console.WriteLine("Mileage Updated.");
            }
        }
    }
}
