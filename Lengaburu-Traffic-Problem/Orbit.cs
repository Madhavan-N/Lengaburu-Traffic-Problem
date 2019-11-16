namespace Lengaburu_Traffic_Problem
{
	public class Orbit
	{
		public string description;
		public double trafficSpeed;
		public int numberOfCraters;
		public double distance;

		public Orbit()
		{

		}
		public Orbit(string _description, double _trafficSpeed, int _noOfCraters, double _distance)
		{
			description = _description;
			trafficSpeed = _trafficSpeed;
			numberOfCraters = _noOfCraters;
			distance = _distance;
		}

		public int getCratersOnOrbit(Weather weather)
		{
			numberOfCraters += (int)(numberOfCraters * weather.weatherDamagePercantageOnCrater());
			return numberOfCraters;
		}
	}
}
