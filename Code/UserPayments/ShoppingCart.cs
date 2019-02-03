
using System;
using System.Collections.Generic;
using System.Linq;

namespace UserPayments
{
    public class ShoppingCart
    {
        private List<Product> products = new List<Product>();

        public double Total { get { return Math.Round(products.Sum(p => p.Price), 2); } }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
