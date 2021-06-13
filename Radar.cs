using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radar
{
    public class Radar
    {
        bool catchedTargetFlag;
        public bool changeTargetFlag;
        public int targetCatched = 0;
        public bool clockwiseScan = true;
        static int _size;
        public Image baseImageRadarScan;
        public Image baseImageStraightSweep;
        public Image baseImageCircleSweep;
        public Image baseImageSpiralSweep;
        public Image outputImageStraightSweep;
        public Image outputImageRadarScan;
        public Image outputImageCircleSweep;
        public Image outputImageSpiralSweep;
        public int numberOfSpirals = 3;
        public double maxAngle = 60;
        public int _az = 0;
        public PointF _pt;
        public PointF _pt3;
        public PointF _pt2;
        Timer t;
        Color _topColor = Color.FromArgb(0, 120, 0);
        Color _bottonColor = Color.FromArgb(0, 40, 0);
        Color _lineColor = Color.FromArgb(0, 255, 0);
        Color _targetColor = Color.FromArgb(255, 0, 0);
        public List<maybay> TargetList = new List<maybay>();
        public Radar(int diameter, int ss_w, int ss_h, int cs_size)
        {
            _size = diameter;
            CreateBaseImage();
            CreatebaseImageStraightSweep(ss_w, ss_h);
            CreateBaseImageCircleSweep(cs_size);
            CreateBaseImageSpiralSweep(cs_size);
            Draw();
            t = new Timer();
            t.Enabled = true;
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 40;
        }
        public int DrawScanInterval
        {
            //khoảng thời gian giữa hai lần quét,càng tăng thì đường quét càng chậm
            get
            {
                return t.Interval;
            }
            set
            {
                if (value > 0)
                {
                    t.Interval = value;
                }
            }
        }
        public Color CustomGradientColorBotton
        {
            get
            {
                return _bottonColor;
            }
            set
            {
                _bottonColor = value;
                CreateBaseImage();
                Draw();
            }
        }
        public Color CustomGradientColorTop
        {
            get
            { return _topColor; }
            set
            {
                _topColor = value;
                CreateBaseImage();
                Draw();
            }
        }
        public Image Image
        {
            get
            {
                return outputImageRadarScan;
            }
        }
        void CreateBaseImage()
        {
            Image i = new Bitmap(_size, _size);
            Graphics g = Graphics.FromImage(i);
            Pen p = new Pen(_lineColor);
            //làm ảnh đẹp hơn
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.Bicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //vẽ ảnh nền của radar scan
            g.DrawEllipse(p, 0, 0, _size - 1, _size - 1);
            //vẽ các vòng tròn (ở đây là 5 vong tròn)
            int interval = _size / 5;
            for (int j = 1; j < 5; j++)
            {
                int interval1 = interval * j;
                g.DrawEllipse(p, (_size - interval1) / 2, (_size - interval1) / 2, interval1, interval1);
                Font ab = new Font("Arial", 10);
                g.DrawString((30 - 6 * j).ToString(), ab, Brushes.Red, interval1 / 2, _size / 2);
                g.DrawString((30 - 6 * j).ToString(), ab, Brushes.Red, _size - interval1 / 2 - 15, _size / 2);

            }
            //vẽ trục ox,oy
            g.DrawLine(p, new Point(0, (int)(_size / 2)), new Point(_size - 1, (int)(_size - 2) / 2));
            g.DrawLine(p, new Point((int)(_size / 2), 0), new Point((int)(_size - 2) / 2, _size - 1));
            Font abc = new Font("Arial", 10);
            g.DrawString("w", abc, Brushes.Red, 0, _size / 2);
            g.DrawString("n", abc, Brushes.Red, _size / 2, 0);
            g.DrawString("e", abc, Brushes.Red, _size - 15, _size / 2);
            g.DrawString("w", abc, Brushes.Red, _size / 2, _size - 15);
            //xóa ảnh vẽ
            g.Dispose();
            //update the base image
            baseImageRadarScan = i;
        }
        void Draw()
        {
            Image scanImage;
            if (!catchedTargetFlag)
                scanImage = (Image)baseImageRadarScan.Clone();
            else
            {
                if (!changeTargetFlag)
                {
                    scanImage = (Image)baseImageRadarScan.Clone();
                }
                else
                    scanImage = outputImageRadarScan;
            }
            Image straightSweepImage = (Image)baseImageStraightSweep.Clone();
            Image circleSweepImage = (Image)baseImageCircleSweep.Clone();
            Image spiralSweepImage = (Image)baseImageSpiralSweep.Clone();

            Graphics scanGraphics = Graphics.FromImage(scanImage);
            Graphics straightSweepGraphics = Graphics.FromImage(straightSweepImage);
            Graphics circleSweepGraphics = Graphics.FromImage(circleSweepImage);
            Graphics spiralSweepGraphics = Graphics.FromImage(spiralSweepImage);

            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            if (!catchedTargetFlag)
            {
                //vẽ cạnh sóng radar
                gp.AddLine(new PointF((float)(_size / 2), (float)(_size / 2)), _pt2);
                gp.AddCurve(new PointF[] { _pt2, AzRg2XY(_az - 20, _size / 2), AzRg2XY(_az - 10, _size / 2), _pt, AzRg2XY(_az + 10, _size / 2), AzRg2XY(_az + 20, _size / 2), _pt3 });
                gp.AddLine(_pt3, new PointF((float)(_size / 2), (float)(_size / 2)));
                PathGradientBrush pgb = new PathGradientBrush(gp);
                pgb.CenterPoint = _pt3;
                pgb.CenterColor = Color.FromArgb(128, _lineColor);
                pgb.SurroundColors = new Color[] { Color.Empty };
                scanGraphics.FillPath(pgb, gp);
                //vẽ tia quét
                scanGraphics.DrawLine(new Pen(_lineColor), new PointF((float)(_size / 2), (float)(_size / 2)), _pt3);
            }
            else
            {
                if (changeTargetFlag)
                {
                    //vẽ cạnh sóng radar
                    gp.AddLine(new PointF((float)(_size / 2), (float)(_size / 2)), _pt2);
                    gp.AddCurve(new PointF[] { _pt2, AzRg2XY(_az - 20, _size / 2), AzRg2XY(_az - 10, _size / 2), _pt, AzRg2XY(_az + 10, _size / 2), AzRg2XY(_az + 20, _size / 2), _pt3 });
                    gp.AddLine(_pt3, new PointF((float)(_size / 2), (float)(_size / 2)));
                    PathGradientBrush pgb = new PathGradientBrush(gp);
                    pgb.CenterPoint = _pt3;
                    pgb.CenterColor = Color.FromArgb(128, _lineColor);
                    pgb.SurroundColors = new Color[] { Color.Empty };
                    scanGraphics.FillPath(pgb, gp);
                    //vẽ tia quét
                    scanGraphics.DrawLine(new Pen(_lineColor), new PointF((float)(_size / 2), (float)(_size / 2)), _pt3);

                }
            }

            //tính sin của góc ngẩng cao nhất
            double max_angle = maxAngle * 0.0174532925;//đổi sang radian
            foreach (maybay item in TargetList)
            {
                if (_az + 20 > 360)
                {
                    if (getAzimuth(item._current) < 360 && getAzimuth(item._current) > getAzimuth(_pt2) && (getRange(item._current) * Math.Sin(max_angle)) > item._current.Z && getRange(item._current) < _size / 2)
                    {
                        item.DrawItem(this, scanGraphics);
                        item.DrawItemStraightSweep(this, straightSweepGraphics, straightSweepImage.Width, straightSweepImage.Height);
                        item.DrawItemCircleSweep(this, circleSweepGraphics, circleSweepImage.Width - 40);
                        item.DrawItemSpiralSweep(this, spiralSweepGraphics, spiralSweepImage.Width - 40, numberOfSpirals);
                    }
                }
                else
                {
                    if (getAzimuth(item._current) < getAzimuth(_pt3) && getAzimuth(item._current) > getAzimuth(_pt2) && (getAzimuth(item._current) * Math.Sin(max_angle)) > item._current.Z && getRange(item._current) < _size / 2)
                    {
                        item.DrawItem(this, scanGraphics);
                        item.DrawItemStraightSweep(this, straightSweepGraphics, straightSweepImage.Width, straightSweepImage.Height);
                        item.DrawItemCircleSweep(this, circleSweepGraphics, circleSweepImage.Width - 40);
                        item.DrawItemSpiralSweep(this, spiralSweepGraphics, spiralSweepImage.Width - 40, numberOfSpirals);
                    }
                }
            }
            //vẽ lại vòng tròn(chỉ để ảnh đẹp hơn)
            //giải phóng tài nguyên
            scanGraphics.Dispose();
            straightSweepGraphics.Dispose();
            circleSweepGraphics.Dispose();
            spiralSweepGraphics.Dispose();
            //giới hạn update ảnh
            OnImageUpdate(scanImage);
            outputImageCircleSweep = circleSweepImage;
            outputImageStraightSweep = straightSweepImage;
            outputImageSpiralSweep = spiralSweepImage;
            outputImageRadarScan = scanImage;
            if (targetCatched == 0)
                catchedTargetFlag = false;//hiện ra đường quét trên scanradar
            else
            {
                catchedTargetFlag = true;
                changeTargetFlag = false;
            }
        }
        //vẽ các vạch chia của màn hình quét cùng với số k pi
        public void DrawStraightSweepdegree(Graphics g, int x, int y, string str)
        {
            g.DrawLine(new Pen(Color.Red), x, y - 7, x, y - 7);
            g.DrawString(str, new Font("Arial", 8), Brushes.Red, (float)(x - 10), (float)(y + 10));
        }
        //vẽ ảnh nền của màn hình quét thẳng
        public void CreatebaseImageStraightSweep(int w, int h)
        {
            Image i = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(i);
            Pen p = new Pen(_lineColor);
            //vẽ ba đường thẳng
            g.DrawLine(p, new Point(0, h / 4), new Point(w, h / 4));
            g.DrawLine(p, new Point(0, h / 2), new Point(w, h / 2));
            g.DrawLine(p, new Point(0, 3 * h / 4), new Point(w, 3 * h / 4));
            //vẽ các điểm chia các đường thẳng
            //đường thẳng 1
            DrawStraightSweepdegree(g, w / 3, h / 4, "100");
            DrawStraightSweepdegree(g, 2 * w / 3, h / 4, "200");
            //đường thẳng 2
            for (int k = 1; k < 10; k++)
            {
                DrawStraightSweepdegree(g, k * w / 10, h / 2, "0");
            }
            //đường thẳng 3
            for (int k = 1; k < 10; k++)
            {
                DrawStraightSweepdegree(g, k * w / 10, 3 * h / 4, k.ToString());
            }
            g.Dispose();
            baseImageStraightSweep = i;
        }
        //vẽ ảnh nền của màn hình quét tròn
        public void CreateBaseImageCircleSweep(int w)
        {
            Image i = new Bitmap(w, w);
            int size = w - 40;
            Graphics g = Graphics.FromImage(i);
            Pen p = new Pen(_lineColor);
            //vẽ 3 vòng tròn
            g.DrawEllipse(new Pen(Color.Green), 20, 20, size, size);
            g.DrawEllipse(new Pen(Color.Green), size / 6 + 20, size / 6 + 20, size * 2 / 3, size * 2 / 3);
            g.DrawEllipse(new Pen(Color.Green), size / 3 + 20, size / 3 + 20, size / 3, size / 3);
            //vẽ các vạch chia
            //vòng tròn ngoài cùng
            DrawCircleSweepdegree(g, 120, size / 2, "100", w);
            DrawCircleSweepdegree(g, 240, size / 2, "200", w);
            DrawCircleSweepdegree(g, 0, size / 2, "300", w);
            g.DrawString("0", new Font("Arial", 8), Brushes.Red, AzRg2XY(0, size / 2 + 20, w));
            //vòng tròn thứ 2
            for (int k = 1; k <= 20; k++)
            {
                DrawCircleSweepdegree(g, 36 * k, size / 3, k.ToString() + "0", w);
            }
            g.DrawString("0", new Font("Arial", 8), Brushes.Red, AzRg2XY(0, size / 3 + 20, w));
            //vòng thứ 3
            for (int k = 1; k <= 10; k++)
            {
                DrawCircleSweepdegree(g, 36 * k, size / 6, k.ToString(), w);
            }
            g.DrawString("0", new Font("Arial", 8), Brushes.Red, AzRg2XY(0, size / 6 + 20, w));
            g.Dispose();
            baseImageCircleSweep = i;
        }
        //vẽ các vạch chia của màn hình quét tròn
        private void DrawCircleSweepdegree(Graphics g, int az, int rg, string str, int size)
        {
            PointF pt1 = AzRg2XY(az, rg - 10, size);
            PointF pt2 = AzRg2XY(az, rg + 10, size);
            g.DrawLine(new Pen(Color.Red), pt1, pt2);
            g.DrawString(str, new Font("arial", 8), Brushes.Red, AzRg2XY(az, rg, size));
        }
        //vẽ ảnh nền của màn hình quét xoắn ốc
        public void CreateBaseImageSpiralSweep(int w)
        {
            Image i = new Bitmap(w, w);
            int size = w - 40;
            Graphics g = Graphics.FromImage(i);
            Pen p = new Pen(_lineColor);

            int iNumRevs = numberOfSpirals;
            int iNumPoints = 300;
            PointF[] aptf = new PointF[iNumPoints];
            float fAnge, fScale;
            for (int k = 0; k < iNumPoints; k++)
            {
                fAnge = (float)(k * 2 * Math.PI / (iNumPoints / iNumRevs));
                fScale = 1 - (float)k / iNumPoints;
                aptf[k].X = (float)((size / 2) * (1 + fScale * Math.Sin(fAnge)));
                aptf[k].Y = (float)((size / 2) * (1 + fScale * Math.Cos(fAnge)));
                if (k % 10 == 0)
                {
                    g.DrawString((300 - k).ToString(), new Font("Arial", 7), Brushes.Red, aptf[k]);
                }
                if (k % 2 == 0)
                {
                    PointF pt1 = new PointF((float)((size / 2) * (1 + fScale * 1.05 * Math.Sin(fAnge))), (float)((size / 2) * (1 + fScale * 1.05 * Math.Cos(fAnge))));
                    PointF pt2 = new PointF((float)((size / 2) * (1 + fScale * 0.95 * Math.Sin(fAnge))), (float)((size / 2) * (1 + fScale * 0.95 * Math.Cos(fAnge))));
                    g.DrawLine(new Pen(Color.Green), pt1, pt2);
                }
            }
            g.DrawLines(new Pen(Color.Green), aptf);
            g.Dispose();
            baseImageSpiralSweep = i;
        }
        //thêm các mục tiêu vào list mục tiêu của radar
        public void AddItem(maybay item)
        {
            bool bFlag = true;
            for (int i = 0; i < TargetList.Count; i++)
            {
                if (TargetList[i].ID == item.ID)
                {
                    TargetList[i] = item;
                    bFlag = false;
                }
            }
            if (bFlag)
            {
                TargetList.Add(item);
            }
            Draw();
        }
        //event xảy ra khi bộ đếm nhảy lên một khoảng thời gian
        void t_Tick(object sender, EventArgs e)
        {
            //nếu không có mục tiêu nào
            if (targetCatched == 0)
            {
                //tăng giảm góc quét
                if (clockwiseScan)
                {
                    _az++;
                }
                else
                {
                    _az--;
                }
                //reset góc phương vị
                //nếu không suất hiện lỗi overflowException
                if (_az >= 360)
                    _az = 0;
                //tạo 3 điểm để xác định cạnh sóng radar
                _pt = AzRg2XY(_az, _size / 2);
                _pt2 = AzRg2XY(_az - 20, _size / 2);
                _pt3 = AzRg2XY(_az + 20, _size / 2);
                //vẽ lại ảnh đầu ra
                Draw();
            }
            //nếu có mục tiêu bám
            else
            {
                foreach (maybay item in TargetList)
                {
                    if (item.ID == targetCatched)
                        _az = getAzimuth(item._current);
                }
                _pt = AzRg2XY(_az, _size / 2);
                _pt2 = AzRg2XY(_az - 20, _size / 2);
                _pt3 = AzRg2XY(_az + 20, _size / 2);
                Draw();
            }
        }
        //hàm chuyển đổi từ góc phương vị cự li sang xy nếu size=size của màn hình scan radar
        public PointF AzRg2XY(int azimuth, int Rg)
        {
            //chuyển góc phương vị sang góc theo trục x
            double angle = (270d + (double)azimuth);
            //chuyển sang radian
            angle *= 0.0174532925d;
            double r, x, y;
            //tính x và y theo size màn hình scan radar có sẵn
            r = Rg;
            x = (((double)_size * 0.5d) + (r * Math.Cos(angle)));
            y = (((double)_size * 0.5d) + (r * Math.Sin(angle)));
            return new PointF((float)x, (float)y);
        }
        //hàm chuyển đổi góc phương vị cự li sang xy nếu size=size cho trước các class khác có thể sử dụng để tính toán
        public PointF AzRg2XY(int Azimuth, int Rg, int size)
        {
            //chuyển sang góc so với trục x
            double angle = (270d + (double)Azimuth);
            //chuyển sang radian
            angle *= 0.0174532925d;
            double r, x, y;
            //tính xy theo size theomanf hình scan radar
            r = Rg;
            x = (((double)_size * 0.5d) + (r * Math.Cos(angle)));
            y = (((double)_size * 0.5d) + (r * Math.Sin(angle)));
            return new PointF((float)x, (float)y);
        }
        public static bool isNummeric(string str)
        {
            char[] chr = str.ToCharArray();
            foreach (char ch in chr)
            {
                if ('0' > ch || ch > '9')
                    return false;
            }
            return true;
        }
        public static int getAzimuth(PointF pt)
        {
            double r, x, y;
            r = _size * 0.5d;//bán kính đường tròn
            //xác định tọa độ xo với tâm
            x = pt.X - r;
            y = pt.Y - r;
            double canh_huyen = Math.Sqrt(x * x + y * y);
            //tính góc so với trục x
            double angle = Math.Acos(x / canh_huyen);
            //đổi sang độ
            angle = angle / 0.0174532925d;
            if (y < 0)
            {
                angle = 360d - angle;
            }
            //chuyển sang góc so với trục y
            double azimuth = angle - 270d;
            if (azimuth < 0) azimuth = azimuth + 360d;
            return (int)azimuth;
        }
        //lấy góc phương vị của một tọa độ đã cho
        public static int getAzimuth(toado td)
        {
            double r, x, y;
            r = _size * 0.5d;//bán kính đường tròn
            //xác định tọa độ xo với tâm
            x = td.X - r;
            y = td.Y - r;
            double canh_huyen = Math.Sqrt(x * x + y * y);
            //tính góc so với trục x
            double angle = Math.Acos(x / canh_huyen);
            //đổi sang độ
            angle = angle / 0.0174532925d;
            if (y < 0)
            {
                angle = 360d - angle;
            }
            //chuyển sang góc so với trục y
            double azimuth = angle - 270d;
            if (azimuth < 0) azimuth = azimuth + 360d;
            return (int)azimuth;
        }
        //lấy cự ly của một tọa độ đã cho
        public static double getRange(toado td)
        {
            double r, x, y;
            r = _size * 0.5d;//bán kính đường tròn
            //xác định tọa độ xo với tâm
            x = td.X - r;
            y = td.Y - r;
            double canh_huyen = Math.Sqrt(x * x + y * y);
            return canh_huyen;
        }
        private void OnImageUpdate(Image i)
        {
            if (ImageUpdate != null)
                ImageUpdate(this, new ImageUpdateEventArgs(i));
        }
        /// <summary>
        /// Event fired when the output image is redrawn
        /// </summary>
        public event ImageUpdateHandler ImageUpdate;
    }
    public delegate void ImageUpdateHandler(object sender, ImageUpdateEventArgs e);
    public class ImageUpdateEventArgs : EventArgs
    {
        Image _image;
        public Image Image
        {
            get
            {
                return _image;
            }
        }
        public ImageUpdateEventArgs(Image i)
        {
            _image = i;
        }

    }
}
