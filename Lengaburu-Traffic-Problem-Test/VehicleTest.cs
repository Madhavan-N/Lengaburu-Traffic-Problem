using Lengaburu_Traffic_Problem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lengaburu_Traffic_Problem_Test
{
	[TestClass]
	public class VehicleTest
	{
		[TestMethod]
		public void shouldReturnTravelTimeCappedByOrbitTrafficSpeed()
		{
			var orbit = new Orbit() { distance = 20, trafficSpeed = 10, numberOfCraters = 0 };
			var vehicle = new Vehicle() { maxSpeed = 15, timeToCrossOneCraterinMins = 2 };

			var expectedOutput = 2;
			Assert.AreEqual(expectedOutput, vehicle.getTravelTime(orbit, new Weather()));
		}

		[TestMethod]
		public void shouldReturnTravelTimeWithMaxSpeedOfVehicleIfGreaterThanTrafficSpeed()
		{
			var orbit = new Orbit() { distance = 20, trafficSpeed = 20, numberOfCraters = 0 };
			var vehicle = new Vehicle() { maxSpeed = 10, timeToCrossOneCraterinMins = 2 };

			var expectedOutput = 2;
			Assert.AreEqual(expectedOutput, vehicle.getTravelTime(orbit, new Weather()));
		}

		[TestMethod]
		public void shouldBeAbleToRideIfWeatherIsOntheSuitableWeatherType()
		{
			var weather = new Weather(WeatherType.Sunny);
			var vehicle = new Vehicle() { suitableWeatherTypes = new WeatherType[] { WeatherType.Sunny, WeatherType.Windy } };
			var result = vehicle.canTravel(weather);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void shoulNotdBeAbleToRideIfWeatherIsNotOntheSuitableWeatherType()
		{
			var weather = new Weather(WeatherType.Sunny);
			var vehicle = new Vehicle() { suitableWeatherTypes = new WeatherType[] { WeatherType.Rainy, WeatherType.Windy } };
			var result = vehicle.canTravel(weather);
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void shoulNotdBeAbleToRideIfSuitableWeatherTypeIsEmpty()
		{
			var weather = new Weather(WeatherType.Sunny);
			var vehicle = new Vehicle() { suitableWeatherTypes = new WeatherType[] { } };
			var result = vehicle.canTravel(weather);
			Assert.IsFalse(result);
		}
	}
}
