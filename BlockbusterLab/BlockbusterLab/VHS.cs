using System;
using System.Collections.Generic;
using System.Text;

namespace BlockbusterLab
{
    class VHS : Movie
    {
        public int CurrentTime { get; set; }
        public VHS(string Title, string Category, int RunTime, List<String> Scenes) : base(Title, Category, RunTime, Scenes)
        {
            this.Title = Title;
            this.Category = Category;
            this.RunTime = RunTime;
            this.Scenes = Scenes;
            CurrentTime = 0;
        }

        //overridden to play scene at current time and increment current time. 
        public override void Play()
        {
            Console.WriteLine($"\nScene Played:\n{Scenes[CurrentTime]}");
            CurrentTime++; 
            if(CurrentTime >= Scenes.Count)
            {
                Rewind();
            }
        }

        //resets current time to 0 to simulate rewinding movie.
        public void Rewind()
        {
            CurrentTime = 0;
        }
    }
}
