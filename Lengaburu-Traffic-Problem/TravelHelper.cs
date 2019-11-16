using System;
using System.Linq;

namespace Lengaburu_Traffic_Problem
{
	public class TravelHelper
	{
		public Orbit[] orbits { get; set; }
		public Vehicle[] vehicles { get; set; }
		public WeatherType weatherType { get; set; }

		public TravelHelper()
		{

		}
		public TravelHelper(Orbit[] _orbits, Vehicle[] _vehicles, WeatherType _weatherType)
		{
			orbits = _orbits;
			vehicles = _vehicles;
			weatherType = _weatherType;
		}
		public Trip getTripWithShortestTravelTime()
		{
			Trip shortestTrip = null;
			Weather weather = new Weather(weatherType);
			Vehicle[] availableVehicles = getVehiclesSuitableForWeather(vehicles, weather);
			try
			{
				foreach (var orbit in orbits)
				{
					foreach (var vehicle in availableVehicles)
					{
						Trip trip = new Trip(orbit, vehicle, weather);
						if (shortestTrip == null)
						{
							shortestTrip = trip;
						}
						else
						{
							shortestTrip = chooseOptimalTrip(trip, shortestTrip);
						}
					}
				}
				return shortestTrip;
			}
			catch (Exception ex)
			{
				throw new Exception("Cannot find ,something went wrong");
			}
		}

		private Trip chooseOptimalTrip(Trip newTrip, Trip shortestTrip)
		{
			var newTripTravelTime = newTrip.getTravelTime();
			var shortestTripTravelTime = shortestTrip.getTravelTime();
			if (newTripTravelTime < shortestTripTravelTime)
			{
				shortestTrip = newTrip;
			}
			else if (newTripTravelTime == shortestTripTravelTime)
			{
				var trips = new Trip[] { newTrip, shortestTrip };
				shortestTrip = trips.OrderBy(t => t.vehicle.priority).FirstOrDefault();
			}
			return shortestTrip;
		}

		private Vehicle[] getVehiclesSuitableForWeather(Vehicle[] vehicles, Weather weather)
		{
			return vehicles.Where(v => v.canTravel(weather)).ToArray();
		}
	}
}
