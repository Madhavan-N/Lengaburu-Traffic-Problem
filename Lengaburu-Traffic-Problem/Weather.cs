using System.Collections.Generic;

namespace Lengaburu_Traffic_Problem
{
	public class Weather
	{
		const int percentage = 100;
		private IDictionary<WeatherType, double> weatherDamagePercentage = new Dictionary<WeatherType, double>();

		private double damage;
		public WeatherType weatherType;
		public Weather()
		{

		}
		public Weather(WeatherType _weatherType)
		{
			weatherDamagePercentage.Add(WeatherType.Rainy, 20);
			weatherDamagePercentage.Add(WeatherType.Sunny, -10);
			weatherDamagePercentage.Add(WeatherType.Windy, 0);

			weatherType = _weatherType;
			weatherDamagePercentage.TryGetValue(_weatherType, out damage);
		}
		public virtual double weatherDamagePercantageOnCrater()
		{
			return damage / percentage;
		}
	}
}
