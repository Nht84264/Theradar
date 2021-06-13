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
using Radar;

namespace Theradar
{
    public partial class Form1 : Form
    {
        private Theradar _radar;
        toado td1 = new toado(1, 400, 400, 4000, 1000, "abc");
        toado td2 = new toado(2, 200, 200, 4000, 1000, "abc");
        List<toado> qd1 = new List<toado>();
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        int speed = 400;
        public static List<maybay> listTarget = new List<maybay>();
        public static List<tenlua> listTenlua = new List<tenlua>();
        private object rbthang;
        private object rbnguoc;

        public Form1()
        {
            t.Interval = 500;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
            InitializeComponent();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            _radar = new Radar(pictureBox1.Width, pthang.Width, pthang.Height, ptron.Width)
            {
                numberOfSpirals = 3
            };
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
            muctieu mt = new muctieu();
            mt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //may bay 1- dan su - mau do
            toado toado1 = new toado(1, 439, 451, 10, 1000, "abc");
            toado toado2 = new toado(2, 101, 377, 10, 1000, "abc");
            List<toado> qd = new List<toado>();
            qd.Add(toado1);
            qd.Add(toado2);
            maybay mb = new maybay("Dân sự ", 1, qd, Color.Red);
            Form1.listTarget.Add(mb);
            //may bay 2- dan su- da troi
            toado1 = new toado(1, 239, 480, 8, 800, "abc");
            toado2 = new toado(2, 440, 157, 8, 800, "abc");
            qd = new List<toado>();
            qd.Add(toado1);
            qd.Add(toado2);
            mb = new maybay("Dân sự", 2, qd, Color.Blue);
            Form1.listTarget.Add(mb);
            //may bay 3 - quan su(ta) 
            toado1 = new toado(1, 494, 115, 12, 2000, "abc");
            toado2 = new toado(2, 352, 428, 12, 2000, "abc");
            qd = new List<toado>();
            qd.Add(toado1);
            qd.Add(toado2);
            mb = new maybay("Quân sự  (ta)", 3, qd, Color.Yellow);
            Form1.listTarget.Add(mb);
            //may bay 4
            toado1 = new toado(1, 227, 79, 14, 2000, "abc");
            toado2 = new toado(2, 436, 483, 14, 2000, "abc");
            qd = new List<toado>();
            qd.Add(toado1);
            qd.Add(toado2);
            mb = new maybay("Quân sự (địch)", 4, qd, Color.Purple);
            Form1.listTarget.Add(mb);
            //may bay 5
            toado1 = new toado(1, 58, 242, 6, 1200, "abc");
            toado2 = new toado(2, 512, 372, 6, 1200, "abc");
            qd = new List<toado>();
            qd.Add(toado1);
            qd.Add(toado2);
            mb = new maybay("Quân sự (địch)", 5, qd, Color.Gray);
            Form1.listTarget.Add(mb);
            //may bay 6
            toado1 = new toado(1, 527, 197, 12, 1500, "abc");
            toado2 = new toado(2, 390, 419, 12, 1500, "abc");
            qd = new List<toado>();
            qd.Add(toado1);
            qd.Add(toado2);
            mb = new maybay("Quân sự  (ta)", 6, qd, Color.Pink);
            Form1.listTarget.Add(mb);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
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

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
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
            if (trackbarspeed.Value == 0)
                trackbarspeed.Value = 1;
            _radar.DrawScanInterval = (speed) / trackbarspeed.Value;
            _radar.ImageUpdate += new ImageUpdateHandler(_radar_ImageUpdate);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNoSprial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNoSpiral.Text == "")
                { }
                else
                {
                    _radar.numberOfSpirals = Convert.ToInt32(txtNoSpiral.Text);
                    _radar.CreateBaseImageSpiralSweep(pxoanoc.Width);
                    pxoanoc.Image = _radar.outputImageSpiralSweep;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cbtarget_TextChanged(object sender, EventArgs e)
        {
            if (cbtarget.Text == "")
            {
                _radar.targetCatched = 0;
            }
            else
            {
                if (_radar.targetCatched == 0)
                { }
                else
                    _radar.changeTargetFlag = true;
                int id = Convert.ToInt16(cbtarget.Text);
                _radar.targetCatched = id;
            }

        }

    }
