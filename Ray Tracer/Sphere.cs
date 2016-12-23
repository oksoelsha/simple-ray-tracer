using System;

namespace Ray_Tracer
{
	/// <summary>
	/// Summary description for Sphere.
	/// </summary>
	public class Sphere
	{
		public Sphere(Point c, double r)
		{
			center = c;
			radius = r;
		}

		private Point center;
		private double radius;

		public Point Center 
		{
			get { return center; }
		}

		public double Radius 
		{
			get { return radius; }
		}
	}
}
