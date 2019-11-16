using System;

namespace Lengaburu_Traffic_Problem.IntegerationTest
{
	public class IntegerationTest
	{
		public void MethodOne()
		{
			Console.WriteLine("Integeration test 1:");
			Orbit[] orbits = new Orbit[]
			{
				new Orbit("Orbit1",12,20,18),
				new Orbit("Orbit2",10,10,20)
			};

			Vehicle[] vehicles = new Vehicle[]
			{
				new Vehicle(VehicleType.Bike,10,2,new WeatherType[]{ WeatherType.Sunny,WeatherType.Windy },1),
				new Vehicle(VehicleType.TukTuk,12,1,new WeatherType[]{ WeatherType.Sunny,WeatherType.Rainy },2),
				new Vehicle(VehicleType.SuperCar,20,3,new WeatherType[]{ WeatherType.Sunny,WeatherType.Windy,WeatherType.Rainy },3)
			};
			TravelHelper helper = new TravelHelper(orbits, vehicles, WeatherType.Sunny);
			var shortestTrip = helper.getTripWithShortestTravelTime();
			Console.WriteLine("Input: Weather is Sunny");
			Console.WriteLine("Input: Orbit1 traffic speed is 12 megamiles/hour");
			Console.WriteLine("Input: Orbit2 traffic speed is 10 megamiles/hour");
			Console.WriteLine("Output: " + shortestTrip.ToString());
			Console.WriteLine();
		}

		public void MethodTwo()
		{
			Console.WriteLine("Integeration test 2:");
			Orbit[] orbits = new Orbit[]
			{
				new Orbit("Orbit1",14,20,18),
				new Orbit("Orbit2",20,10,20)
			};

			Vehicle[] vehicles = new Vehicle[]
			{
				new Vehicle(VehicleType.Bike,10,2,new WeatherType[]{ WeatherType.Sunny,WeatherType.Windy },1),
				new Vehicle(VehicleType.TukTuk,12,1,new WeatherType[]{ WeatherType.Sunny,WeatherType.Rainy },2),
				new Vehicle(VehicleType.SuperCar,20,3,new WeatherType[]{ WeatherType.Sunny,WeatherType.Windy,WeatherType.Rainy },3)
			};
			TravelHelper helper = new TravelHelper(orbits, vehicles, WeatherType.Sunny);
			var shortestTrip = helper.getTripWithShortestTravelTime();
			Console.WriteLine("Input: Weather is Windy");
			Console.WriteLine("Input: Orbit1 traffic speed is 14 megamiles/hour");
			Console.WriteLine("Input: Orbit2 traffic speed is 20 megamiles/hour");
			Console.WriteLine("Output: " + shortestTrip.ToString());
			Console.WriteLine();
		}
	}
}
