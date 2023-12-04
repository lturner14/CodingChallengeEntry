using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MIS_Coding_Challenge
{
    public class Game
    {

        static string[] GetNumberArt(int number)
        {
            switch (number)
            {
                case 0:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |     ____     | |",
                    "| |   .'    '.   | |",
                    "| |  |  .--.  |  | |",
                    "| |  | |    | |  | |",
                    "| |  |  `--'  |  | |",
                    "| |   '.____.'   | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                case 1:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |     __       | |",
                    "| |    /  |      | |",
                    "| |    `| |      | |",
                    "| |     | |      | |",
                    "| |    _| |_     | |",
                    "| |   |_____|    | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                case 2:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |    _____     | |",
                    "| |   / ___ `.   | |",
                    "| |  |_/___) |   | |",
                    "| |   .'____.'   | |",
                    "| |  / /____     | |",
                    "| |  |_______|   | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                case 3:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |    ______    | |",
                    "| |   / ____ `.  | |",
                    "| |   `'  __) |  | |",
                    "| |   _  |__ '.  | |",
                    "| |  | \\____) |  | |",
                    "| |   \\______.'  | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                case 4:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |   _    _     | |",
                    "| |  | |  | |    | |",
                    "| |  | |__| |_   | |",
                    "| |  |____   _|  | |",
                    "| |      _| |_   | |",
                    "| |     |_____|  | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                case 5:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |   _______    | |",
                    "| |  |  _____|   | |",
                    "| |  | |____     | |",
                    "| |  '_.____''.  | |",
                    "| |  | \\____) |  | |",
                    "| |   \\______.'  | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                case 6:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |    ______    | |",
                    "| |  .' ____ \\   | |",
                    "| |  | |____\\_|  | |",
                    "| |  | '____`'.  | |",
                    "| |  | (____) |  | |",
                    "| |  '.______.'  | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                case 7:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |   _______    | |",
                    "| |  |  ___  |   | |",
                    "| |  |_/  / /    | |",
                    "| |      / /     | |",
                    "| |     / /      | |",
                    "| |    /_/       | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                case 8:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |     ____     | |",
                    "| |   .' __ '.   | |",
                    "| |   | (__) |   | |",
                    "| |   .`____'.   | |",
                    "| |  | (____) |  | |",
                    "| |  `.______.'  | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                case 9:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |    ______    | |",
                    "| |  .' ____ '.  | |",
                    "| |  | (____) |  | |",
                    "| |  '_.____. |  | |",
                    "| |  | \\____| |  | |",
                    "| |   \\______,'  | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                case 10:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |              | |",
                    "| |              | |",
                    "| |              | |",
                    "| |              | |",
                    "| |      _       | |",
                    "| |     (_)      | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                case 11:
                    return new string[]
                    {
                    " .----------------. ",
                    "| .--------------. |",
                    "| |    ______    | |",
                    "| |   / _ __ `.  | |",
                    "| |  |_/____) |  | |",
                    "| |    /  ___.'  | |",
                    "| |    |_|       | |",
                    "| |    (_)       | |",
                    "| |              | |",
                    "| '--------------' |",
                    " '----------------' "
                    };
                default:
                    return null;
            }
        }
        public static void DisplayPrice(double price, ConsoleColor textColor = ConsoleColor.White)
        {
            string priceString = price.ToString();
            string[][] digits = new string[50][];
            int count = 0;

            foreach (char character in priceString)
            {
                if (char.IsDigit(character))
                {
                    int index = int.Parse(character.ToString());
                    string[] numberArt = GetNumberArt(index);

                    if (numberArt != null)
                    {
                        digits[count] = numberArt;
                        count++;
                    }
                }
                else if (character == '.')
                {
                    digits[count] = GetNumberArt(10);
                    count++;
                }
                else if (character == '?')
                {
                    digits[count] = GetNumberArt(11);
                    count++;
                }
            }

            // print digits with specified text color
            for (int i = 0; i < 11; i++)
            {
                Console.ForegroundColor = textColor;

                for (int j = 0; j < count; j++)
                {
                    Console.Write(digits[j][i]);
                }

                Console.ResetColor();
                Console.WriteLine();
            }

        }
        public static int[] FindMatchingIndices(string userGuess, string price)
        {
            int minLength = Math.Min(userGuess.Length, price.Length);
            int matchingCount = 0;

            for (int i = 0; i < minLength; i++)
            {
                if (userGuess[i] == price[i])
                {
                    matchingCount++;
                }
            }

            int[] matchIndices = new int[matchingCount];
            matchingCount = 0;

            for (int i = 0; i < minLength; i++)
            {
                if (userGuess[i] == price[i])
                {
                    matchIndices[matchingCount++] = i;
                }
            }

            return matchIndices;
        }


        public static void DisplayGuess(string userGuess, int[] matchingIndices)
        {
            string userGuessString = userGuess;
            string[][] digits = new string[50][];
            int count = 0;

            foreach (char character in userGuessString)
            {
                if (char.IsDigit(character))
                {
                    int index = int.Parse(character.ToString());
                    string[] numberArt = GetNumberArt(index);

                    if (numberArt != null)
                    {
                        digits[count] = numberArt;
                        count++;
                    }
                }
                else if (character == '.')
                {
                    digits[count] = GetNumberArt(10);
                    count++;
                }
                else if (character == '?')
                {
                    digits[count] = GetNumberArt(11);
                    count++;
                }
            }

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (IsInArray(j + 1, matchingIndices))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write(digits[j][i]);
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }


        static bool IsInArray(int number, int[] array)
        {
            foreach (int element in array)
            {
                if (element == number)
                {
                    return true;
                }
            }
            return false;
        }

        public static void DisplayPrice(string price)
        {

            string[][] digits = new string[50][];
            int count = 0;
            foreach (char character in price)
            {
                if (char.IsDigit(character))
                {
                    int index = int.Parse(character.ToString());
                    string[] numberArt = GetNumberArt(index);
                    if (numberArt != null)
                    {
                        digits[count] = numberArt;
                        count++;
                    }
                }
                else if (character == '.')
                {
                    digits[count] = GetNumberArt(10);
                    count++;
                }
                else if (character == '?')
                {
                    digits[count] = GetNumberArt(11);
                    count++;
                }
            }


            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Console.Write(digits[j][i]);
                }
                Console.WriteLine();
            }
        }

        public static void DisplayStairs(int userInput, string[] messages)
        {
            int steps = 8;
            ConsoleColor textColor = ConsoleColor.White;
            static void WriteColor(string message, ConsoleColor color)
            {
                var pieces = Regex.Split(message, @"(\[[^\]]*\])");

                for (int i = 0; i < pieces.Length; i++)
                {
                    string piece = pieces[i];

                    if (piece.StartsWith("[") && piece.EndsWith("]"))
                    {
                        Console.ForegroundColor = color;
                        piece = piece.Substring(1, piece.Length - 2);
                    }

                    Console.Write(piece);
                    Console.ResetColor();
                }

                Console.WriteLine();
            }

            if (userInput <= 3)
            {
                textColor = ConsoleColor.Green;
            }
            if (userInput > 3 && userInput <= 6)
            {
                textColor = ConsoleColor.Yellow;
            }
            if (userInput > 6)
            {
                textColor = ConsoleColor.Red;
            }
            int userInputPos = 7 - userInput;
            for (int x = 0; x < messages.Length; x++)
            {
                if (messages[x].Length % 2 != 0)
                {
                    messages[x] += " ";
                }
            }
            for (int x = 0; x < steps; x++)
            {
                string spacesBefore = new string(' ', (steps - x - 1) * 5);
                string spacesAfter = new string(' ', x * 5);

                if (x == 0)
                {
                    if (userInput == 8)
                    {
                        Console.ForegroundColor = textColor;
                        Console.WriteLine($"{spacesBefore}         o  {spacesAfter}");
                        Console.WriteLine($"{spacesBefore}        /|\\ {spacesAfter}");
                        Console.WriteLine($"{spacesBefore}        / \\ {spacesAfter}");
                        Console.ResetColor();
                        Console.WriteLine($"{spacesBefore}      ******{spacesAfter}*");
                        Console.WriteLine($"{spacesBefore}      *     {spacesAfter}*");
                        Console.WriteLine($"{spacesBefore}      *     {spacesAfter}*");
                    }
                    else if (userInput == 7)
                    {
                        Console.WriteLine($"{spacesBefore}            {spacesAfter}");
                        Console.WriteLine($"{spacesBefore}            {spacesAfter}");
                        Console.WriteLine($"{spacesBefore}            {spacesAfter}");
                        Console.ResetColor();
                        WriteColor($"{spacesBefore}   [o]  ******{spacesAfter}*", textColor);
                        WriteColor($"{spacesBefore}  [/|\\] *     {spacesAfter}*", textColor);
                        WriteColor($"{spacesBefore}  [/ \\] *     {spacesAfter}*", textColor);
                    }
                    else
                    {
                        Console.WriteLine($"{spacesBefore}            {spacesAfter}");
                        Console.WriteLine($"{spacesBefore}            {spacesAfter}");
                        Console.WriteLine($"{spacesBefore}            {spacesAfter}");
                        Console.WriteLine($"{spacesBefore}      ******{spacesAfter}*");
                        Console.WriteLine($"{spacesBefore}      *     {spacesAfter}*");
                        Console.WriteLine($"{spacesBefore}      *     {spacesAfter}*");

                    }

                }
                else
                {
                    if (x == 6)
                    {
                        if (userInputPos == 6)
                        {
                            int length = messages[0].Length;
                            string spacesAfter2 = new string(' ', ((x * 5 - length) / 2));
                            WriteColor($"{spacesBefore}   [o]  ******{spacesAfter2}{messages[0]}{spacesAfter2}*", textColor);
                            length = messages[1].Length;
                            spacesAfter2 = new string(' ', ((x * 5 - length) / 2));
                            WriteColor($"{spacesBefore}  [/|\\] *     {spacesAfter2}{messages[1]}{spacesAfter2}*", textColor);
                            length = messages[2].Length;
                            spacesAfter2 = new string(' ', ((x * 5 - length) / 2));
                            WriteColor($"{spacesBefore}  [/ \\] *     {spacesAfter2}{messages[2]}{spacesAfter2}*", textColor);
                        }
                        else
                        {
                            int length = messages[0].Length;
                            string spacesAfter2 = new string(' ', ((x * 5 - length) / 2));
                            Console.WriteLine($"{spacesBefore}      ******{spacesAfter2}{messages[0]}{spacesAfter2}*");
                            length = messages[1].Length;

                            spacesAfter2 = new string(' ', ((x * 5 - length) / 2));
                            Console.WriteLine($"{spacesBefore}      *     {spacesAfter2}{messages[1]}{spacesAfter2}*");
                            length = messages[2].Length;

                            spacesAfter2 = new string(' ', ((x * 5 - length) / 2));
                            Console.WriteLine($"{spacesBefore}      *     {spacesAfter2}{messages[2]}{spacesAfter2}*");
                        }
                    }
                    else if (x == 7)
                    {
                        if (userInput > 8)
                        {
                            Console.WriteLine($"{spacesBefore}      ******{spacesAfter}*");
                            Console.WriteLine($"{spacesBefore}      *     {spacesAfter}*");
                            WriteColor($"{spacesBefore}      *     {spacesAfter}*     [___/o]", textColor);
                        }
                        else if (userInput != 0)
                        {
                            Console.WriteLine($"{spacesBefore}      ******{spacesAfter}*");
                            Console.WriteLine($"{spacesBefore}      *     {spacesAfter}*");
                            Console.WriteLine($"{spacesBefore}      *     {spacesAfter}*");
                        }
                        else
                        {
                            WriteColor($"{spacesBefore}   [o]  ******{spacesAfter}*", textColor);
                            WriteColor($"{spacesBefore}  [/|\\] *     {spacesAfter}*", textColor);
                            WriteColor($"{spacesBefore}  [/ \\] *     {spacesAfter}*", textColor);
                        }
                    }
                    else
                    {
                        if (x == userInputPos)
                        {
                            WriteColor($"{spacesBefore}   [o]  ******{spacesAfter}*", textColor);
                            WriteColor($"{spacesBefore}  [/|\\] *     {spacesAfter}*", textColor);
                            WriteColor($"{spacesBefore}  [/ \\] *     {spacesAfter}*", textColor);
                        }
                        else
                        {
                            Console.WriteLine($"{spacesBefore}      ******{spacesAfter}*");
                            Console.WriteLine($"{spacesBefore}      *     {spacesAfter}*");
                            Console.WriteLine($"{spacesBefore}      *     {spacesAfter}*");
                        }
                    }
                }
            }
            if (userInput > 8)
            {
                WriteColor("************************************************    [/)  |]", textColor);
            }
            else
            {
                Console.WriteLine("************************************************");
            }
            Console.ResetColor();
        }
        public static async Task AnimateStairs(int start, int end, string[] messages)
        {
            for (int currentStep = start; currentStep <= end; currentStep++)
            {
                Console.Clear();
                DisplayStairs(currentStep, messages);
                await Task.Delay(1000);
            }
        }
    }


}