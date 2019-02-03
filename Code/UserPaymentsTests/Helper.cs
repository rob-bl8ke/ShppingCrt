using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPayments;

namespace UserPaymentsTests
{
    public class Helper
    {
        public static Product CreateDoveSoap() => new Product("DOV01", "Dove Soap", 39.99);
        public static Product CreateAxeDeo() => new Product("AXE01", "Axe Deo", 99.99);

        public static IEnumerable<Product> CreateManyAxeDeoProducts(int num)
        {
            var products = new List<Product>();

            for (int x = 0; x < num; x++)
            {
                products.Add(CreateAxeDeo());
            }

            return products;
        }

        public static IEnumerable<Product> CreateManyDoveSoapProducts(int num)
        {
            var products = new List<Product>();

            for (int x = 0; x < num; x++)
            {
                products.Add(CreateDoveSoap());
            }

            return products;
        }
    }
}
