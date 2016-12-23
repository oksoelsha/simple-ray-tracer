using System;

namespace Ray_Tracer
{
	public class Ray
	{
		public Ray(Point p1, Point p2)
		{
			this.p1 = p1;
			this.p2 = p2;
		}

		private Point p1, p2;

		public Point P1
		{
			set { p1 = value; }
			get { return p1; }
		}

		public Point P2
		{
			set { p2 = value; }
			get { return p2; }
		}
	}
}
