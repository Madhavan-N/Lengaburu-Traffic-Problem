using Lengaburu_Traffic_Problem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Lengaburu_Traffic_Problem_Test
{
	[TestClass]
	public class OrbitTest
	{
		[TestMethod]
		public void shouldUpdateNumberOfCraterDependingOnWeather()
		{
			Orbit orbit = new Orbit() { numberOfCraters = 10 };
			var increasePercentage = 0.10;
			var expectedValue = 11;
			Mock<Weather> weather = new Mock<Weather>(MockBehavior.Strict);
			weather.Setup(_ => _.weatherDamagePercantageOnCrater()).Returns(increasePercentage);
			var actualValue = orbit.getCratersOnOrbit(weather.Object);
			Assert.AreEqual(expectedValue, actualValue);
		}

		[TestMethod]
		public void shouldIncreaseNumberOfCraterWithPositiveDamageValue()
		{
			Orbit orbit = new Orbit() { numberOfCraters = 20 };
			var percentage = 0.10;
			var expectedValue = 22;
			Mock<Weather> weather = new Mock<Weather>(MockBehavior.Strict);
			weather.Setup(_ => _.weatherDamagePercantageOnCrater()).Returns(percentage);
			var actualValue = orbit.getCratersOnOrbit(weather.Object);
			Assert.AreEqual(expectedValue, actualValue);
		}

		[TestMethod]
		public void shouldDecreaseNumberOfCraterDependingOnWeatherNegativeDamageValue()
		{
			Orbit orbit = new Orbit() { numberOfCraters = 10 };
			var percentage = -0.10;
			var expectedValue = 9;
			Mock<Weather> weather = new Mock<Weather>(MockBehavior.Strict);
			weather.Setup(_ => _.weatherDamagePercantageOnCrater()).Returns(percentage);
			var actualValue = orbit.getCratersOnOrbit(weather.Object);
			Assert.AreEqual(expectedValue, actualValue);
		}
		[TestMethod]
		public void shouldNotUpdateNumberOfCraterIfWeatherHasZeroDamage()
		{
			Orbit orbit = new Orbit() { numberOfCraters = 10 };
			var percentage = 0;
			var expectedValue = 10;
			Mock<Weather> weather = new Mock<Weather>(MockBehavior.Strict);
			weather.Setup(_ => _.weatherDamagePercantageOnCrater()).Returns(percentage);
			var actualValue = orbit.getCratersOnOrbit(weather.Object);
			Assert.AreEqual(expectedValue, actualValue);
		}
	}
}
