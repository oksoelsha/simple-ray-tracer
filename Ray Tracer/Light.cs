using System;

namespace Ray_Tracer
{
	public class Light : Point
	{
		public Light(double x, double y, double z, RGB color) : base(x, y, z, color)
		{
		}
	}
}
