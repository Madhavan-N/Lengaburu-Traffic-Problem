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
			var orbit = new Orbit("orbit 1", 10, 0, 20);
			var vehicle = new Vehicle(VehicleType.Bike, 15, 2, new WeatherType[] { }, 1);

			var expectedOutput = 2;
			Assert.AreEqual(expectedOutput, vehicle.getTravelTime(orbit, new Weather()));
		}

		[TestMethod]
		public void shouldReturnTravelTimeWithMaxSpeedOfVehicleIfGreaterThanTrafficSpeed()
		{
			var orbit = new Orbit("orbit 1", 20, 0, 20);
			var vehicle = new Vehicle(VehicleType.Bike, 10, 2, new WeatherType[] { }, 1);

			var expectedOutput = 2;
			Assert.AreEqual(expectedOutput, vehicle.getTravelTime(orbit, new Weather()));
		}

		[TestMethod]
		public void shouldBeAbleToRideIfWeatherIsOntheSuitableWeatherType()
		{
			var weather = new Weather(WeatherType.Sunny);
			var vehicle = new Vehicle(VehicleType.Bike, 10, 2, new WeatherType[] { WeatherType.Sunny, WeatherType.Windy }, 1);
			var result = vehicle.canTravel(weather);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void shoulNotdBeAbleToRideIfWeatherIsNotOntheSuitableWeatherType()
		{
			var weather = new Weather(WeatherType.Sunny);
			var vehicle = new Vehicle(VehicleType.Bike, 10, 2, new WeatherType[] { WeatherType.Rainy, WeatherType.Windy }, 1);

			var result = vehicle.canTravel(weather);
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void shoulNotdBeAbleToRideIfSuitableWeatherTypeIsEmpty()
		{
			var weather = new Weather(WeatherType.Sunny);
			var vehicle = new Vehicle(VehicleType.Bike, 10, 2, new WeatherType[] { }, 1);

			var result = vehicle.canTravel(weather);
			Assert.IsFalse(result);
		}
	}
}
