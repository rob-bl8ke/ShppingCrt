
using System;
using System.Collections.Generic;
using System.Linq;

namespace UserPayments
{
    public class ShoppingCart
    {
        private List<Product> products = new List<Product>();

        public double TaxExcludedTotal { get => Math.Round(products.Sum(p => p.Price), 2); }

        public double TaxIncludedTotal { get => Math.Round(TaxExcludedTotal + TotalTax, 2); }

        public double TotalTax { get => Math.Round(TaxExcludedTotal * .125); }

        public double ProductCount { get => products.Count; }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("A null product cannot be added to the Shopping Cart.");

            products.Add(product);
        }

        public double ProductByCodeCount(string code)
        {
            var productTypes = products.GroupBy(p => p.Code);
            var productType = productTypes.Where(p => p.Key == code).SingleOrDefault();

            if (productType != null)
                return productType.Count();

            return 0;
        }

        public double ProductByCodeUnitPrice(string code)
        {
            var productTypes = products.GroupBy(p => p.Code);

            if (productTypes.Where(p => p.Key == code).Any())
            {
                var product = productTypes.Where(p => p.Key == code).SingleOrDefault().FirstOrDefault();

                if (product != null)
                    return product.Price;
            }

            return 0;
        }
    }
}
