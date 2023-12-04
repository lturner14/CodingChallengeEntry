using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS_Coding_Challenge
{
    public class StumpMePlay : Game
    {
        private ProductInfo[] myProductInfo;
        private StumpMe[] stumpMe;
        private PriceGetter priceGetter;
        private StumpMeUtility stumpMeUtility;

        public StumpMePlay(ProductInfo[] myProductInfo, PriceGetter priceGetter, StumpMe[] stumpMe, StumpMeUtility stumpMeUtility)
        {
            this.myProductInfo = myProductInfo;
            this.priceGetter = priceGetter;
            this.stumpMe = stumpMe;
            this.stumpMeUtility = stumpMeUtility;
        }

        public async Task Play()
        {
            Console.Clear();
            StumpMePlay.PrintInstructions();
            Console.Clear();

            System.Console.WriteLine("Player 1, it's your turn to add three items.");
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("Press Enter to continue...");

            Console.ResetColor();
            Console.ReadLine();

            int currentUser = 1;

            for (int i = 0; i < 3; i++)
            {
                await AddItem(currentUser);
            }

            Console.Clear();

            System.Console.WriteLine("Player 2, it's your turn to add three items.");
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("Press Enter to continue...");

            Console.ResetColor();
            Console.ReadLine();

            currentUser = 2;

            for (int i = 0; i < 3; i++)
            {
                await AddItem(currentUser);
            }
            stumpMeUtility.SaveItemsToFile();
            Console.Clear();
            System.Console.WriteLine("Player 2, it's time to guess the prices of Player 1's items.");
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("Press Enter to continue...");

            Console.ResetColor();
            Console.ReadLine();
            int player2Score = GuessItems(2, stumpMe, stumpMeUtility, priceGetter, myProductInfo);

            Console.Clear();
            System.Console.WriteLine("Player 1, it's time to guess the prices of Player 2's items.");
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("Press Enter to continue...");

            Console.ResetColor();
            Console.ReadLine();
            int player1Score = GuessItems(1, stumpMe, stumpMeUtility, priceGetter, myProductInfo);


            DisplayFinalScores(player1Score, player2Score);
        }

        private async Task AddItem(int currentUser)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            System.Console.WriteLine($"What item you would like to search for?");
            Console.ResetColor();
            string userItem = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;

            System.Console.WriteLine("\nEnter your preferred retailer (Target, Walmart, Amazon, or -1 for all)");
            Console.ResetColor();

            string preferredRetailer = Console.ReadLine();
            await priceGetter.SearchProducts(userItem, PriceGetter.GetRetailerCode(preferredRetailer), 5);

            int currentIndex = 0;
            bool exitLoop = false;

            while (!exitLoop)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;

                System.Console.WriteLine($"Your search: \"{userItem}\"");
                Console.ResetColor();
                priceGetter.DisplayProduct(currentIndex, false);
                System.Console.WriteLine("\nPress Enter key to toggle between items");
                Console.ForegroundColor = ConsoleColor.Blue;

                System.Console.WriteLine("Type S to select item.");
                Console.ResetColor();


                ConsoleKeyInfo keyInfo = Console.ReadKey();
                string userInput = keyInfo.Key == ConsoleKey.Enter ? "" : keyInfo.KeyChar.ToString();

                switch (userInput.ToUpper())
                {
                    case "S":
                        Console.Clear();
                        priceGetter.DisplayProduct(currentIndex, false, ConsoleColor.Green);
                        StumpMe newItem = new StumpMe(myProductInfo[currentIndex].GetProductName(), myProductInfo[currentIndex].GetRetailerName(), myProductInfo[currentIndex].GetPrice(), currentUser);
                        stumpMeUtility.AddItem(newItem);
                        stumpMeUtility.SaveItemsToFile();
                        System.Console.WriteLine("Adding item...");
                        await Task.Delay(1000);
                        exitLoop = true;
                        break;

                    case "":
                        currentIndex = (currentIndex + 1) % 5;
                        break;

                    default:
                        break;
                }
            }
        }



        private int GuessItems(int currentUser, StumpMe[] stumpMe, StumpMeUtility stumpMeUtility, PriceGetter priceGetter, ProductInfo[] myProductInfo)
        {
            stumpMeUtility.LoadItems();

            List<int> indices = FindIndicesByUserNum(currentUser, stumpMe);
            int userPoints = 0;

            foreach (int index in indices)
            {
                Console.Clear();
                priceGetter.DisplaySelectedProducts(index, true, stumpMe);
                double actualPrice = stumpMe[index].GetPrice();
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine("\nWhat is your guess?");
                Console.ResetColor();
                Console.Write("$");
                double userGuess;
                while (!double.TryParse(Console.ReadLine(), out userGuess))
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    System.Console.WriteLine("\nInvalid input. Please enter a valid price.");
                    Console.ResetColor();
                    Console.Write("$");

                }
                userPoints += (int)Math.Abs(actualPrice - userGuess);

                if (Math.Abs(userGuess - actualPrice) <= 5)
                {
                    Console.Clear();
                    priceGetter.DisplaySelectedProducts(index, false, stumpMe);

                    System.Console.WriteLine($"\nYou guessed {userGuess.ToString("C2")}");
                    Console.ForegroundColor = ConsoleColor.Green;

                    System.Console.WriteLine($"You were ${userPoints} off.");
                    Console.ResetColor();
                    Thread.Sleep(4000);
                }
                else
                {
                    Console.Clear();
                    priceGetter.DisplaySelectedProducts(index, false, stumpMe);
                    System.Console.WriteLine($"\nYou guessed {userGuess.ToString("C2")}");

                    Console.ForegroundColor = ConsoleColor.Red;

                    System.Console.WriteLine($"You were ${userPoints} off.");

                    Console.ResetColor();
                    Thread.Sleep(4000);

                }
            }
            System.Console.WriteLine($"\nPlayer {currentUser}, your score is: {userPoints}.");
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine($"\nPress Enter to continue...");

            Console.ResetColor();
            Console.ReadLine();
            return userPoints;
        }

        private void DisplayFinalScores(int player1Score, int player2Score)
        {
            Console.Clear();
            System.Console.WriteLine($"Player 1's final score: {player1Score}");
            System.Console.WriteLine($"Player 2's final score: {player2Score}");

            if (player1Score < player2Score)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                System.Console.WriteLine("\nPlayer 1 wins!");
                Console.ForegroundColor = ConsoleColor.Red;

                System.Console.WriteLine("Sorry, Player 2!");
                Console.ResetColor();
            }
            else if (player2Score < player1Score)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                System.Console.WriteLine("\nPlayer 2 wins!");
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Sorry, Player 1!");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                System.Console.WriteLine("\nIt's a tie!");
                Console.ResetColor();
            }
        }

        private static List<int> FindIndicesByUserNum(int currentUser, StumpMe[] stumpMe)
        {
            List<int> indices = new List<int>();

            if (currentUser == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    indices.Add(i);
                }
            }
            else
            {
                for (int i = 3; i < 6; i++)
                {
                    indices.Add(i);
                }
            }
            return indices;
        }

        static void PrintInstructions()
        {
            Console.WriteLine("  ___ _                     __  __     ");
            Console.WriteLine(" / __| |_ _  _ _ __  _ __  |  \\/  |___ ");
            Console.WriteLine(" \\__ \\  _| || | '  \\| '_ \\ | |\\/| / -_)");
            Console.WriteLine(" |___/\\__|\\_,_|_|_|_| .__/ |_|  |_|\\___|");
            Console.WriteLine("                    |_|                 ");


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to the Stump Me game!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("*This game is for 2 players*");
            Console.ResetColor();

            System.Console.WriteLine("\nEach player selects 3 items to quiz the other player on.");
            Console.WriteLine("The player gets one chance to guess each of the other player's items.");
            System.Console.WriteLine("The player with the lowest score (closest to the prices) wins!");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\nPress Enter to continue...");
            Console.ResetColor();

            Console.ReadLine();
        }

    }
}
