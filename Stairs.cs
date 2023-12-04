using System;
using System.Threading.Tasks;

namespace MIS_Coding_Challenge
{
    public class Stairs : Game
    {
        private ProductInfo[] myProductInfo;
        private PriceGetter priceGetter;

        public Stairs(ProductInfo[] myProductInfo, PriceGetter priceGetter)
        {
            this.myProductInfo = myProductInfo;
            this.priceGetter = priceGetter;
        }

        public async Task Play()
        {
            Console.Clear();
            Stairs.PrintInstructions();
            Console.Clear();
            int stairPosition = 0;
            int difference = -1;
            Game.DisplayStairs(stairPosition, new string[] { "Stairs Game", "Guess 5 Items", "Move up for each $4 off" });

            bool continuePlaying = true;

            while (continuePlaying)
            {
                string[] itemNames = PriceGetter.ReadItemNamesFromFile();

                for (int i = 0; i < 5; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Item #{i + 1}:");
                    Console.ResetColor();
                    string randomItemName = PriceGetter.GetRandomItemName(itemNames);

                    await priceGetter.SearchProducts(randomItemName, PriceGetter.GetRetailerCode("Walmart"), 1);
                    double realPrice = myProductInfo[0].GetPrice();


                    double userGuess;
                    do
                    {
                        Console.WriteLine($"What is the price of {myProductInfo[0].GetProductName()} at Walmart?");
                        Console.Write("$");
                        if (!double.TryParse(Console.ReadLine(), out userGuess) || userGuess <= 0)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid, positive price.");
                        }
                        else
                        {
                            break;
                        }

                    } while (true);
                    difference = (int)Math.Abs(realPrice - userGuess);
                    stairPosition += difference / 4;

                    if (difference == 0)
                    {
                        Console.Clear();
                        Game.DisplayStairs(stairPosition, new string[] { $"The price was {(realPrice).ToString("C2")}", $"You guessed {(userGuess).ToString("C2")}", "You are safe!" });
                        Console.ResetColor();
                    }
                    else if (stairPosition >= 9)
                    {
                        continuePlaying = false;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        await Game.AnimateStairs(stairPosition - (difference / 4), stairPosition, new string[] { $"The price was {(realPrice).ToString("C2")}", $"You guessed {(userGuess).ToString("C2")}", $"You moved up {difference / 4} {(difference / 4 == 1 ? "step" : "steps")}" });
                        Console.ResetColor();
                    }
                }
                if (continuePlaying == true)
                {
                    Console.Clear();
                    continuePlaying = false;
                    Game.DisplayStairs(stairPosition, new string[] { $"Congrats!", "You survived the stairs", $"Score: {8 - stairPosition}" });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You win! Score: {8 - stairPosition}");
                    Console.ResetColor();
                }
            }

            Console.Clear();
            await Game.AnimateStairs(stairPosition - (difference / 4), 9, new string[] { $"GAME OVER", $"Try again next time!", $"You failed the stairs." });
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You died!");
            Console.ResetColor();
        }


        static void PrintInstructions()
        {
            Console.WriteLine("  ___ _        _           ___                ");
            Console.WriteLine(" / __| |_ __ _(_)_ _ ___  / __|__ _ _ __  ___ ");
            Console.WriteLine(" \\__ \\  _/ _` | | '_(_-< | (_ / _` | '  \\/ -_)");
            Console.WriteLine(" |___/\\__\\__,_|_|_| /__/  \\___\\__,_|_|_|_\\___|");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" Welcome to the stairs game!");
            Console.ResetColor();
            Console.WriteLine("\nYou will be given 5 items, and your job is to guess the price of each.");
            Console.WriteLine("For each $4 you are off, the Stair Climber will move up one step.");
            Console.WriteLine("Try not to fall off before the end. Good luck!");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\nPress Enter to continue...");
            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
