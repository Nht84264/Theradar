using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Text;
using System.Threading.Tasks;

namespace Radar
{
    public class maybay
    {
        public toado _current;
        public toado _to;
        public string _category;
        public int ID;
        public List<toado> airline = new List<toado>();
        public Color _color;
        public maybay()
        { }
        public maybay(int targetID)
        {
            _current = new toado(0, 300, 300, 0, 4000, "abc");
            _to = new toado(1, 600, 600, 0, 0, "abc");
            _category = "Tên lửa";
            ID = 1000;
        }
        public maybay(string loai, int id, List<toado> qd, Color color)
        {
            ID = id;
            _category = loai;
            airline = qd;
            _current = qd[0];
            _to = qd[1];
            _color = color;
        }
        // ve cac muc tieu tren man hinh scan cua radar
        public void DrawItem(Theradar radar, Graphics g)
        {
            PointF cp = new PointF((float)_current.X, (float)_current.Y);
            //loai 1 - Hinh vuong - Quan ta
            if (_category == "Quân sự  (ta)")
            {
                //PointF cp = radar.AzRg2XY(_azimuth, _range);
                //cp = this.From;
                PointF topLeft = new PointF(cp.X - ((float)8 / 2), cp.Y - ((float)8 / 2));
                g.FillRectangle(new SolidBrush(_color), new RectangleF(topLeft, new SizeF((float)8, (float)8)));
            }
            //loai 2 - Hinh tron - Dan su
            else if (_category == "Dân sự")
            {
                //PointF cp = radar.AzRg2XY(_azimuth, _range);
                PointF topLeft = new PointF(cp.X - ((float)8 / 2), cp.Y - ((float)8 / 2));
                g.FillEllipse(new SolidBrush(_color), new RectangleF(topLeft, new SizeF((float)8, (float)8)));
            }
            //loai 3 - Hinh tam giac - Quan dich
            else if (_category == "Quân sự (địch)")
            {
                //PointF cp = radar.AzRg2XY(_azimuth, _range);
                PointF _topLeft = new PointF(cp.X - ((float)8 / 2), cp.Y - ((float)8 / 2));

                PointF p1 = new PointF(((float)_topLeft.X + ((float)8 / 2F)), (float)_topLeft.Y);
                PointF p2 = new PointF((float)_topLeft.X, (float)_topLeft.Y + (float)8);
                PointF p3 = new PointF((float)_topLeft.X + (float)8, (float)_topLeft.Y + (float)8);

                GraphicsPath _gp = new GraphicsPath(FillMode.Winding);
                _gp.AddPolygon(new PointF[] { p1, p2, p3 });
                g.FillPath(new SolidBrush(_color), _gp);
            }
            //loai 4 _ Hinh tam giac vang - Ten lua
            else
            {
                PointF _topLeft = new PointF(cp.X - ((float)8 / 2), cp.Y - ((float)8 / 2));
                PointF p1 = new PointF(((float)_topLeft.X + ((float)8 / 2F)), (float)_topLeft.Y);
                PointF p2 = new PointF((float)_topLeft.X, (float)_topLeft.Y + (float)8);
                PointF p3 = new PointF((float)_topLeft.X + (float)8, (float)_topLeft.Y + (float)8);
                GraphicsPath _gp = new GraphicsPath(FillMode.Winding);
                _gp.AddPolygon(new PointF[] { p1, p2, p3 });
                g.FillPath(new SolidBrush(Color.Yellow), _gp);
            }
        }
        // ve cac muc tieu tren man hinh quet thang
        public void DrawItemStraightSweep(Radar radar, Graphics g, int w, int h)
        {
            double d = Radar.getRange(_current);
            PointF pt1 = new PointF((float)d * w / 300, (float)h / 4);
            g.FillRectangle(new SolidBrush(_color), new RectangleF(pt1, new SizeF((float)8, (float)8)));
            PointF pt2 = new PointF((float)(d % 100) * w / 100, (float)h / 2);
            g.FillRectangle(new SolidBrush(_color), new RectangleF(pt2, new SizeF((float)8, (float)8)));
            PointF pt3 = new PointF((float)(d % 10) * w / 10, (float)h * 3 / 4);
            g.FillRectangle(new SolidBrush(_color), new RectangleF(pt3, new SizeF((float)8, (float)8)));
        }
        // ve cac muc tieu tren man hinh quet tron 
        public void DrawItemCircleSweep(Radar radar, Graphics g, int size)
        {
            double d = Radar.getRange(_current);
            PointF pt1 = AzRg2XY((float)(d) * 360 / 300, size / 2, size + 40);
            g.FillRectangle(new SolidBrush(_color), new
            RectangleF(pt1, new SizeF((float)8, (float)8)));
            PointF pt2 = AzRg2XY((float)(d % 100) * 360 / 100, size / 3, size + 40);
            g.FillRectangle(new SolidBrush(_color), new RectangleF(pt2, new SizeF((float)8, (float)8)));
            PointF pt3 = AzRg2XY((float)(d % 10) * 360 / 10, size / 6, size + 40);
            g.FillRectangle(new SolidBrush(_color), new RectangleF(pt3, new SizeF((float)8, (float)8)));
        }
        // ve cac muc tieu tren man quet xoan oc
        public void DrawItemSpiralSweep(Radar radar, Graphics g, int size, int numRev)
        {
            double d = 300 - Radar.getRange(_current);
            PointF pt = new PointF();
            int iNumRevs = numRev;
            int iNumPoints = 300;

            float fAngle, fScale;
            fAngle = (float)(d * 2 * Math.PI / (iNumPoints / iNumRevs));
            fScale = 1 - (float)d / iNumPoints;
            pt.X = (float)((size / 2) * (1 + fScale * Math.Sin(fAngle)));
            pt.Y = (float)((size / 2) * (1 + fScale * Math.Cos(fAngle)));
            g.FillRectangle(new SolidBrush(_color), new RectangleF(pt, new SizeF((float)8, (float)8)));
        }
        public int CompareTo(maybay item)
        {
            return 0;
        }
        public PointF AzRg2XY(float azimuth, float Rg, int size)
        {
            //rotate coords… 90deg W =100Deg trig
            double angle = (278d + (double)azimuth);
            //turn into radians
            angle *= 0.0174532925d;
            double r, x, y;
            //determine the light of the radius;
            r = Rg;
            x = (((double)size * 0.5d) + (r * Math.Cos(angle)));
            y = (((double)size * 0.5d) + (r * Math.Sin(angle)));
            return new PointF((float)x, (float)y);
        }

    }
}
