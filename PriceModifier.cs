using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS_Coding_Challenge
{
    public class PriceModifier
    {

        public static string MaskSide(string input, int maskSide)
        {
            string numberString = input;
            int dotIndex = numberString.IndexOf('.');

            if (dotIndex >= 0)
            {
                string leftSide = numberString.Substring(0, dotIndex);
                string rightSide = numberString.Substring(dotIndex + 1);

                string sideToMask = (maskSide == 0) ? leftSide : rightSide;

                string maskedSide = new string('?', sideToMask.Length);

                string result = (maskSide == 0) ? maskedSide + "." + rightSide : leftSide + "." + maskedSide;

                return result;
            }


            return numberString;
        }


        public static string OrderDigitsAscending(string price)
        {
            string priceString = price.Replace(".", "").Replace("$", "");
            char[] digitsArray = priceString.ToCharArray();

            for (int i = 0; i < digitsArray.Length - 1; i++)
            {
                for (int j = 0; j < digitsArray.Length - 1 - i; j++)
                {
                    if (digitsArray[j] > digitsArray[j + 1])
                    {

                        char temp = digitsArray[j];
                        digitsArray[j] = digitsArray[j + 1];
                        digitsArray[j + 1] = temp;
                    }
                }
            }
            string orderedDigits = new string(digitsArray) + ".";
            return orderedDigits;
        }


        public static string[] SplitPrice(string price)
        {
            string priceString = price;
            string[] parts = priceString.Split('.');

            
            string leftSide = parts[0];
            string rightSide = parts[1];

            Random random = new Random();
            int randomValue = random.Next(2);
            if (randomValue == 0)
            {
                return new string[] { $"{GenerateRandomDigits(leftSide.Length)}.{rightSide}", "0" };
            }
            else
            {
                return new string[] { $"{leftSide}.{GenerateRandomDigits(rightSide.Length)}", "1" };
            }
        }
        static string GenerateRandomDigits(int numberOfDigits)
        {
            Random random = new Random();
            string result = "";

            for (int i = 0; i < numberOfDigits; i++)
            {
                result += random.Next(1, 10).ToString();
            }

            return result;
        }

        public static bool AreStringsEquivalent(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            int[] charCount1 = CountCharacters(str1);
            int[] charCount2 = CountCharacters(str2);

            return AreCharacterCountsEqual(charCount1, charCount2);
        }

        static int[] CountCharacters(string str)
        {
            int[] charCount = new int[128]; 

            foreach (char c in str)
            {
                charCount[c]++;
            }

            return charCount;
        }

        static bool AreCharacterCountsEqual(int[] charCount1, int[] charCount2)
        {
            for (int i = 0; i < charCount1.Length; i++)
            {
                if (charCount1[i] != charCount2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}