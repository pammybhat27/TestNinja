using System.Linq;
using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {

        private Math _math;

        //Setup
        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }

        [Test]
        //[Ignore("Becase i want to")]
        public void Add_WhenCalled_ReturnSumofArguments()
        {

            var result = _math.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnGreaterArgument(int a, int b, int expectedResult)
        {

            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_WhenCalledWithinLimit_ReturnOddNumbers()
        {
            //What I have
            //A method that returns an array of odd numbers for a specified limit
            //what i need to check if the array contains any mubers
            var result = _math.GetOddNumbers(5);

            //Assert.That(result,Is.Not.Empty);
            ////If 5 is entered as input, then it must return 3 values namely 1,3,5
            ////So the length of the result returned needs to be 3
            //Assert.That(result.Count(),Is.EqualTo(3));
            ////Check if it contains 1, 3 or 5
            //Assert.That(result,Does.Contain(1));
            //Assert.That(result,Does.Contain(3));
            //Assert.That(result,Does.Contain(5));

            //But all these are conditional checks, we need to see if it is specific
            //Check if all the items exist in the array
            Assert.That(result,Is.EquivalentTo(new [] {1,3,5}));



        }

    }
}
