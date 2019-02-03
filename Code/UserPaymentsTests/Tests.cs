using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UserPayments;

namespace UserPaymentsTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CreateProduct_WithConstructor_Initialises_State_Correctly()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            Product product = new Product("Dove Soap", 39.99);

            Assert.AreEqual(39.99, product.Price, "Initial product state must reflect what's passed in the constructor");
            Assert.AreEqual("Dove Soap", product.Title, "Initial product state must reflect what's passed in the constructor");
        }

        [Test]
        public void Step1_Add_Single_DoveSoap_Calculates_Correct_ShoppingCart_TaxExcludedTotal()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            Product product = new Product("Dove Soap", 39.99);
            shoppingCart.AddProduct(product);

            Assert.AreEqual(39.99, shoppingCart.TaxExcludedTotal, "When a single item is added to the cart, the total should reflect the item price.");
            Assert.AreEqual(39.99, shoppingCart.TaxExcludedTotal, "When a single item is added to the cart, the total should reflect the item price.");
        }

        [Test]
        public void Step1_Add_Five_DoveSoaps_Calculates_Correct_ShoppingCart_TaxExcludedTotal()
        {
            ShoppingCart shoppingCart = new ShoppingCart();

            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());

            Assert.AreEqual(199.95, shoppingCart.TaxExcludedTotal, "When multiple items are added to the cart, the cart should reflect the total of those values.");
        }

        [Test]
        public void Step2_Add_Five_DoveSoaps_Calculates_Correct_ShoppingCart_TaxExcludedTotal()
        {
            ShoppingCart shoppingCart = new ShoppingCart();

            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());

            Assert.AreEqual(199.95, shoppingCart.TaxExcludedTotal, "When multiple items are added to the cart, the cart should reflect the total of those values.");
        }

        [Test]
        public void Step2_Add_DoveSoaps_AsRange_Calculates_Correct_ShoppingCart_TaxExcludedTotal_And_NoOfProducts()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            IEnumerable<Product> fiveDoveSoaps = CreateManyDoveSoapProducts(5);
            IEnumerable<Product> threeDoveSoaps = CreateManyDoveSoapProducts(3);

            foreach (Product product in fiveDoveSoaps)
                shoppingCart.AddProduct(product);

            foreach (Product product in threeDoveSoaps)
                shoppingCart.AddProduct(product);

            Assert.AreEqual(5, fiveDoveSoaps.Count());
            Assert.AreEqual(3, threeDoveSoaps.Count());

            Assert.AreEqual(319.92, shoppingCart.TaxExcludedTotal, "When multiple items are added to the cart, the cart should reflect the total of those values.");
            Assert.AreEqual(8, shoppingCart.ProductCount, "When multiple items are added to the cart, the cart shold reflect the correct number of items.");
        }

        private Product CreateDoveSoap() => new Product("Dove Soap", 39.99);

        private IEnumerable<Product> CreateManyDoveSoapProducts(int num)
        {
            List<Product> products = new List<Product>();

            for (int x = 0; x < num; x++)
            {
                products.Add(CreateDoveSoap());
            }

            return products;
        }
    }
}
