using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Theradar;

namespace Radar
{
    public partial class muctieu : Form
    {
        Color _topColor = Color.FromArgb(0, 120, 0);
        Color _bottonColor = Color.FromArgb(0, 40, 0);
        Color _linecolor = Color.FromArgb(0, 255, 0);
        Color _targetcolor = Color.FromArgb(255, 0, 0);

        int _size;

        public muctieu()
        {
            InitializeComponent();
            pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);

        }


        private void btAddpoint_Click(object sender, EventArgs e)
        {
            if (txttoado.Text == " ")
            { return; }
            if (!(Radar.isNummeric(txtdocao.Text)) || txtdocao.Text == "")
            {
                MessageBox.Show("độ cao không đúng ");
                return;
            }
            if (!(Radar.isNummeric(txtvantoc.Text)) || txtvantoc.Text == "")
            {
                MessageBox.Show("vận tốc không đúng ");
                return;
            }
            ListViewItem item = new ListViewItem();
            item.Text = txtdiem.Text;
            item.SubItems.Add(txttoado.Text);
            item.SubItems.Add(txtdocao.Text);
            item.SubItems.Add(txtvantoc.Text);
            lvAirline.Items.Add(item);
            int i = Convert.ToInt16(txtdiem.Text);
            i++;
            txtdiem.Text = i.ToString();
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            CreateBaseImage();
            lvAirline.Items.Clear();
            txtdiem.Text = "1";
            txtdocao.Text = "*";
            txttoado.Text = "*";
            txtvantoc.Text = "*";
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            if (lvAirline.Items.Count < 2)
            {
                MessageBox.Show("quỹ đạo cần ít nhất 2 điểm");
                return;
            }
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.ShowDialog();
            Color color = colorDialog1.Color;
            List<toado> qd = new List<toado>();
            for (int k = 0; k < lvAirline.Items.Count; k++)
            {
                ListViewItem Toado = lvAirline.Items[k];
                int stt = Convert.ToInt16(Toado.Text);
                String[] chuoi = Toado.SubItems[1].Text.Split(',');
                Double x = Convert.ToDouble(chuoi[0].ToString());
                Double y = Convert.ToDouble(chuoi[1].ToString());
                toado td = new toado(Convert.ToInt16(Toado.Text), x, y, Convert.ToDouble(Toado.SubItems[2].Text), Convert.ToDouble(Toado.SubItems[3].Text), "abc");
                qd.Add(td);
            }
            int a = Form1.listTarget.Count + 1;
            maybay mb = new maybay(cbLoai.Text, a, qd, color);
            Form1.listTarget.Add(mb);
            ListViewItem item = new ListViewItem();
            item.Text = a.ToString();
            item.SubItems.Add(cbLoai.Text);
            item.BackColor = color;
            lvTarget.Items.Add(item);
        }

        private void txttoado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtvantoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdocao_TextChanged(object sender, EventArgs e)
        {

        }

        private void muctieu_Load(object sender, EventArgs e)
        {
            CreateBaseImage();
            foreach (maybay mb in Form1.listTarget)
            {
                ListViewItem item = new ListViewItem();
                item.Text = mb.ID.ToString();
                item.SubItems.Add(mb._category);
                item.BackColor = mb._color;
                lvTarget.Items.Add(item);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txttoado.Text = e.X.ToString() + "," + e.Y.ToString();
            PointF pt1 = new PointF(e.X, e.Y);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Color _lineColor = Color.FromArgb(255, 255, 0);
            Pen p = new Pen(_lineColor);
            if (lvAirline.Items.Count == 0)
            { }
            else
            {
                ListViewItem item = lvAirline.Items[lvAirline.Items.Count - 1];
                String[] chuoi = item.SubItems[1].Text.Split(',');
                PointF pt2 = new PointF((float)Convert.ToDouble(chuoi[0].ToString()), (float)Convert.ToDouble(chuoi[1].ToString()));
                g.DrawLine(p, pt1, pt2);
            }
            g.Dispose();
            pictureBox1.Image = pictureBox1.Image;
        }
        private void CreateBaseImage()
        {
            _size = pictureBox1.Width;
            Image i = new Bitmap(_size, _size);
            Graphics g = Graphics.FromImage(i);
            Pen p = new Pen(_linecolor);
            //làm cho anh dep hơn
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.Bicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //draw the background of the radar
            g.FillEllipse(new LinearGradientBrush(new Point((int)(_size / 2), 0), new Point((int)(_size / 2), _size - 1), _topColor, _bottonColor), 0, 0, _size - 1, _size - 1);
            //draw the outer ring (0” elevation)
            g.DrawEllipse(p, 0, 0, _size - 1, _size - 1);
            // draw the inner ring (60’ elevation)
            int interval = _size / 5;
            for (int j = 1; j < 5; j++)
            {
                int interval1 = interval * j;
                g.DrawEllipse(p, (_size - interval1) / 2, (_size - interval1) / 2, interval1, interval1);
                Font ab = new Font("arial", 10);
                g.DrawString((30 - 6 * j).ToString() + "0", ab, Brushes.Red, interval1 / 2, _size / 2);
                g.DrawString((30 - 6 * j).ToString() + "0", ab, Brushes.Red, _size - interval1 / 2 - 15, _size / 2);
            }
            //draw the x and y axis lines
            g.DrawLine(p, new Point(0, (int)(_size / 2)), new Point(_size - 1, (int)(_size / 2)));
            g.DrawLine(p, new Point((int)(_size / 2), 0), new Point((int)(_size / 2), _size - 1));
            Font abc = new Font("Arial", 10);
            g.DrawString("w", abc, Brushes.Red, 0, _size / 2);
            g.DrawString("n", abc, Brushes.Red, _size / 2, 0);
            g.DrawString("e", abc, Brushes.Red, _size - 15, _size / 2);
            g.DrawString("s", abc, Brushes.Red, _size / 2, _size - 15);
            // release the graphics object
            g.Dispose();
            //update the base image
            pictureBox1.Image = i;
        }

        private void lvTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTarget.SelectedItems.Count == 0)
            { return; }
            ListViewItem item = lvTarget.SelectedItems[0];
            lvAirline.Items.Clear();
            foreach (maybay mb in Form1.listTarget)
            {
                if (mb.ID.ToString() == item.Text)
                {
                    foreach (toado td in mb.airline)
                    {
                        ListViewItem item1 = new ListViewItem();
                        item1.Text = td.stt.ToString();
                        item1.SubItems.Add(td.X.ToString() + "," + td.Y.ToString());
                        item1.SubItems.Add(td.Z.ToString());
                        item1.SubItems.Add(td.velocity.ToString());
                        lvAirline.Items.Add(item1);
                    }
                    for (int i = 0; i < mb.airline.Count - 1; i++)
                    {
                        toado td1 = mb.airline[i];
                        toado td2 = mb.airline[i + 1];
                        PointF pt1 = new PointF((float)td1.X, (float)td1.Y);
                        PointF pt2 = new PointF((float)td2.X, (float)td2.Y);
                        Graphics g = Graphics.FromImage(pictureBox1.Image);
                        Color _lineColor = Color.FromArgb(255, 255, 0);
                        Pen p = new Pen(_lineColor);
                        g.DrawRectangle(p, (float)td1.X, (float)td1.Y, 10, 10);
                        g.DrawRectangle(p, (float)td2.X, (float)td2.Y, 10, 10);
                        g.DrawLine(p, pt1, pt2);
                        g.Dispose();
                        pictureBox1.Image = pictureBox1.Image;
                    }
                }
            }
        }
    }
}
