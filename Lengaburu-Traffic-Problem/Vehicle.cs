using System;
using System.Linq;

namespace Lengaburu_Traffic_Problem
{
	public class Vehicle
	{
		const int minutes = 60;
		public VehicleType vehicleType;
		public double maxSpeed;
		public double timeToCrossOneCraterinMins;
		public int priority;
		public WeatherType[] suitableWeatherTypes;
		public Vehicle()
		{

		}
		public Vehicle(VehicleType _vehicleType, int _speed, int _timeToCrossCrater, WeatherType[] _suitableWeatherTypes, int _priority)
		{
			priority = _priority;
			vehicleType = _vehicleType;
			maxSpeed = _speed;
			timeToCrossOneCraterinMins = _timeToCrossCrater;
			suitableWeatherTypes = _suitableWeatherTypes;
		}
		public virtual bool canTravel(Weather weather)
		{
			return suitableWeatherTypes.Contains(weather.weatherType);
		}
		public virtual double getTravelTime(Orbit orbit, Weather weather)
		{
			double time = (orbit.distance / Math.Min(maxSpeed, orbit.trafficSpeed)) + ((orbit.getCratersOnOrbit(weather) * timeToCrossOneCraterinMins) / minutes);
			return time;
		}

		public override string ToString()
		{
			return vehicleType.ToString();
		}
	}
}
