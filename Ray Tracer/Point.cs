using System;

namespace Ray_Tracer
{
	/// <summary>
	/// Summary description for Point.
	/// </summary>
	public class Point
	{
		public Point(double x, double y, double z, RGB color)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.color = color;
		}

		private double x, y, z;
		RGB color;

		public double X 
		{
			set { x = value; }
			get { return x; }
		}

		public double Y
		{
			set { y = value; }
			get { return y; }
		}

		public double Z
		{
			set { z = value; }
			get { return z; }
		}

		public RGB Color 
		{
			get { return color; }
		}
	}
}
