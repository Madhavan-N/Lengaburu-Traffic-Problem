namespace Lengaburu_Traffic_Problem
{
	public class Orbit
	{
		private string description;
		private double trafficSpeed;
		private int numberOfCraters;
		private double distance;

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

		public string getDescription()
		{
			return description;
		}

		public double getTrafficSpeed()
		{
			return trafficSpeed;
		}

		public double getDistance()
		{
			return distance;
		}
	}
}
