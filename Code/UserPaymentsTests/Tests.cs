using NUnit.Framework;
using System;
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
            var shoppingCart = new ShoppingCart();
            var product = new Product("DOV01", "Dove Soap", 39.99);

            Assert.AreEqual(39.99, product.Price, "Initial product state must reflect what's passed in the constructor");
            Assert.AreEqual("Dove Soap", product.Title, "Initial product state must reflect what's passed in the constructor");
            Assert.AreEqual("DOV01", product.Code, "Initial product state must reflect what's passed in the constructor");
        }

        [Test]
        public void Step1_Add_Single_DoveSoap_Calculates_Correct_ShoppingCart_TaxExcludedTotal()
        {
            var shoppingCart = new ShoppingCart();
            var product = new Product("DOV01", "Dove Soap", 39.99);
            shoppingCart.AddProduct(product);

            Assert.AreEqual(39.99, shoppingCart.TaxExcludedTotal, "When a single item is added to the cart, the tax exclusive total should reflect the item price.");
            Assert.AreEqual(39.99, shoppingCart.TaxExcludedTotal, "When a single item is added to the cart, the tax exclusive total should reflect the item price.");
        }

        [Test]
        public void Step1_Add_Five_DoveSoaps_Calculates_Correct_ShoppingCart_TaxExcludedTotal()
        {
            var shoppingCart = new ShoppingCart();

            shoppingCart.AddProduct(Helper.CreateDoveSoap());
            shoppingCart.AddProduct(Helper.CreateDoveSoap());
            shoppingCart.AddProduct(Helper.CreateDoveSoap());
            shoppingCart.AddProduct(Helper.CreateDoveSoap());
            shoppingCart.AddProduct(Helper.CreateDoveSoap());

            Assert.AreEqual(199.95, shoppingCart.TaxExcludedTotal, "When multiple items are added to the cart, the cart should reflect the correct tax exclusive total.");
        }

        [Test]
        public void Step2_Add_Five_DoveSoaps_Calculates_Correct_ShoppingCart_TaxExcludedTotal()
        {
            var shoppingCart = new ShoppingCart();

            shoppingCart.AddProduct(Helper.CreateDoveSoap());
            shoppingCart.AddProduct(Helper.CreateDoveSoap());
            shoppingCart.AddProduct(Helper.CreateDoveSoap());
            shoppingCart.AddProduct(Helper.CreateDoveSoap());
            shoppingCart.AddProduct(Helper.CreateDoveSoap());

            Assert.AreEqual(199.95, shoppingCart.TaxExcludedTotal, "When multiple items are added to the cart, the cart should reflect the correct tax exclusive total.");
        }

        [Test]
        public void Step2_Add_DoveSoaps_AsRange_Calculates_Correct_ShoppingCart_TaxExcludedTotal_And_NoOfProducts()
        {
            var shoppingCart = new ShoppingCart();
            var fiveDoveSoaps = Helper.CreateManyDoveSoapProducts(5);
            var threeDoveSoaps = Helper.CreateManyDoveSoapProducts(3);

            foreach (Product product in fiveDoveSoaps)
                shoppingCart.AddProduct(product);

            foreach (Product product in threeDoveSoaps)
                shoppingCart.AddProduct(product);

            Assert.AreEqual(5, fiveDoveSoaps.Count());
            Assert.AreEqual(3, threeDoveSoaps.Count());

            Assert.AreEqual(319.92, shoppingCart.TaxExcludedTotal, "When multiple items are added to the cart, the cart should reflect the correct tax exclusive total.");
            Assert.AreEqual(8, shoppingCart.ProductCount, "When multiple items are added to the cart, the cart shold reflect the correct number of items.");
        }

        [Test]
        public void Step3_Add_Products_AsRange_Calculates_Correct_ShoppingCart_TotalTax()
        {
            var shoppingCart = new ShoppingCart();
            var twoDoveSoaps = Helper.CreateManyDoveSoapProducts(2);
            var twoAxeDeos = Helper.CreateManyAxeDeoProducts(2);

            foreach (Product product in twoDoveSoaps)
                shoppingCart.AddProduct(product);

            foreach (Product product in twoAxeDeos)
                shoppingCart.AddProduct(product);

            Assert.AreEqual(2, twoDoveSoaps.Count());
            Assert.AreEqual(2, twoAxeDeos.Count());

            Assert.AreEqual(35.00, shoppingCart.TotalTax, "When multiple items are added to the cart, the cart should reflect the correct total tax.");
        }

        [Test]
        public void Step3_Add_Products_AsRange_Calculates_Correct_ShoppingCart_TaxIncludedTotal()
        {
            var shoppingCart = new ShoppingCart();
            var twoDoveSoaps = Helper.CreateManyDoveSoapProducts(2);
            var twoAxeDeos = Helper.CreateManyAxeDeoProducts(2);

            foreach (Product product in twoDoveSoaps)
                shoppingCart.AddProduct(product);

            foreach (Product product in twoAxeDeos)
                shoppingCart.AddProduct(product);

            Assert.AreEqual(2, twoDoveSoaps.Count());
            Assert.AreEqual(2, twoAxeDeos.Count());

            Assert.AreEqual(314.96, shoppingCart.TaxIncludedTotal, "When multiple items are added to the cart, the cart should reflect the correct total tax inclusive total.");
        }

        [Test]
        public void Step3_With_No_Products_Calculates_Correct_ShoppingCart_TaxIncludedTotal()
        {
            var shoppingCart = new ShoppingCart();
            IEnumerable<Product> twoDoveSoaps = Helper.CreateManyDoveSoapProducts(2);
            IEnumerable<Product> twoAxeDeos = Helper.CreateManyAxeDeoProducts(2);

            foreach (Product product in twoDoveSoaps)
                shoppingCart.AddProduct(product);

            foreach (Product product in twoAxeDeos)
                shoppingCart.AddProduct(product);

            Assert.AreEqual(2, twoDoveSoaps.Count());
            Assert.AreEqual(2, twoAxeDeos.Count());

            Assert.AreEqual(314.96, shoppingCart.TaxIncludedTotal, "When multiple items are added to the cart, the cart should reflect the correct total tax inclusive total.");
        }

        [Test]
        public void Step3_Add_Products_AsRange_Calculates_Correct_Product_Counts_Given_A_ProductCode()
        {
            var shoppingCart = new ShoppingCart();
            IEnumerable<Product> twoDoveSoaps = Helper.CreateManyDoveSoapProducts(2);
            IEnumerable<Product> twoAxeDeos = Helper.CreateManyAxeDeoProducts(2);

            foreach (Product product in twoDoveSoaps)
                shoppingCart.AddProduct(product);

            foreach (Product product in twoAxeDeos)
                shoppingCart.AddProduct(product);

            Assert.AreEqual(2, shoppingCart.ProductByCodeCount(Helper.CreateDoveSoap()), "When multiple items of different types are added to the shopping cart, the cart correctly calculated the number of existing products with a given code.");
            Assert.AreEqual(2, shoppingCart.ProductByCodeCount(Helper.CreateAxeDeo()), "When multiple items of different types are added to the shopping cart, the cart correctly calculated the number of existing products with a given code.");
        }

        [Test]
        public void Step3_Add_Products_AsRange_Calculates_Correct_Product_UnitPrice_Given_A_ProductCode()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            IEnumerable<Product> twoDoveSoaps = Helper.CreateManyDoveSoapProducts(2);
            IEnumerable<Product> twoAxeDeos = Helper.CreateManyAxeDeoProducts(2);

            foreach (Product product in twoDoveSoaps)
                shoppingCart.AddProduct(product);

            foreach (Product product in twoAxeDeos)
                shoppingCart.AddProduct(product);

            Assert.AreEqual(39.99, shoppingCart.ProductByCodeUnitPrice(Helper.CreateDoveSoap()), "When multiple items of different types are added to the shopping cart, the cart correctly calculated the unit price of a product with a given code.");
            Assert.AreEqual(99.99, shoppingCart.ProductByCodeUnitPrice(Helper.CreateAxeDeo()), "When multiple items of different types are added to the shopping cart, the cart correctly calculated the unit price of a product with a given code.");
        }

        [Test]
        public void Step3_NoProducts_Added_Calculates_0_Product_Count_Given_A_ProductCode()
        {
            var shoppingCart = new ShoppingCart();

            Assert.AreEqual(0, shoppingCart.ProductByCodeCount(Helper.CreateDoveSoap()), "When multiple items of different types are added to the shopping cart, the cart correctly calculated the unit price of a product with a given code.");
            Assert.AreEqual(0, shoppingCart.ProductByCodeCount(Helper.CreateAxeDeo()), "When multiple items of different types are added to the shopping cart, the cart correctly calculated the unit price of a product with a given code.");
        }

        [Test]
        public void Step3_NoProducts_Added_Calculates_0_Product_UnitPrice_Given_A_ProductCode()
        {
            var shoppingCart = new ShoppingCart();

            Assert.AreEqual(0, shoppingCart.ProductByCodeUnitPrice(Helper.CreateDoveSoap()), "When multiple items of different types are added to the shopping cart, the cart correctly calculated the unit price of a product with a given code.");
            Assert.AreEqual(0, shoppingCart.ProductByCodeUnitPrice(Helper.CreateAxeDeo()), "When multiple items of different types are added to the shopping cart, the cart correctly calculated the unit price of a product with a given code.");
        }

        [Test]
        public void Adding_A_Null_Product_To_ShoppingCart_Must_Raise_Exception()
        {
            var shoppingCart = new ShoppingCart();

            TestDelegate proc = () => shoppingCart.AddProduct(null);
            Assert.That(proc, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Adding_A_Null_OrEmpty_Code_To_Product_Constructor_Must_Raise_Exception()
        {
            TestDelegate nullTest = () => new Product(null, "Test Title", 20.00);
            Assert.That(nullTest, Throws.TypeOf<ArgumentNullException>());

            TestDelegate emptyTest = () => new Product("", "Test Title", 20.00);
            Assert.That(emptyTest, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void A_Product_Equals_Another_Product()
        {
            var product1 = new Product("PR001", "Title", 39.99);
            var product2 = new Product("PR001", "Title", 39.99);

            Assert.AreEqual(product1, product2);
        }
    }
}
