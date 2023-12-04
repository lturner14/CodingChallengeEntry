using System;
using System.Threading.Tasks;

namespace MIS_Coding_Challenge
{
    public class OrderPrice : Game
    {
        private ProductInfo[] myProductInfo;
        private PriceGetter priceGetter;

        public OrderPrice(ProductInfo[] myProductInfo, PriceGetter priceGetter)
        {
            this.myProductInfo = myProductInfo;
            this.priceGetter = priceGetter;
        }
        public async Task Play()
        {
            Console.Clear();
            OrderPrice.PrintInstructions();
            string[] itemNames = PriceGetter.ReadItemNamesFromFile();

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Item #{i + 1}:");
                Console.ResetColor();
                string randomItemName = PriceGetter.GetRandomItemName(itemNames);
                await priceGetter.SearchProducts(randomItemName, PriceGetter.GetRetailerCode("Walmart"), 1);
                double realPrice = myProductInfo[0].GetPrice();
                string orderedDigits = PriceModifier.OrderDigitsAscending(realPrice.ToString("C2"));

                int tries = 0;
                bool correctGuess = false;
                double userGuess = -1.00;

                while (tries < 3 && !correctGuess)
                {
                    Console.Clear();
                    if (tries == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine($"Item #{i + 1}:");
                        Console.ResetColor();
                        Game.DisplayPrice(orderedDigits);

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine($"Item #{i + 1}:");
                        Console.ResetColor();
                        Game.DisplayGuess(userGuess.ToString("C2"), Game.FindMatchingIndices(userGuess.ToString("C2"), realPrice.ToString("C2")));
                    }

                    bool isValidInput = false;

                    while (!isValidInput)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine($"What is the price of {myProductInfo[0].GetProductName()} at Walmart? (Attempt {tries + 1}):");
                        Console.ResetColor();
                        Console.Write("$");
                        if (double.TryParse(Console.ReadLine(), out userGuess) && PriceModifier.AreStringsEquivalent(userGuess.ToString("C2"), realPrice.ToString("C2")))
                        {
                            isValidInput = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("Invalid input. Please enter a valid price.");
                            Console.ResetColor();
                        }
                    }
                    if (userGuess == realPrice)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine($"Item #{i + 1}:");
                        Console.ResetColor();
                        Game.DisplayGuess(userGuess.ToString("C2"), Game.FindMatchingIndices(userGuess.ToString("C2"), realPrice.ToString("C2")));
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Correct! You guessed it!");
                        Console.ResetColor();
                        await Task.Delay(2000);
                        correctGuess = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine($"Item #{i + 1}:");
                        Console.ResetColor();
                        Game.DisplayGuess(userGuess.ToString("C2"), Game.FindMatchingIndices(userGuess.ToString("C2"), realPrice.ToString("C2")));
                        Console.ForegroundColor = ConsoleColor.Magenta;

                        System.Console.WriteLine("Not quite.");
                        Console.ResetColor();
                        await Task.Delay(2000);
                        tries++;

                    }
                }
                if (!correctGuess)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine($"Sorry, you couldn't guess the price for {myProductInfo[0].GetProductName()}.\nThe correct price was {realPrice.ToString("C2")}");
                    Console.ResetColor();
                    await Task.Delay(3000);
                }
            }


        }


        static void PrintInstructions()
        {
            Console.WriteLine("   ___         _           ___     _        ");
            Console.WriteLine("  / _ \\ _ _ __| |___ _ _  | _ \\_ _(_)__ ___ ");
            Console.WriteLine(" | (_) | '_/ _` / -_) '_| |  _/ '_| / _/ -_)");
            Console.WriteLine("  \\___/|_| \\__,_\\___|_|   |_| |_| |_|\\__\\___|");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" Welcome to the Order Price game!");
            Console.ResetColor();
            Console.WriteLine("\nYou will be given 3 items, and you have to order the digits to form the correct price.");
            Console.WriteLine("The digits will change colors to indicate which guesses are correct.");
            Console.WriteLine("You get three tries for each price.");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\nPress Enter to continue...");
            Console.ResetColor();
            Console.ReadLine();
        }

    }
}