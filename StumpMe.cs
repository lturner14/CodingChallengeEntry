using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS_Coding_Challenge
{
    public class StumpMe
    {
        private string productName;
        private string retailerName;
        private double Price;
        private int userNum;
        private static int count;

        public StumpMe(string productName, string retailerName, double Price, int userNum)
        {
            this.productName = productName;
            this.retailerName = retailerName;
            this.Price = Price;
            this.userNum = userNum;
        }

        public string GetProductName()
        {
            return productName;
        }

        public void SetProductName(string productName)
        {
            this.productName = productName;
        }
        public string GetRetailerName()
        {
            return retailerName;
        }

        public void SetRetailerName(string retailerName)
        {
            this.retailerName = retailerName;
        }

        public double GetPrice()
        {
            return Price;
        }

        public void SetPrice(double Price)
        {
            this.Price = Price;
        }

        public int GetUserNum()
        {
            return userNum;
        }

        public void SetUserNum(int userNum)
        {
            this.userNum = userNum;
        }

        public static int GetCount()
        {
            return count;
        }
        public static void ClearAllProductInfo()
        {
            count = 0;
        }
        public static void SetCount(int count)
        {
            StumpMe.count = count;
        }
        public static void IncCount()
        {
            count++;
        }
        public override string ToString()
        {
            return $"{productName}\t{retailerName}\t{Price}\t{userNum}";
        }
        public string ToFile()
        {
            return $"{productName}#{retailerName}#{Price}#{userNum}";
        }
    }
}