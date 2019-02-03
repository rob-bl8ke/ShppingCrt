using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPayments
{
    public class Product
    {
        public Product(string title, double price)
        {
            Title = title;
            Price = price;
        }

        public double Price { get; }
        public string Title { get; }
    }
}
