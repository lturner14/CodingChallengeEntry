using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS_Coding_Challenge
{
    public class ProductInfo
    {
        private string productName;
        private string retailerName;
        private double Price;
        private static int count;

        public ProductInfo(string productName, string retailerName, double Price)
        {
            this.productName = productName;
            this.retailerName = retailerName;
            this.Price = Price;
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
            ProductInfo.count = count;
        }
        public static void IncCount()
        {
            count++;
        }
        public override string ToString()
        {
            return $"{productName}\t{retailerName}\t{Price}";
        }
        public string ToFile()
        {
            return $"{productName}#{retailerName}#{Price}";
        }
    }
}