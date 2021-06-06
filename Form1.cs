using System;
using System.Collections;
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
using System.Windows;


namespace Theradar
{
    public partial class Form1 : Form
    {
        Radar _radar;
        toado td1 = new toado(1, 400, 400, 4000, 1000, "abc");
        toado td2 = new toado(2, 200, 200, 4000, 1000, "abc");
        List<toado> qd1 = new List<toado>();
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        int speed = 400;
        public static List<maybay> listTarget = new List<maybay>();
        public static List<tenlua> listTenlua = new List<tenlua>();

        public Form1()
        {
            t.Interval = 500;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _radar = new Radar(pictureBox1.Width, pthang.Width, pthang.Height, ptron.Width);
            _radar.numberOfSpirals = 3;
            pictureBox1.Image = _radar.Image;
            _radar.ImageUpdate += new ImageUpdateHandler(_radar_ImageUpdate);
            _radar.DrawScanInterval = speed;
            txtMaxAngle.Text = _radar.maxAngle.ToString();
            trackbarspeed.Maximum = 20;
            trackbarspeed.TickFrequency = 1;
            pthang.Image = _radar.outputImageStraightSweep;
            ptron.Image = _radar.outputImageCircleSweep;
            pxoanoc.Image = _radar.outputImageSpiralSweep;
        }
        void _radar_ImageUpdate(object sender, ImageUpdateEventArgs e)
        {
            // this event is important to catch!
            pictureBox1.Image = e.Image;
            pthang.Image = _radar.outputImageStraightSweep;
            ptron.Image = _radar.outputImageCircleSweep;
            pxoanoc.Image = _radar.outputImageSpiralSweep;
            txtAzimuth.Text = _radar._az.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnguoc.Checked)
                _radar.clockwiseScan = false;
            _radar.ImageUpdate += new ImageUpdateHandler(_radar_ImageUpdate);
        }

        private void bttieudiet_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

            private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void rbtthang_CheckedChanged(object sender, EventArgs e)
        {
            if (rbthang.Checked)
            {
                pthang.Visible = true;
                ptron.Visible = false;
                pxoanoc.Visible = false;
                txtNoSpiral.Visible = false;
                label1.Visible = false;
            }
            else if (rbtron.Checked)
            {
                pthang.Visible = false;
                ptron.Visible = true;
                pxoanoc.Visible = false;
                txtNoSpiral.Visible = false;
                label1.Visible = false;
            }
            else if (rbxoanoc.Checked)
            {
                pthang.Visible = false;
                ptron.Visible = false;
                pxoanoc.Visible = true;
                txtNoSpiral.Visible = true;
                label1.Visible = true;

            }
        }

        private void rbtthuan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbthuan.Checked)
                _radar.clockwiseScan = true;
            _radar.ImageUpdate += new ImageUpdateHandler(_radar_ImageUpdate);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void trackbarspeed_Scroll(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
