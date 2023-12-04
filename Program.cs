using System;
using System.IO;
using System.Threading.Tasks;
using MIS_Coding_Challenge;

class Program
{
    static async Task Main()
    {
        ProductInfo[] myProductInfo = new ProductInfo[100];

        ProductInfoUtility productInfoUtility = new ProductInfoUtility(myProductInfo);

        PriceGetter priceGetter = new PriceGetter(myProductInfo, productInfoUtility);
        Game game = new Game();
        StumpMe[] stumpMe = new StumpMe[100];
        StumpMeUtility stumpMeUtility = new StumpMeUtility(stumpMe);
        ProgramDocs programDocs = new ProgramDocs();
        Stairs stairsGame = new Stairs(myProductInfo, priceGetter);
        OrderPrice orderPriceGame = new OrderPrice(myProductInfo, priceGetter);
        WhichSide whichSideGame = new WhichSide(myProductInfo, priceGetter);
        StumpMePlay stumpMePlay = new StumpMePlay(myProductInfo, priceGetter, stumpMe, stumpMeUtility);

        bool exitMenu = false;

        do
        {
            Console.Clear();
            PrintTitle();
            Console.WriteLine("\n");
            Console.WriteLine("Welcome to the Price is Right Games!");

            // Set console text color for different games
            Console.WriteLine("0. About This Program");
            Console.WriteLine("1. Stairs Game");

            Console.WriteLine("2. Order Price Game");

            Console.WriteLine("3. Which Side Game");

            Console.WriteLine("4. Stump Me Game");

            // Reset console text color to default

            Console.WriteLine("5. Exit");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\nEnter your choice (1-5): ");
            Console.ResetColor();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    ProgramDocs.Display();
                    break;
                case "1":
                    await stairsGame.Play();
                    break;

                case "2":
                    await orderPriceGame.Play();
                    break;

                case "3":
                    await whichSideGame.Play();
                    break;

                case "4":
                    await stumpMePlay.Play();
                    break;

                case "5":
                    Console.WriteLine("Exiting the game. Goodbye!");
                    exitMenu = true;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice. Please enter a number from 1 to 5.");
                    Console.ResetColor();
                    break;
            }

            if (!exitMenu)
            {
                Console.WriteLine("\nPress Enter to return to Main Menu...");
                Console.ReadLine();
            }

        } while (!exitMenu);
    }

    static void PrintTitle()
    {
        Console.WriteLine("  ___     _          _      ___ _      _   _   ");
        Console.WriteLine(" | _ \\_ _(_)__ ___  (_)___ | _ (_)__ _| |_| |_ ");
        Console.WriteLine(" |  _/ '_| / _/ -_) | (_-< |   / / _` | ' \\  _|");
        Console.WriteLine(" |_| |_| |_|\\__\\___| |_/__/ |_|_\\_\\__, |_| |_|  ");
        Console.WriteLine("                               |___/          ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(" By Luke Turner | MIS-221 Coding Competition");
        Console.ResetColor();
    }
}
