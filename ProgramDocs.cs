using System;

namespace MIS_Coding_Challenge
{
    public class ProgramDocs
    {
        public ProgramDocs()
        {
        }

        public static void Display()
        {
            Console.Clear();
            ProgramDocs.PrintTitle();
            ProgramDocs.PrintInfo();
        }

        static void PrintTitle()
        {
            Console.WriteLine("    _   _              _   ");
            Console.WriteLine("   /_\\ | |__  ___ _  _| |_ ");
            Console.WriteLine("  / _ \\| '_ \\/ _ \\ || |  _|");
            Console.WriteLine(" /_/ \\_\\_.__/\\___/\\_,_|\\__|");


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n*Make sure the console window is big enough (but not too big!)");
            Console.ResetColor();
            System.Console.WriteLine("If something looks scrambled, the window is too small.");
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n*There will be a slight delay due to the API anytime the program is retrieving a price.");
            Console.ResetColor();

            System.Console.WriteLine("It should not be more than a few seconds at most!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n*I've done my best to add in error checking...");
            Console.ResetColor();
            System.Console.WriteLine("but it may occasionally throw an error if it gets bad input!");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAbout This Program");
            Console.ResetColor();
            Console.WriteLine("\nI'm a big fan of game shows, so I thought it would be fun to make a few \"Price is Right\"-inspired minigames for my challenge entry! This was written in C#, using most (if not all) of the concepts we've covered this year in MIS-221.");
        }

        static void PrintInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nHow It Works");
            Console.ResetColor();
            Console.WriteLine("\nAfter originally developing my own online price scraper in C#, Jeff recommended that I locate an API so I didn't to worry about my requests getting blocked.");
            Console.WriteLine("I ended up using SerpAPI, an API that had a free tier available.");
            Console.WriteLine("\nAfter writing functions and classes to interface with the Price API, I created a file of 500+ random item names that could be fed to the API.");
            Console.WriteLine("\nI then dissected Google Shopping URLs to determine how to request item prices from different retailers based on a unique code.");


        }
    }
}
