using System;

namespace Ray_Tracer
{
	/// <summary>
	/// Summary description for RGB.
	/// </summary>
	public class RGB
	{
		public RGB(int r, int g, int b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
		}

		private int r, g, b;

		public int R
		{
			set 
			{
				r = value;
				if (r>255) r=255;
			}
			get { return r; }
		}

		public int G
		{
			set
			{
				g = value;
				if (g>255) g=255;
			}
			get { return g; }
		}

		public int B
		{
			set
			{
				b = value;
				if (b>255) b=255;
			}
			get { return b; }
		}
	}
}
