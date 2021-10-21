using System;
using System.Collections.Generic;

namespace BlockbusterLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockbuster myBlockbuster = new Blockbuster();
            Movie myMovie;
            bool runAgain = true;

            Console.WriteLine("Welcome to the GC BlockBuster App!\n");
            while (runAgain)
            {
                
                myMovie = myBlockbuster.CheckOut();
                bool watchMovie = Continue("Do you want to watch this movie? (y/n): ");
                if (watchMovie)
                {
                    myMovie.Play();
                }
                runAgain = Continue("Do you want to watch another movie? (y/n): ");
            }
            Console.WriteLine("Program Exiting. Goodbye!");
        }

        //prompts user if they would like to run again/continue/do something and returns bool based on input
        public static bool Continue(string prompt)
        {
            Console.Write(prompt);
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false; 
            }
            else
            {
                Console.WriteLine("I'm sorry, I didn't understand, try again.");
                return Continue(prompt);
            }
        }
    }
}
