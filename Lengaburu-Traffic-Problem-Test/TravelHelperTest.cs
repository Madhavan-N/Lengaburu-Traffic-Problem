using Lengaburu_Traffic_Problem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Lengaburu_Traffic_Problem_Test
{
	[TestClass]
	public class TravelHelperTest
	{
		Orbit orbit1 = new Orbit("orbit 1", 10, 10, 10);
		Orbit orbit2 = new Orbit("orbit 2", 10, 10, 10);
		[TestMethod]
		public void shouldChooseBikeOverSupercarIfTravelTimeIsSame()
		{
			Mock<Vehicle> bikeMock = new Mock<Vehicle>(MockBehavior.Strict);
			bikeMock.Setup(_=>_.getPriority()).Returns(1);
			bikeMock.Setup(_ => _.getVehicleType()).Returns(VehicleType.Bike);
			bikeMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(true);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit1.getDescription()), It.IsAny<Weather>()))
				.Returns(2);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit2.getDescription()), It.IsAny<Weather>()))
				.Returns(5.5);
			bikeMock.Setup(_ => _.ToString()).Returns(bikeMock.Object.getVehicleType().ToString());

			Mock<Vehicle> superCarMock = new Mock<Vehicle>(MockBehavior.Strict);
			superCarMock.Setup(_=>_.getPriority()).Returns(3);
			superCarMock.Setup(_ => _.getVehicleType()).Returns(VehicleType.SuperCar);
			superCarMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(true);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit1.getDescription()), It.IsAny<Weather>()))
				.Returns(2);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit2.getDescription()), It.IsAny<Weather>()))
				.Returns(5.4);
			superCarMock.Setup(_ => _.ToString()).Returns(superCarMock.Object.getVehicleType().ToString());

			var helper = new TravelHelper(new Orbit[] { orbit1, orbit2 }, new Vehicle[] { bikeMock.Object, superCarMock.Object }, WeatherType.Rainy);
			var expectedOutput = "Vehicle " + bikeMock.Object.getVehicleType().ToString() + " on " + orbit1.getDescription();
			var shortestTrip = helper.getTripWithShortestTravelTime();
			Assert.AreEqual(expectedOutput, shortestTrip.ToString());
		}

		[TestMethod]
		public void shouldGetOrbitAndVehicleWithShortestTravelTime()
		{
			IDictionary<Orbit, Vehicle> vehicles = new Dictionary<Orbit, Vehicle>();

			Mock<Vehicle> bikeMock = new Mock<Vehicle>(MockBehavior.Strict);
			bikeMock.Setup(_ => _.getVehicleType()).Returns(VehicleType.Bike);
			bikeMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(true);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit1.getDescription()), It.IsAny<Weather>()))
				.Returns(2);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit2.getDescription()), It.IsAny<Weather>()))
				.Returns(1.5);
			bikeMock.Setup(_ => _.ToString()).Returns(bikeMock.Object.getVehicleType().ToString());

			Mock<Vehicle> superCarMock = new Mock<Vehicle>(MockBehavior.Strict);
			superCarMock.Setup(_ => _.getVehicleType()).Returns(VehicleType.SuperCar);
			superCarMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(true);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit1.getDescription()), It.IsAny<Weather>()))
				.Returns(1.7);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit2.getDescription()), It.IsAny<Weather>()))
				.Returns(1.4);
			superCarMock.Setup(_ => _.ToString()).Returns(superCarMock.Object.getVehicleType().ToString());

			var helper = new TravelHelper(new Orbit[] { orbit1, orbit2 },
				new Vehicle[] { bikeMock.Object, superCarMock.Object },
				WeatherType.Rainy);
			var expectedOutput = "Vehicle " + superCarMock.Object.getVehicleType().ToString() + " on " + orbit2.getDescription();

			var shortestTrip = helper.getTripWithShortestTravelTime();
			Assert.AreEqual(expectedOutput, shortestTrip.ToString());
		}

		[TestMethod]
		public void shouldGetOrbitAndVehicleWithShortestTravelTimeSuitableToWeather()
		{
			Mock<Vehicle> bikeMock = new Mock<Vehicle>(MockBehavior.Strict);
			bikeMock.Setup(_ => _.getVehicleType()).Returns( VehicleType.Bike);
			bikeMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(true);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit1.getDescription()), It.IsAny<Weather>()))
				.Returns(2);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit2.getDescription()), It.IsAny<Weather>()))
				.Returns(1.5);
			bikeMock.Setup(_ => _.ToString()).Returns(bikeMock.Object.getVehicleType().ToString());

			Mock<Vehicle> superCarMock = new Mock<Vehicle>(MockBehavior.Strict);
			superCarMock.Setup(_ => _.getVehicleType()).Returns(VehicleType.SuperCar);
			superCarMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(false);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit1.getDescription()), It.IsAny<Weather>()))
				.Returns(1.7);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.getDescription() == orbit2.getDescription()), It.IsAny<Weather>()))
				.Returns(1.4);
			superCarMock.Setup(_ => _.ToString()).Returns(superCarMock.Object.getVehicleType().ToString());

			var helper = new TravelHelper(new Orbit[] { orbit1, orbit2 },
				new Vehicle[] { bikeMock.Object, superCarMock.Object },
				WeatherType.Rainy);
			var expectedOutput = "Vehicle " + bikeMock.Object.getVehicleType().ToString() + " on " + orbit2.getDescription();

			var shortestTrip = helper.getTripWithShortestTravelTime();
			Assert.AreEqual(expectedOutput, shortestTrip.ToString());
		}

	}
}
