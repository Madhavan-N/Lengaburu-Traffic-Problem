namespace Lengaburu_Traffic_Problem
{
	public class Trip
	{
		public Orbit orbit;
		public Vehicle vehicle;
		public Weather weather;
		public Trip(Orbit _orbit, Vehicle _vehicle, Weather _weather)
		{
			orbit = _orbit;
			vehicle = _vehicle;
			weather = _weather;
		}

		public double getTravelTime()
		{
			return vehicle.getTravelTime(orbit, weather);
		}

		public override string ToString()
		{
			return string.Format("Vehicle {0} on {1}", vehicle.ToString(), orbit.description);
		}
	}
}
