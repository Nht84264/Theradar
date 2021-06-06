using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar
{
    public class toado
    {
        public int stt;
        public double X;
        public double Y;
        public double Z;
        public double alpha;
        public double beta;
        public double r;
        public double range;
        public double velocity;
        public toado(int sttu, double x, double y, double z, double speed, string xyz)
        {
            stt = sttu;
            X = x;
            Y = y;
            Z = z;
            range = Math.Sqrt(x * x + y * y);
            alpha = Math.Acos(x / range);
            alpha = alpha / 0.0174532925d;
            if (y < 0)
            {
                alpha = 360d - alpha;
            }
            r = Math.Sqrt(range * range + z * z);
            beta = Math.Asin(z / r);
            velocity = speed;
        }
        public toado(int sttu, double a, double b, double radius, double speed)
        {
            stt = sttu;
            range = r * Math.Cos(b);
            Z = r * Math.Sin(b);
            X = range * Math.Cos(a);
            if (a > 180)
            {
                Y = range * Math.Sin(360 - a);
            }
            else
                Y = range * Math.Sin(a);
            velocity = speed;
            alpha = a;
            beta = b;
            r = radius;
        }

    }
}
