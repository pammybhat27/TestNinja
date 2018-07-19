using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests {
    [TestFixture]
   public class CustomerControllerTests {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            //What this test checks
            //it checks if the customer id is zero, then throw an exception
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            Assert.That(result,Is.TypeOf<NotFound>());

            Assert.That(result,Is.InstanceOf<NotFound>());


        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {


        }
    }
}
