using System;
using System.Threading.Tasks;

namespace MIS_Coding_Challenge
{
    public class WhichSide : Game
    {
        private ProductInfo[] myProductInfo;
        private PriceGetter priceGetter;

        public WhichSide(ProductInfo[] myProductInfo, PriceGetter priceGetter)
        {
            this.myProductInfo = myProductInfo;
            this.priceGetter = priceGetter;
        }

        public async Task Play()
        {
            Console.Clear();
            WhichSide.PrintInstructions();
            string[] itemNames = PriceGetter.ReadItemNamesFromFile();
            Random random = new Random();
            int randomSide = -1;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine($"Item #{i + 1}:");
                Console.ResetColor();
                string randomItemName = PriceGetter.GetRandomItemName(itemNames);
                await priceGetter.SearchProducts(randomItemName, PriceGetter.GetRetailerCode("Walmart"), 1);
                double realPrice = myProductInfo[0].GetPrice();
                string[] scrambledInfo = PriceModifier.SplitPrice(realPrice.ToString());
                string scrambledPrice = scrambledInfo[0];
                string scrambledSide = scrambledInfo[1];

                randomSide = random.Next(2);

                string maskedPrice = PriceModifier.MaskSide(scrambledPrice, randomSide);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine($"Item #{i + 1}:");
                Console.ResetColor();

                Game.DisplayPrice($"{maskedPrice:C2}");


                Console.WriteLine($"What is the price of {myProductInfo[0].GetProductName()} at Walmart?");
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("\nPress Spacebar to alternate between sides.\nPress Enter when the correct side is visible.");
                Console.ResetColor();

                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        randomSide = 1 - randomSide;
                        maskedPrice = PriceModifier.MaskSide(scrambledPrice, randomSide);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine($"Item #{i + 1}:");
                        Console.ResetColor();

                        Game.DisplayPrice($"{maskedPrice:C2}");

                        Console.WriteLine($"What is the price of {myProductInfo[0].GetProductName()} at Walmart?");
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine("\nPress Spacebar to alternate between sides.\nPress Enter when the correct side is visible.");
                        Console.ResetColor();

                    }

                } while (keyInfo.Key != ConsoleKey.Enter);

                if (int.Parse(scrambledSide) == randomSide)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine($"Item #{i + 1}:");
                    Console.ResetColor();
                    Game.DisplayPrice(realPrice, ConsoleColor.Green);
                    System.Console.WriteLine("Correct! You got it!");
                    Thread.Sleep(4000);
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine($"Item #{i + 1}:");
                    Console.ResetColor();
                    Game.DisplayPrice(realPrice, ConsoleColor.Red);
                    System.Console.WriteLine($"Incorrect. The correct price was {realPrice.ToString("C2")}.");
                    Thread.Sleep(4000);
                }
            }
        }


        static void PrintInstructions()
        {
            Console.WriteLine(" __      ___    _    _      ___ _    _     ");
            Console.WriteLine(" \\ \\    / / |_ (_)__| |_   / __(_)__| |___ ");
            Console.WriteLine("  \\ \\/\\/ /| ' \\| / _| ' \\  \\__ \\ / _` / -_)");
            Console.WriteLine("   \\_/\\_/ |_||_|_\\__|_||_| |___/_\\__,_\\___|");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" Welcome to the Which Side game!");
            Console.ResetColor();
            Console.WriteLine("\nYou will be given 5 items");
            System.Console.WriteLine("Determine whether the left or right digits are correct.");
            Console.WriteLine("You only get one try for each price.");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\nPress Enter to continue...");
            Console.ResetColor();

            Console.ReadLine();
        }

    }
}