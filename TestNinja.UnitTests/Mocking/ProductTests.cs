using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking {
    [TestFixture]
  public   class ProductTests {
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            //To get the price 
            //where do we get the price from
            //Product
            //Instantiate the product
            var productNewProduct = new Product();
            productNewProduct.ListPrice = 100;

            //What we need to check is for the get price that takes in customer object
            //Is gold property of the customer object
            //Whether it is true if it is 30 percent of the list price

            var customer = new Customer();
            customer.IsGold = true;

            var newresult = productNewProduct.GetPrice(customer);

            //var product = new Product {ListPrice = 100};

            //var result = product.GetPrice(new Customer {IsGold = true});

            Assert.That(newresult,Is.EqualTo(70));

        }

    }
}
