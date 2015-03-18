using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{

        [Test()]
        public void TestThatFlightInitializes()
        {
            DateTime DateFlightLeaves = new DateTime(2015, 3, 18);
            DateTime DateFlightReturns = new DateTime(2015, 4, 2);
            int MilesFlightTravels = 2000;
            var target = new Flight(DateFlightLeaves, DateFlightReturns, MilesFlightTravels);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceFor7DayVacation()
        {
            DateTime DateFlightLeaves = new DateTime(2015, 6, 3);
            DateTime DateFlightReturns = new DateTime(2015, 6, 10);
            int MilesFlightTravels = 500;
            var target = new Flight(DateFlightLeaves, DateFlightReturns, MilesFlightTravels);
            Assert.AreEqual(340, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnEndBeforeStart()
        {
            DateTime DateFlightLeaves = new DateTime(2015, 2, 15);
            DateTime DateFlightReturns = new DateTime(2015, 2, 1);
            int MilesFlightTravels = 500;
            var target = new Flight(DateFlightLeaves, DateFlightReturns, MilesFlightTravels);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnNegativeFlightMiles()
        {
            DateTime DateFlightLeaves = new DateTime(2015, 1, 1);
            DateTime DateFlightReturns = new DateTime(2015, 1, 10);
            int MilesFlightTravels = -10;
            var target = new Flight(DateFlightLeaves, DateFlightReturns, MilesFlightTravels);
        }

        [Test()]
        public void TestThatFlightIsEqualToItself()
        {
            DateTime DateFlightLeaves = new DateTime(2015, 4, 7);
            DateTime DateFlightReturns = new DateTime(2015, 4, 10);
            int MilesFlightTravels = 250;
            var target = new Flight(DateFlightLeaves, DateFlightReturns, MilesFlightTravels);
            Assert.IsTrue(target.Equals(target));
        }

        [Test()]
        public void TestThatTwoSameFlightsAreCorrectlyEqual()
        {
            DateTime DateFlightLeaves1 = new DateTime(2015, 5, 12);
            DateTime DateFlightReturns1 = new DateTime(2015, 5, 14);
            int MilesFlightTravels1 = 200;
            var target1 = new Flight(DateFlightLeaves1, DateFlightReturns1, MilesFlightTravels1);

            DateTime DateFlightLeaves2 = new DateTime(2015, 5, 12);
            DateTime DateFlightReturns2 = new DateTime(2015, 5, 14);
            int MilesFlightTravels2 = 200;
            var target2 = new Flight(DateFlightLeaves2, DateFlightReturns2, MilesFlightTravels2);
            Assert.IsTrue(target1.Equals(target2));
        }

        [Test()]
        public void TestThatTwoDifferentFlightsAreCorrectlyNotEqual()
        {
            DateTime DateFlightLeaves1 = new DateTime(2015, 7, 6);
            DateTime DateFlightReturns1 = new DateTime(2015, 8, 14);
            int MilesFlightTravels1 = 200;
            var target1 = new Flight(DateFlightLeaves1, DateFlightReturns1, MilesFlightTravels1);

            DateTime DateFlightLeaves2 = new DateTime(2015, 9, 2);
            DateTime DateFlightReturns2 = new DateTime(2015, 9, 13);
            int MilesFlightTravels2 = 400;
            var target2 = new Flight(DateFlightLeaves2, DateFlightReturns2, MilesFlightTravels2);
            Assert.IsFalse(target1.Equals(target2));
        }
	}
}
