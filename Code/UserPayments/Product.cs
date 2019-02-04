using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPayments
{
    public sealed class Product : IEquatable<Product>
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

        public override int GetHashCode()
        {
            return Price.GetHashCode() ^ Title.GetHashCode() ^ Code.GetHashCode();
        }

        public bool Equals(Product other)
        {
            return Price == other.Price && Title == other.Title && Code == other.Code;
        }
    }
}
