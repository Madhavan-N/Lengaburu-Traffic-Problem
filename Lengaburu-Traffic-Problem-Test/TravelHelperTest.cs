using Lengaburu_Traffic_Problem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Lengaburu_Traffic_Problem_Test
{
	[TestClass]
	public class TravelHelperTest
	{
		[TestMethod]
		public void shouldChooseBikeOverSupercarIfTravelTimeIsSame()
		{
			var orbit1 = new Orbit() { description = "orbit 1" };
			var orbit2 = new Orbit() { description = "orbit 2" };


			Mock<Vehicle> bikeMock = new Mock<Vehicle>(MockBehavior.Strict);
			bikeMock.Object.priority = 1;
			bikeMock.Object.vehicleType = VehicleType.Bike;
			bikeMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(true);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit1.description), It.IsAny<Weather>()))
				.Returns(2);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit2.description), It.IsAny<Weather>()))
				.Returns(5.5);
			bikeMock.Setup(_ => _.ToString()).Returns(bikeMock.Object.vehicleType.ToString());

			Mock<Vehicle> superCarMock = new Mock<Vehicle>(MockBehavior.Strict);
			superCarMock.Object.priority = 3;
			superCarMock.Object.vehicleType = VehicleType.SuperCar;
			superCarMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(true);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit1.description), It.IsAny<Weather>()))
				.Returns(2);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit2.description), It.IsAny<Weather>()))
				.Returns(5.4);
			superCarMock.Setup(_ => _.ToString()).Returns(superCarMock.Object.vehicleType.ToString());

			var helper = new TravelHelper(new Orbit[] { orbit1, orbit2 }, new Vehicle[] { bikeMock.Object, superCarMock.Object }, WeatherType.Rainy);
			var expectedOutput = "Vehicle " + bikeMock.Object.vehicleType.ToString() + " on " + orbit1.description;
			var shortestTrip = helper.getTripWithShortestTravelTime();
			Assert.AreEqual(expectedOutput, shortestTrip.ToString());
		}

		[TestMethod]
		public void shouldGetOrbitAndVehicleWithShortestTravelTime()
		{
			IDictionary<Orbit, Vehicle> vehicles = new Dictionary<Orbit, Vehicle>();
			var orbit1 = new Orbit() { description = "orbit 1" };
			var orbit2 = new Orbit() { description = "orbit 2" };

			Mock<Vehicle> bikeMock = new Mock<Vehicle>(MockBehavior.Strict);
			bikeMock.Object.vehicleType = VehicleType.Bike;
			bikeMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(true);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit1.description), It.IsAny<Weather>()))
				.Returns(2);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit2.description), It.IsAny<Weather>()))
				.Returns(1.5);
			bikeMock.Setup(_ => _.ToString()).Returns(bikeMock.Object.vehicleType.ToString());

			Mock<Vehicle> superCarMock = new Mock<Vehicle>(MockBehavior.Strict);
			superCarMock.Object.vehicleType = VehicleType.SuperCar;
			superCarMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(true);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit1.description), It.IsAny<Weather>()))
				.Returns(1.7);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit2.description), It.IsAny<Weather>()))
				.Returns(1.4);
			superCarMock.Setup(_ => _.ToString()).Returns(superCarMock.Object.vehicleType.ToString());

			var helper = new TravelHelper(new Orbit[] { orbit1, orbit2 },
				new Vehicle[] { bikeMock.Object, superCarMock.Object },
				WeatherType.Rainy);
			var expectedOutput = "Vehicle " + superCarMock.Object.vehicleType.ToString() + " on " + orbit2.description;

			var shortestTrip = helper.getTripWithShortestTravelTime();
			Assert.AreEqual(expectedOutput, shortestTrip.ToString());
		}

		[TestMethod]
		public void shouldGetOrbitAndVehicleWithShortestTravelTimeSuitableToWeather()
		{
			var orbit1 = new Orbit() { description = "orbit 1" };
			var orbit2 = new Orbit() { description = "orbit 2" };

			Mock<Vehicle> bikeMock = new Mock<Vehicle>(MockBehavior.Strict);
			bikeMock.Object.vehicleType = VehicleType.Bike;
			bikeMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(true);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit1.description), It.IsAny<Weather>()))
				.Returns(2);
			bikeMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit2.description), It.IsAny<Weather>()))
				.Returns(1.5);
			bikeMock.Setup(_ => _.ToString()).Returns(bikeMock.Object.vehicleType.ToString());

			Mock<Vehicle> superCarMock = new Mock<Vehicle>(MockBehavior.Strict);
			superCarMock.Object.vehicleType = VehicleType.SuperCar;
			superCarMock.Setup(_ => _.canTravel(It.IsAny<Weather>())).Returns(false);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit1.description), It.IsAny<Weather>()))
				.Returns(1.7);
			superCarMock.Setup(_ => _.getTravelTime(It.Is<Orbit>(o => o.description == orbit2.description), It.IsAny<Weather>()))
				.Returns(1.4);
			superCarMock.Setup(_ => _.ToString()).Returns(superCarMock.Object.vehicleType.ToString());

			var helper = new TravelHelper(new Orbit[] { orbit1, orbit2 },
				new Vehicle[] { bikeMock.Object, superCarMock.Object },
				WeatherType.Rainy);
			var expectedOutput = "Vehicle " + bikeMock.Object.vehicleType.ToString() + " on " + orbit2.description;

			var shortestTrip = helper.getTripWithShortestTravelTime();
			Assert.AreEqual(expectedOutput, shortestTrip.ToString());
		}

	}
}
