using System;

namespace CarLotApp
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        //base constructor with default values
        public Car()
        {
            Make = "None";
            Model = "None";
            Year = 1900;
            Price = 0.00;
        }

        //overloaded constructor
        public Car(string Make, string Model, int Year, double Price)
        {
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.Price = Price;
        }

        //displays car 
        public override string ToString()
        {
            return $"{Year,-4} {Make,-10} {Model,-10} ${Price,9}";
        }

        //displays a edit menu to ask what the user would like to update about the car
        public void EditCarMenu()
        {
            Console.WriteLine("What would you like to update?");
            Console.WriteLine("[1]Year  [2]Make  [3]Model [4]Price [5]Mileage");
            string choice = GetInput("Make your Selection: ");
            MakeEdit(choice);

        }

        //general get input method to get input in string form from user
        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        //allows the admin to edit attributes of the cars
        public virtual void MakeEdit(string choice)
        {
            if (choice == "1")
            {
                Year = int.Parse(GetInput("Enter New Year: "));
                Console.WriteLine("Year Updated.");
            }
            if (choice == "2")
            {
                Make = GetInput("Enter new Make: ");
                Console.WriteLine("Make Updated.");
            }
            if (choice == "3")
            {
                Model = GetInput("Enter new Model: ");
                Console.WriteLine("Model Updated.");
            }
            if (choice == "4")
            {
                Price = double.Parse(GetInput("Enter New Price: "));
                Console.WriteLine("Price Updated.");
            }
        }

    }
}
