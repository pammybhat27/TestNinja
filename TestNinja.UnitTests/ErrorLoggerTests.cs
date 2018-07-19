using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests {
    [TestFixture]
    public class ErrorLoggerTests {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty() {
            var logger = new ErrorLogger();
            //We cannot check for the result in
            //this case as it is a command execution
            //and not a query variable
            //So we set the last error value and then check if the last error value
            //is what we have entered
            logger.Log("a");
            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger =  new ErrorLogger();

            //logger.Log(error);
            Assert.That(()=> logger.Log(error),Throws.ArgumentNullException);

        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger =  new ErrorLogger();
            var id = Guid.Empty;
            //logger.Log(error);

            //To write test for methods that raise events, subscribe to the 
            //event, and then pass the id 
            //This makes sure if there is an event subscribed , the test passes else it fails
            logger.ErrorLogged += (sender, args) => { id = args; };
            logger.Log("a");
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));

        }

    }
}
