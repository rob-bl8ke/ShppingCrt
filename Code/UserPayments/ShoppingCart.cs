
using System;
using System.Collections.Generic;
using System.Linq;

namespace UserPayments
{
    public class ShoppingCart
    {
        private Dictionary<Product, int> productBaskets = new Dictionary<Product, int>();

        public double TaxExcludedTotal
        {
            get
            {
                double total = 0;
                foreach (var product in productBaskets.Keys)
                {
                    total += product.Price * (double)productBaskets[product];
                }
                return Math.Round(total, 2);
            }
        }

        public double TaxIncludedTotal { get => Math.Round(TaxExcludedTotal + TotalTax, 2); }

        public double TotalTax { get => Math.Round(TaxExcludedTotal * .125); }

        public double ProductCount
        {
            get
            {
                double total = 0;
                foreach (var product in productBaskets.Keys)
                {
                    total += productBaskets[product];
                }
                return total;
            }
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("A null product cannot be added to the Shopping Cart.");

            if (!productBaskets.ContainsKey(product))
                productBaskets.Add(product, 1);
            else
                productBaskets[product]++;
        }

        public double ProductByCodeCount(Product product)
        {
            if (productBaskets.ContainsKey(product))
                return productBaskets[product];
            return 0;
        }

        public double ProductByCodeUnitPrice(Product product)
        {
            if (productBaskets.ContainsKey(product))
                return product.Price;

            return 0;
        }
    }
}
