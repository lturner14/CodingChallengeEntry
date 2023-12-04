using System;
using System.IO;

namespace MIS_Coding_Challenge
{
    public class ProductInfoUtility
    {
        private ProductInfo[] myProductInfo;

        public ProductInfoUtility(ProductInfo[] myProductInfo)
        {
            this.myProductInfo = myProductInfo;
        }

        public void AddProduct(ProductInfo newProduct)
        {
            myProductInfo[ProductInfo.GetCount()] = newProduct;

            ProductInfo.IncCount();
        }

    }
}
