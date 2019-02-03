using NUnit.Framework;
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
        public void Step1_Add_Single_DoveSoap_Calculates_Correct_ShoppingCart_Total()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            Product product = new Product("Dove Soap", 39.99);
            shoppingCart.AddProduct(product);

            Assert.AreEqual(39.99, shoppingCart.Total, "When a single item is added to the cart, the total should reflect the item price.");
            Assert.AreEqual(39.99, shoppingCart.Total, "When a single item is added to the cart, the total should reflect the item price.");
        }

        [Test]
        public void Step1_Add_Five_DoveSoaps_Calculates_Correct_ShoppingCart_Total()
        {
            ShoppingCart shoppingCart = new ShoppingCart();

            //shoppingCart.AddProduct(CreateDoveSoap());

            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());
            shoppingCart.AddProduct(CreateDoveSoap());

            Assert.AreEqual(199.95, shoppingCart.Total, "When multiple items are added to the cart, the cart should reflect the total of those values.");
        }

        private Product CreateDoveSoap() => new Product("Dove Soap", 39.99);
    }
}
