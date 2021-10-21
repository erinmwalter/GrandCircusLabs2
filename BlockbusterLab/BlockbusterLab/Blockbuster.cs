using System;
using System.Collections.Generic;
using System.Text;

namespace BlockbusterLab
{
    class Blockbuster
    {
        public List<Movie> movieList = new List<Movie>();
        public List<string> Genre = new List<string>() { "Drama", "Comedy", "Horror", "Romance", "Action" };

        //initializes a list of 6 movies-3 DVD and 3VHS with titles, cagetories, run times, and a scene list.
        public Blockbuster()
        {
            List<string> scenes = new List<string>() { "Harry and Ron Skip and Sing Down the Great Hall",
                "Neville's Frog Escapes and They Chase it Through The Common Room",
                "Draco's Spell Backfires and He's covered in warts",
                "Voldemort Chases Harry and Trips on his Cloak and Falls",
                "Everyone Cheers, Harry saved the day, they fly around the grounds, Ron's broom breaks in half" };
            movieList.Add(new DVD("Harry Potter: The Funny One", "Comedy", 180, scenes));

            List<string> scenes2 = new List<string>() {"Harry feels someone following him on his way to Diagon Alley",
                "Sinister music plays as Hermione runs back to the Gryffindor Common Room",
                "A Ghoul Jumps out of an empty classroom and lunges at Ron, Harry, and Hermione",
                "Harry and Ron hide under their beds while a Dementor searches their dormitory",
                "Voldemort Cackles in the distance. He won this round."};
            movieList.Add(new DVD("Harry Potter: The Spooky One", "Horror", 230, scenes2));

            List<string> scenes3 = new List<string>() { "Ron gets jealous of Harry and Hermione because they seem a little too buddy-buddy on the couch in the common room",
                "Harry has his eyes set on Cho Chang, but shoots his shot and gets turned down after asking her to the ball",
                "Harry decides to settle for Ginny. Ron is big mad",
                "Ron realizes that he was only jealous of Harry because of his deep love for Hermione",
                "Ron comes to accept Harry and Ginny's Relationship and welcomes Harry into the family"};
            movieList.Add(new DVD("Harry Potter: The Love-Scene One", "Romance", 200, scenes3));

            List<string> scenes4 = new List<string>() {"A tournament is coming to Hogwarts, so dangerous it hasn't been held in over a century",
                "Jarry 'doesn't enter' but somehow gets picked as a participant in the tournament despite not being eliglbe. The professors just say 'yeah whatever, sounds good' and let him participate",
                "Harry is vastly underprepared but manages to skate through each challenge because he just some how manages to get the exact bit of help he needs at the exact moment he needs it",
                "The last challenge is a large maze and plot twist, the trophy is a portkey that zaps Harry and his friend Cedric away from Hogwarts",
                "Harry is tied up and Voldemort re-materializes in the flesh, pale and snake-looking",
                "Harry runs to tell everyone and they just brush him off and gas light him until an entire book later when they finally acknowledge he was right."};
            movieList.Add(new VHS("Harry Potter: The Rise of the Dark Lord One", "Action", 160, scenes4));

            List<string> scenes5 = new List<string>() {"Harry and Ron get in a fight because Ron gets jealous of Harry's fame and notariety.",
                "Hermione tries to keep the peace between Harry and Ron, eventually gets exhausted, and then yells at them to get it together.",
                "Ginny is all moody and broody and won't stop writing in a diary that writes back to her, she's super protective of the diary.",
                "Hermione gets all moody and distant from everyone  because she's time traveling and keeping it a secret",
                "Harry gets all dark and emotional because the Dark Lord and him are connected and he can't stop being connected to him"};
            movieList.Add(new VHS("Harry Potter: The Teen Angst One", "Drama", 234, scenes5));

            List<string> scenes6 = new List<string>() { "Harry is jolted awake from his nightmare of Voldemort killing a man",
                "Harry, Ron, and Hermione travel all over hiding from Voldemort and his lackies",
                "Harry breaks into Gringotts and then wrestles and fights with a Death Eater, trying to retrieve a Ravenclaw family heirloom aka Horcrux",
                "Harry, Ron, and Hermione return to Hogwarts after skipping school the entire year, plotting the castle's last stand against Voldemort",
                "Harry dies after Voldemort uses Avada Kedavra on him, but somehow goes to a weird heaven like place and then gets sent back to earth re-alive to fight again.",
                "Neville slices the snake with a sword, then Harry finishes off the Dark Lord, and all is well in the wizarding realm."};
            movieList.Add(new VHS("Harry Potter: The Epic Voldemort Defeat One", "Action", 338, scenes6));
        }

        //prints a list of all movies
        private void PrintMovies()
        {
            for(int i = 0; i < movieList.Count; i++)
            {  
                Console.WriteLine($"{i}: {movieList[i].Title}");
            }
        }

        //gets which movie the user wishes to check out.
        public Movie CheckOut()
        {
            bool goodInput = false;
            int choice = -1;
            PrintMovies();
            while (!goodInput)
            {
                try
                {
                    choice = int.Parse(GetInput("Which Movie would you like to Check Out? (Select Number): "));
                    Console.WriteLine($"\nYou have selected {movieList[choice]}");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid selection, must be an integer value.");
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Invalid Choice. Must be between 0 and {movieList.Count - 1}");
                    continue;
                }
            }
            return movieList[choice];
        }

        //gets input in string form
        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
