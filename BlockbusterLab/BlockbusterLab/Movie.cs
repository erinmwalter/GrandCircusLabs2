using System;
using System.Collections.Generic;
using System.Text;

namespace BlockbusterLab
{
    class Movie
    {
        //this class is parent class/object that stores Title/Genre/RunTime/Scenes of movies

        public string Title { get; set; }
        public string Category { get; set; }
        public int RunTime { get; set; }
        public List<String> Scenes { get; set; }

        public Movie(string Title, string Category, int RunTime, List<String> Scenes) 
        {
            this.Title = Title;
            this.Category = Category;
            this.RunTime = RunTime;
            this.Scenes = Scenes;
        }

        //override of to string to format objects output
        public override string ToString()
        {
            return $"{Title}\nGenre: {Category}, Run Time: {RunTime} minutes";
        }

        public virtual void Play()
        {
            //just threw a CW in here to test to see if it was firing initially
            //this will be overridden in the child classes though so should not be called 
            //directly, the overridden classes should be called.
            Console.WriteLine("Play Method--To Be Overridden");
        }

        //gets user input
        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }



    }
}
