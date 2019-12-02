using System;
using System.Linq;

namespace Lengaburu_Traffic_Problem
{
	public class Vehicle
	{
		const int minutes = 60;
		private VehicleType vehicleType;
		private double maxSpeed;
		private double timeToCrossOneCraterinMins;
		private int priority;
		private WeatherType[] suitableWeatherTypes;
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
			return suitableWeatherTypes.Contains(weather.getWeatherType());
		}
		public virtual double getTravelTime(Orbit orbit, Weather weather)
		{
			double time = (orbit.getDistance() / Math.Min(maxSpeed, orbit.getTrafficSpeed())) + ((orbit.getCratersOnOrbit(weather) * timeToCrossOneCraterinMins) / minutes);
			return time;
		}

		public virtual int getPriority()
		{
			return priority;
		}

		public virtual VehicleType getVehicleType()
		{
			return vehicleType;
		}

		public override string ToString()
		{
			return vehicleType.ToString();
		}
	}
}
