using System;
using System.Collections.Generic;
using System.Text;

namespace BlockbusterLab
{
    class DVD : Movie
    {
        public DVD(string Title, string Category, int RunTime, List<String> Scenes) : base(Title, Category, RunTime, Scenes)
        {
            this.Title = Title;
            this.Category = Category;
            this.RunTime = RunTime;
            this.Scenes = Scenes;
        }

        //asks user which scene they would like to play and plays it, also validates user input
        public override void Play()
        {
            bool goodInput = false;
            Console.WriteLine($"\nScenes in {Title}");
            for (int i = 0; i < Scenes.Count; i++)
            {
                Console.WriteLine($"{i}: {Scenes[i]}");
            }
            while (!goodInput)
            {
                
                try
                {
                    int answer = int.Parse(GetInput("Choose a Scene: "));
                    Console.WriteLine($"\nPlaying Scene: \n{Scenes[answer]}");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid selection, must be an integer value.");
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Invalid Choice. Must be between 0 and {Scenes.Count - 1}");
                    continue;
                }
            }
        }
    }
}
