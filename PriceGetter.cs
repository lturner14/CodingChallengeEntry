using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MIS_Coding_Challenge
{
    public class PriceGetter
    {
        private ProductInfo[] myProductInfo;
        private ProductInfoUtility productInfoUtility;

        public PriceGetter(ProductInfo[] myProductInfo, ProductInfoUtility productInfoUtility)
        {
            this.myProductInfo = myProductInfo;
            this.productInfoUtility = productInfoUtility;
        }
        public static string[] ReadItemNamesFromFile()
        {
            string filePath = "items.txt"; 

            string[] itemNames = new string[0];

            if (File.Exists(filePath))
            {
                itemNames = File.ReadAllText(filePath).Split('#');
            }
            else
            {
                Console.WriteLine("File not found: " + filePath);
            }

            return itemNames;
        }

        public static string GetRandomItemName(string[] itemNames)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, itemNames.Length);

            return itemNames[randomIndex];
        }
        public static string GetRetailerCode(string storeName)
        {
            string filePath = "retailers.txt";

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('#');
                        string currentStoreName = parts[0].Trim();
                        string code = parts[1];

                        if (currentStoreName.ToUpper() == storeName.ToUpper())
                        {
                            return code;
                        }
                    }
                }
            }
            catch
            {
                return "-1";
            }

            return "-1";
        }

        public static string GetRetailerName(string retailerCode)
        {
            string filePath = "retailers.txt"; 

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('#');
                        string currentStoreName = parts[0];
                        string code = parts[1];
                        if (retailerCode == code)
                        {
                            return currentStoreName;
                        }
                    }
                }
            }
            catch
            {

                return "-1";
            }
            return "-1";
        }
        static string ReplaceNumbersWithUnderscores(string price)
        {
            char[] priceChars = price.ToCharArray();

            for (int i = 1; i < priceChars.Length; i++) 
            {
                if (char.IsDigit(priceChars[i]))
                {
                    priceChars[i] = '_';
                }
            }

            string modifiedPrice = new string(priceChars);

            return modifiedPrice;
        }
        public void DisplayProduct(int index, bool hidePrice, ConsoleColor textColor = ConsoleColor.White)
        {
            if (textColor != ConsoleColor.Green && textColor != ConsoleColor.Red)
            {
                textColor = Console.ForegroundColor;
            }
            else
            {
                Console.ForegroundColor = textColor;
            }

            string productName = myProductInfo[index].GetProductName();
            string retailer = myProductInfo[index].GetRetailerName();
            string price = $"{myProductInfo[index].GetPrice().ToString("C2")}";
            if (hidePrice)
            {
                price = ReplaceNumbersWithUnderscores(price);
            }
            int length = price.Length;

            int productLength = -1;
            if (productName.Length < 42)
            {
                productLength = productName.Length;
            }
            else
            {
                productLength = 42;
            }
            string shortName = productName.Substring(0, productLength);
            if (productName.Length > 42)
            {
                shortName += "...";
            }

            if (price.Length % 2 != 0)
            {
                price += " ";
            }
            int halfway = (shortName.Length / 2);
            char[] nameCheck = shortName.ToCharArray();
            while (!Char.IsWhiteSpace(nameCheck[halfway]))
            {
                halfway += 1;
            }
            int nameLength = shortName.Length;
            string name1 = shortName.Substring(0, halfway);
            string name2 = shortName.Substring(halfway, (nameLength - halfway));
            if (name1.Length % 2 != 0)
            {
                name1 += " ";
            }
            if (name2.Length % 2 != 0)
            {
                name2 += " ";
            }
            if (retailer.Length % 2 != 0)
            {
                retailer += " ";
            }
            string nameSpacer1 = new string(' ', (16 - (name1.Length / 2)));
            string nameSpacer2 = new string(' ', (16 - (name2.Length / 2)));
            string retailSpacer = new string(' ', (16 - (retailer.Length / 2)));
            string priceSpacer = new string(' ', (16 - (price.Length / 2)));
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│             ITEM LISTING             │");
            Console.WriteLine("├──────────────────────────────────────┤");
            Console.WriteLine("│                NAME:                 │");
            Console.WriteLine("│  ┌────────────────────────────────┐  │");
            Console.WriteLine($"│  │{nameSpacer1}{name1}{nameSpacer1}│  │");
            Console.WriteLine($"│  │{nameSpacer2}{name2}{nameSpacer2}│  │");
            Console.WriteLine("│  └────────────────────────────────┘  │");
            Console.WriteLine("│                STORE:                │");
            Console.WriteLine("│  ┌────────────────────────────────┐  │");
            Console.WriteLine($"│  │{retailSpacer}{retailer}{retailSpacer}│  │");
            Console.WriteLine("│  └────────────────────────────────┘  │");
            Console.WriteLine("│            CURRENT PRICE:            │");
            Console.WriteLine("│  ┌────────────────────────────────┐  │");
            Console.WriteLine($"│  │{priceSpacer}{price}{priceSpacer}│  │");
            Console.WriteLine("│  └────────────────────────────────┘  │");
            Console.WriteLine("└──────────────────────────────────────┘");

            Console.ResetColor();
        }




        public void DisplaySelectedProducts(int index, bool hidePrice, StumpMe[] stumpMe, ConsoleColor textColor = ConsoleColor.White)
        {
            if (textColor != ConsoleColor.Green && textColor != ConsoleColor.Red)
            {
                textColor = Console.ForegroundColor;
            }
            else
            {
                Console.ForegroundColor = textColor;
            }

            string productName = stumpMe[index].GetProductName();
            string retailer = stumpMe[index].GetRetailerName();
            string price = $"{stumpMe[index].GetPrice().ToString("C2")}";
            if (hidePrice)
            {
                price = ReplaceNumbersWithUnderscores(price);
            }
            int length = price.Length;

            int productLength = -1;
            if (productName.Length < 42)
            {
                productLength = productName.Length;
            }
            else
            {
                productLength = 42;
            }
            string shortName = productName.Substring(0, productLength);
            if (productName.Length > 42)
            {
                shortName += "...";
            }

            if (price.Length % 2 != 0)
            {
                price += " ";
            }
            int halfway = (shortName.Length / 2);
            char[] nameCheck = shortName.ToCharArray();
            while (!Char.IsWhiteSpace(nameCheck[halfway]))
            {
                halfway += 1;
            }
            int nameLength = shortName.Length;
            string name1 = shortName.Substring(0, halfway);
            string name2 = shortName.Substring(halfway, (nameLength - halfway));
            if (name1.Length % 2 != 0)
            {
                name1 += " ";
            }
            if (name2.Length % 2 != 0)
            {
                name2 += " ";
            }
            if (retailer.Length % 2 != 0)
            {
                retailer += " ";
            }
            string nameSpacer1 = new string(' ', (16 - (name1.Length / 2)));
            string nameSpacer2 = new string(' ', (16 - (name2.Length / 2)));
            string retailSpacer = new string(' ', (16 - (retailer.Length / 2)));
            string priceSpacer = new string(' ', (16 - (price.Length / 2)));
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│             ITEM LISTING             │");
            Console.WriteLine("├──────────────────────────────────────┤");
            Console.WriteLine("│                NAME:                 │");
            Console.WriteLine("│  ┌────────────────────────────────┐  │");
            Console.WriteLine($"│  │{nameSpacer1}{name1}{nameSpacer1}│  │");
            Console.WriteLine($"│  │{nameSpacer2}{name2}{nameSpacer2}│  │");
            Console.WriteLine("│  └────────────────────────────────┘  │");
            Console.WriteLine("│                STORE:                │");
            Console.WriteLine("│  ┌────────────────────────────────┐  │");
            Console.WriteLine($"│  │{retailSpacer}{retailer}{retailSpacer}│  │");
            Console.WriteLine("│  └────────────────────────────────┘  │");
            Console.WriteLine("│            CURRENT PRICE:            │");
            Console.WriteLine("│  ┌────────────────────────────────┐  │");
            Console.WriteLine($"│  │{priceSpacer}{price}{priceSpacer}│  │");
            Console.WriteLine("│  └────────────────────────────────┘  │");
            Console.WriteLine("└──────────────────────────────────────┘");

            Console.ResetColor();
        }


        public async Task SearchProducts(string query, string retailerCode, int numResults)
        {
            string apiUrl = "";
            string apiKey = "f779ded78db1bf3c1d8bcc4ee72fe0ccf710dd106b13b6e29cee319f81d7b4c9";
            ProductInfo.ClearAllProductInfo();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    if (retailerCode != "-1")
                    {
                        apiUrl = $"https://serpapi.com/search.json?engine=google_shopping&q={query}&tbs=mr:1,merchagg:{retailerCode}&api_key={apiKey}";
                    }
                    else
                    {
                        apiUrl = $"https://serpapi.com/search.json?engine=google_shopping&q={query}&api_key={apiKey}";
                    }
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(jsonResponse);

                        var shoppingResults = data["shopping_results"];

                        if (shoppingResults != null)
                        {
                            for (int i = 0; i < numResults; i++)
                            {
                                var resultDetails = shoppingResults[i];

                                if (resultDetails != null)
                                {
                                    string productName = resultDetails["title"]?.ToString() ?? "N/A";
                                    string retailerName = resultDetails["source"]?.ToString() ?? "N/A";
                                    string price = resultDetails["price"]?.ToString() ?? "N/A";

                                    double priceDouble = double.Parse(price.Substring(1));

                                    ProductInfo newProduct = new ProductInfo(productName, retailerName, priceDouble);
                                    productInfoUtility.AddProduct(newProduct);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        public async Task<double> ReturnPrice(string itemName, string retailerCode)
        {
            string apiUrl = "";
            string apiKey = "f779ded78db1bf3c1d8bcc4ee72fe0ccf710dd106b13b6e29cee319f81d7b4c9";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    apiUrl = $"https://serpapi.com/search.json?engine=google_shopping&q={itemName}&tbs=mr:1,merchagg:{retailerCode}&api_key={apiKey}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(jsonResponse);

                        var shoppingResults = data["shopping_results"];

                        if (shoppingResults != null)
                        {
                            var resultDetails = shoppingResults[0];

                            if (resultDetails != null)
                            {
                                string price = resultDetails["price"]?.ToString() ?? "N/A";
                                return double.Parse(price.Substring(1));
                            }
                            else
                            {
                                return -1.00;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return -1.00;

        }





    }
}