using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPayments
{
    public class Product
    {
        public double Price { get; }
        public string Title { get; }
        public string Code { get; }

        public Product(string code, string title, double price)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("Code is a required field for a product's identity.");

            Title = title;
            Price = price;
            Code = code;
        }
    }
}
