using System;

namespace Ray_Tracer
{
	public class PixelColor
	{
		public PixelColor()
		{
		}

		private static RGB rgb = new RGB(0,0,0);
		private static Point intersectionPoint = new Point(0,0,0,null);
		private static Point intersectionPoint2 = new Point(0,0,0,null);
		private static Point light_intersect = new Point(0,0,0,null);
		private static Point radius_intersect = new Point(0,0,0,null);
		private static Point Reflection = new Point(0,0,0,null);
		private static Point tmpVector = new Point(0,0,0,null);
		private static Point rayVector = new Point(0,0,0,null);

		public static RGB getRGB(Ray ray,
			Sphere[] spheres,
			Light light,
			int specularLight)
		{
			//do all computations
			double a,b,c;
			double x1,y1,z1;			//stationary point
			double x2,y2,z2;			//viewing pixel
			double x3,y3,z3,r;			//sphere's center and radius

			x1 = ray.P1.X;
			y1 = ray.P1.Y;
			z1 = ray.P1.Z;

			x2 = ray.P2.X;
			y2 = ray.P2.Y;
			z2 = ray.P2.Z;

			double closestZ = -3000000;
			int indexClosestSphere = 0;
			bool sphereIntersected = false;

			//initial assumption is there's no intersection
			//so initialize the pixel color to black
			rgb.R = rgb.G = rgb.B = 0;

			//loop through spheres
			for (int index=0; index<spheres.Length; index++) 
			{
				x3 = spheres[index].Center.X;
				y3 = spheres[index].Center.Y;
				z3 = spheres[index].Center.Z;
				r  = spheres[index].Radius;

				double tmp1,tmp2,tmp3;
				tmp1 = x2-x1;
				tmp2 = y2-y1;
				tmp3 = z2-z1;

				a = tmp1*tmp1 + tmp2*tmp2 + tmp3*tmp3;

				double tmp4,tmp5,tmp6;
				tmp4 = x1-x3;
				tmp5 = y1-y3;
				tmp6 = z1-z3;

				b = 2*(tmp1*tmp4 + tmp2*tmp5 + tmp3*tmp6);

				c = x3*x3 + y3*y3 + z3*z3
					+ x1*x1 + y1*y1 + z1*z1
					- 2*(x3*x1 + y3*y1 + z3*z1) - r*r;


				//find out if there is intersection
				double under = b*b - 4*a*c;

				if (under >= 0)
				{
					//mark that there's at least one intersection
					sphereIntersected = true;

					double u = (-1 * b - Math.Sqrt(under)) / (2 * a);
					double Zpoint = (z2-z1)*u + z1;

					if (Zpoint > closestZ) 
					{
						indexClosestSphere = index;
						closestZ = Zpoint + 0.0001;

						//store the point of intersection. Will be
						//used to find light intensity
						intersectionPoint.X = (x2-x1)*u + x1;
						intersectionPoint.Y = (y2-y1)*u + y1;
						intersectionPoint.Z = Zpoint;
					}
				}
			}

			//at this point we went through all spheres
			if (sphereIntersected == true
				&& ClearPath(intersectionPoint, light, spheres) == true)
			{
				//find cos the angle between radius-point
				// and light-point
				radius_intersect.X = intersectionPoint.X-spheres[indexClosestSphere].Center.X;
				radius_intersect.Y = intersectionPoint.Y-spheres[indexClosestSphere].Center.Y;
				radius_intersect.Z = intersectionPoint.Z-spheres[indexClosestSphere].Center.Z;

				light_intersect.X = intersectionPoint.X-light.X;
				light_intersect.Y = intersectionPoint.Y-light.Y;
				light_intersect.Z = intersectionPoint.Z-light.Z;

				double cosAngle = dotProduct(radius_intersect,
					light_intersect)
					/ magnitude(radius_intersect)
					/ magnitude(light_intersect);

				cosAngle = Math.Abs(cosAngle);

				//set the diffuse light component
				rgb.R = (int)((double)(spheres[indexClosestSphere].Center.Color.R * cosAngle));
				rgb.G = (int)((double)(spheres[indexClosestSphere].Center.Color.G * cosAngle));
				rgb.B = (int)((double)(spheres[indexClosestSphere].Center.Color.B * cosAngle));

				//set the specular light component
				if (specularLight > 0)
				{
					normalize(radius_intersect);
					normalize(light_intersect);

					double NdotL = 2*dotProduct(light_intersect, radius_intersect);
					//The following if statement guarantees that when
					//the viewing ray and the light reflection off the
					//surface are almost parallel, they will not take
					//part in the calculation of the specular light.
					//Not using this if statement results in white
					//edges on the spheres (since cos of angle between
					//the two almost parallel vectors is ~1)
					if (NdotL < -0.5 || NdotL > 0.5) 
					{
						tmpVector.X = NdotL * radius_intersect.X;
						tmpVector.Y = NdotL * radius_intersect.Y;
						tmpVector.Z = NdotL * radius_intersect.Z;

						Reflection.X = tmpVector.X - light_intersect.X;
						Reflection.Y = tmpVector.Y - light_intersect.Y;
						Reflection.Z = tmpVector.Z - light_intersect.Z;

						rayVector.X = ray.P2.X - ray.P1.X;
						rayVector.Y = ray.P2.Y - ray.P1.Y;
						rayVector.Z = ray.P2.Z - ray.P1.Z;

						cosAngle = dotProduct(Reflection, rayVector)
							/ magnitude(Reflection)
							/ magnitude(rayVector);

						cosAngle = Math.Pow(cosAngle, specularLight*100);

						rgb.R += (int)(255 * cosAngle);
						rgb.G += (int)(255 * cosAngle);
						rgb.B += (int)(255 * cosAngle);
					}
				}
			}
			return rgb;
		}

