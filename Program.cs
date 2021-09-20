using System;
using System.Diagnostics;
using System.Threading;
using System.Xml;

namespace Lab1Sharp
{
    class Guitarman
    {
        //Class Fields
        private string Name { get; set; }
        private string Guitar { get; set; }
        protected string[] Repertoir { get; set; }
        internal readonly int DateOfBirth;
        static readonly private int date = DateTime.Now.Year;

        //Class Methods
        public void PlayGuitar()
        {
            Random gen = new Random();
            int rand = gen.Next(maxValue: this.Repertoir.Length);
            Console.WriteLine($"{this.Name} plays the {this.Repertoir[rand]} on {this.Guitar} guitar...");
            for (int i = 0; i < 10; i++)
            {
                rand = gen.Next(2);
                if (rand == 1) Console.WriteLine("Right note! Great!");
                else Console.WriteLine("Wrong note! Badly!");
            }
            Console.WriteLine($"{this.Name} played the song.\n\n\n");
        }

        public void LearnNewSong(string new_song)
        {
            Console.WriteLine($"{this.Name} learning the song {new_song}...");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Learning...");
                Thread.Sleep(500);
            }

            string[] temp = new string[this.Repertoir.Length + 1];
            this.Repertoir.CopyTo(temp, 0);
            temp[temp.Length - 1] = new_song;
            this.Repertoir = temp;
            
            Console.WriteLine("The song is learned!\n\n\n");
        }

        public void ChangeGuitar(string new_guitar)
        {
            this.Guitar = new_guitar;
            Console.WriteLine("Success!\n\n\n");
        }

        internal void GetInfo()
        {
            Console.WriteLine("Information about guitarman:");
            Console.WriteLine($"Name: {this.Name};");
            Console.WriteLine($"Guitar: {this.Guitar};");
            Console.Write($"Repertoir: ");
            foreach (string element in this.Repertoir)
            {
                Console.Write($"{element}; ");
            }
            Console.WriteLine($"\nDate of birth: {this.DateOfBirth} ({Guitarman.GetAge(this)} years old).\n\n\n");
        }

        private static int GetAge(Guitarman guitarman)
        {
            return date - guitarman.DateOfBirth;
        }

        //Class Constructors
        public Guitarman()
        {

        }

        public Guitarman(string name)
        {
            this.Name = name;
        }

        public Guitarman(string name, string guitar, string[] repertoir, int dateOfbirth)
        {
            this.Name = name;
            this.Guitar = guitar;
            this.Repertoir = repertoir;
            this.DateOfBirth = dateOfbirth;
        }

        public Guitarman(Guitarman guitarman)
        {
            this.Name = guitarman.Name;
            this.Guitar = guitarman.Guitar;
            this.Repertoir = guitarman.Repertoir;
            this.DateOfBirth = guitarman.DateOfBirth;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] temp = new string[] {"Smoke On The Water", "Smells Like Teen Spirit", "Sweet Home Alabama"};
            Guitarman One = new Guitarman("Freddy", "Gibson", temp, 1967);
            One.LearnNewSong("Back In Black");
            One.GetInfo();
            One.ChangeGuitar("Fender");
        }
    }
}