using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests {
    [TestFixture]
    public class FizzBuzzTests {
        [Test]
        [TestCase(15,"FizzBuzz")]
        [TestCase(9,"Fizz")]
        [TestCase(20,"Buzz")]
        [TestCase(22,"22")]
        public void GetOutput_InputisDivisibleiveby3and5_ReturnsFizzBuzz(int a , string expectedOutput)
        {
            //It is already a static method so need to instantiate
            string result =  FizzBuzz.GetOutput(a);
            Assert.That(result,Is.EqualTo(expectedOutput));
        }

    
    }
}