		private static void normalize(Point V)
		{
			double mag = magnitude(V);

			V.X /= mag;
			V.Y /= mag;
			V.Z /= mag;
		}

		private static double dotProduct(Point P1, Point P2)
		{
			return (P1.X*P2.X + P1.Y*P2.Y + P1.Z*P2.Z);
		}

		private static double magnitude(Point P)
		{
			return Math.Sqrt(P.X*P.X + P.Y*P.Y + P.Z*P.Z);
		}

		private static bool ClearPath(Point intersectionPoint,
			Light light,
			Sphere[] spheres) 
		{
			//do all computations
			double a,b,c;
			double x1,y1,z1;			//intersection point
			double x2,y2,z2;			//light position
			double x3,y3,z3,r;			//sphere's center and radius

			x1 = intersectionPoint.X;
			y1 = intersectionPoint.Y;
			z1 = intersectionPoint.Z;

			x2 = light.X;
			y2 = light.Y;
			z2 = light.Z;

			double light_intersect_dist =
				Math.Sqrt((x1-x2)*(x1-x2) + 
							(y1-y2)*(y1-y2) +
							(z1-z2)*(z1-z2)) - 0.0001;

			//loop through spheres
			for (int index=0; index<spheres.Length; index++) 
			{
				x3 = spheres[index].Center.X;
				y3 = spheres[index].Center.Y;
				z3 = spheres[index].Center.Z;
				r  = spheres[index].Radius;

				double tmp1,tmp2,tmp3;
				tmp1 = x2-x1;
				tmp2 = y2-y1;
				tmp3 = z2-z1;

				a = tmp1*tmp1 + tmp2*tmp2 + tmp3*tmp3;

				double tmp4,tmp5,tmp6;
				tmp4 = x1-x3;
				tmp5 = y1-y3;
				tmp6 = z1-z3;

				b = 2*(tmp1*tmp4 + tmp2*tmp5 + tmp3*tmp6);

				c = x3*x3 + y3*y3 + z3*z3
					+ x1*x1 + y1*y1 + z1*z1
					- 2*(x3*x1 + y3*y1 + z3*z1) - r*r;

				//find out if there is intersection
				double under = b*b - 4*a*c;

				if (under >= 0)
				{
					double u1 = (-1 * b + Math.Sqrt(under)) / (2 * a);
					double u2 = (-1 * b - Math.Sqrt(under)) / (2 * a);
					double X1,X2,Y1,Y2,Z1,Z2;
					X1 = (x2-x1)*u1 + x1;
					X2 = (x2-x1)*u2 + x1;
					Y1 = (y2-y1)*u1 + y1;
					Y2 = (y2-y1)*u2 + y1;
					Z1 = (z2-z1)*u1 + z1;
					Z2 = (z2-z1)*u2 + z1;

					double dist1 =
						Math.Sqrt((X1-x2)*(X1-x2) +
									(Y1-y2)*(Y1-y2) +
									(Z1-z2)*(Z1-z2));
					double dist2 =
						Math.Sqrt((X2-x2)*(X2-x2) +
									(Y2-y2)*(Y2-y2) +
									(Z2-z2)*(Z2-z2));

					if(dist1 < light_intersect_dist ||
						dist2 < light_intersect_dist)
						return false;

				}
			}
			//if we get here, then the there's nothing blocking
			//the intersection point from the light source
			return true;
		}
	}
}
