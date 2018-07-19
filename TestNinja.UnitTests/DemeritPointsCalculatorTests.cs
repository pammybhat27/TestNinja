using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests {
    [TestFixture]


   public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;


        [SetUp]
        public void SetUp()
        {
             _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        public void calculateDemeritPoints_SpeedLessThanZero_ThrowArgumentOutofRangeException()
        {
            //Arrange
        

           // int intResult = demeritPointsCalculator.CalculateDemeritPoints(-1);
            Assert.That(()=> _demeritPointsCalculator.CalculateDemeritPoints(-1),Throws.TypeOf(typeof(ArgumentOutOfRangeException)));


        }


        [Test]
        public void calculateDemeritPoints_SpeedMoreThan300_ThrowArgumentOutofRangeException()
        {
            //Arrange
            

            // int intResult = demeritPointsCalculator.CalculateDemeritPoints(-1);
            Assert.That(()=> _demeritPointsCalculator.CalculateDemeritPoints(301),Throws.TypeOf(typeof(ArgumentOutOfRangeException)));

        }

        [Test]
        [TestCase(65,0)]
        [TestCase(70,1)]
        [TestCase(75,2)]
        public void calculateDemeritPoints_SpeedInput_ReturnsDemeritPoints(int speed,int expectedDemeritPoints)
        {
            //Arrange
   
            
            //Act
             int intResult = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.That(intResult,Is.EqualTo(expectedDemeritPoints));
                

        }

       


    }
}
