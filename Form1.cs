// Decompiled with JetBrains decompiler
// Type: diao.Form1
// Assembly: diao, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9B9CD16-F024-45F9-8D13-D1172328D6F7
// Assembly location: F:\engraver\LaserEngraver\Laser Framework4.exe

using AForge.Imaging.Filters;
using CCWin;
using CCWin.SkinClass;
using CCWin.SkinControl;
using netDxf; //Read/Write AutoCad Files??
using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace diao
{
    public class Form1 : CCSkinMain
    {
        private int xian_k = 1600;
        private int xian_g = 1520;
        private int bushu = 1;
        private double fen_bian_lv = 0.05;
        private double fen_bian_lv_in = 0.001968505;
        private Bitmap tu_yuan = new Bitmap(1, 1);
        private Bitmap pictureScaling = new Bitmap(1, 1);
        private Bitmap tu_diaoke = new Bitmap(1, 1);
        private Bitmap bei_jing;
        private bool engraverConnected;
        private int fang_shi = 1;
        private double bi;
        private bool jinru;
        private bool openImage;
        private bool openText;
        private bool z_anxia;
        private int z_x;
        private int z_y;
        private bool an_xia;
        private System.Drawing.Point yi_dian = new System.Drawing.Point();
        private System.Drawing.Point qi_dian = new System.Drawing.Point();
        private bool an_xia_wz;
        private int zuo;
        private int you;
        private int shang;
        private int xia;
        private bool showingPreview;
        private bool millimeters = true;
        private bool fan_se;
        private bool returnCode;
        private int returnValue;
        private bool fs_wc;
        private int m_jd;
        private bool stopped;
        private bool zanting;
        private bool pause;
        private bool tj_zt;
        private bool isRunning;
        private Bitmap hf_bmp;
        public static Form1 m_Form1;
        private byte ruo = 70;
        private int hang_yan_shi = 100;
        private int TIM_chong_zhuang_zhi = 1000;
        private byte BU = 4;
        private byte x_buchang = 1;
        private byte y_buchang = 1;
        private int SS = 200;
        private int MM1 = 870;
        private int KUAI = 600;
        private int kuang_sd = 5;
        private IniFiles ini = new IniFiles(Application.StartupPath + "\\pei_zhi.ini");
        private List<Form1.Dian> dian = new List<Form1.Dian>();
        private Form1.Dian dian_lishi = new Form1.Dian();
        private List<Form1.Xian> xian = new List<Form1.Xian>();
        private int bu = 8;
        private int k_kuan;
        private int k_gao;
        private bool shi_liang;
        private List<PointF[]> dian_shu_zu = new List<PointF[]>();
        private int progress;//Percentage?
        private int shu_; //Number, count, quantity or volume?
        private Form1.Xian xian_linshi = new Form1.Xian();
        private int time;// Time - Moments - Events?
        private bool qu_xinghao;//To get/Retrieve?
        public static object locker = new object();
        private string modelNumber = "1 6 04";
        private string selectedLanguge = "ch";
        private string modelVersion = "K4 V2.5";
        private string connectDeviceString = "Connect Device";
        private string disconnectDeviceString = "Disconnect Device";
        private string okString = "Ok";
        private string str4 = "Enter Text";
        private string str5 = "Saved Successfully:";
        private string pauseString = "Pause";
        private string continueString = "Continue";
        private string startString = "Start";
        private string str9 = "Failed to connect to device! Please check whether the data cable is plugged in. Is the driver installed?";
        private string stopPreviewString = "Please stop previewing location first!";
        private string pictureString = "Picture";
        private string str12 = "Set Up";
        private string str13 = "Skin";
        private string str14 = "Image processing method";
        private string str15 = "Laser Power";
        private string str16 = "Engraving Depth";
        private string str17 = "Preview Location";
        private string str18 = "Reset Coordinates";
        private string widthString = "Width";
        private string heightString = "Height";
        private string openPictureString = "Open the Picture";
        private string str22 = "Please connect the device first!";
        private string str23 = "Batch convert pictures to BMP";
        private string lockAspectString = "Lock aspect ratio\r\n";
        private string stopString = "Stop";
        private Bitmap image;
        private IContainer components;
        private SkinPanel change_half;
        private SkinButton btnFlip;
        private SkinButton btnRotate;
        private SkinButton but_trash;
        private SkinButton but_fanse;
        private SkinButton btn_mmToInch;
        private SkinButton btnAddText;
        private SkinButton btn_disconnectConnectDevice;
        private SkinButton btnOpenPicture;
        private SkinButton btn_start;
        private SkinButton btnStop;
        private SkinTrackBar tiao_gonglv;
        private SkinComboBox pictureProcessingDropDownMenu;
        private SkinLabel skinLabel1;
        private SkinTrackBar tiao_shendu;
        private SkinLabel skinLabel2;
        private SkinLabel skinLabel3;
        private SkinLabel skinLabel4;
        private SkinLabel skinLabel5;
        private SkinButton btnPreview;
        private SkinButton btnResetCoordinates;
        private SkinLabel widthLabel;
        private SkinLabel heightLabel;
        private SkinLabel mmInchLabel1;
        private SkinLabel mmInchLabel2;
        private SkinButton btn_save;
        private SerialPort com;
        private SkinPanel skinPanel2;
        private OpenFileDialog bmpFileDialog;
        private SkinPictureBox hua_ban;
        private System.Windows.Forms.Timer ding_cl;
        private TextBox txtBoxText; //Textbox when clicking the new text button
        private Panel panel6;
        private Label label17;
        private Label label16;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton5;
        private ListBox listBox1;
        private TrackBar trackBar5;
        private SkinLabel skinLabel6;
        private TextBox txtBoxWidth;
        private TextBox txtBoxHeight;
        private SkinPanel LED;
        private SkinButton but_tuoji;
        private SkinProgressBar jdt;
        private SkinButton btnSettings;
        private ContextMenuStrip menu;
        private ToolStripMenuItem chineseToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem japaneseToolStripMenuItem;
        private ToolStripMenuItem setUpToolStripMenuItem;
        private ToolStripMenuItem skinToolStripMenuItem;
        private OpenFileDialog pi_fu;
        private CheckBox lockAspectRatioChkBox;
        private ToolStripMenuItem BMPToolStripMenuItem;
        private SkinLabel elapsedTimeLbl;
        private System.Windows.Forms.Timer elapsedTimeTimer;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label18;
        private Label label19;
        private Label label20;

        private Bitmap cartoonPaint_MouseDown(Bitmap bb)
        {
            this.image = new Bitmap((System.Drawing.Image)bb);
            if (this.image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                Bitmap bitmap = AForge.Imaging.Image.Clone(this.image, PixelFormat.Format24bppRgb);
                this.image.Dispose();
                this.image = bitmap;
            }
            Bitmap image = Grayscale.CommonAlgorithms.BT709.Apply(this.image);
            Bitmap bitmap1 = (Bitmap)image.Clone();
            Bitmap bitmap2 = (Bitmap)image.Clone();
            Invert invert = new Invert();
            invert.ApplyInPlace(bitmap1);
            new DifferenceEdgeDetector().ApplyInPlace(image);
            Bitmap bitmap3 = new MoveTowards(bitmap1, 10).Apply(image);
            invert.ApplyInPlace(bitmap3);
            return new Bitmap(bitmap3);
        }

        private void hui_fu() => BeginInvoke(new MyInvoke(hf));
        private void ting_zhi_dk() => BeginInvoke(new MyInvoke(tz));

        private void hf()
        {
            tu_diaoke = new Bitmap(hf_bmp);
            hua_ban.BackgroundImage = tu_diaoke;
            hua_ban.Refresh();
        }

        private void shua_xin() => this.BeginInvoke((Delegate)new Form1.MyInvoke(this.sx));

        private void sx() => this.hua_hong();

        private void shua_xin_kg() => this.BeginInvoke((Delegate)new Form1.MyInvoke(this.kg));

        private void jin_du_() => this.BeginInvoke((Delegate)new Form1.MyInvoke(this.jd));

        private void jin_du_guan() => this.BeginInvoke((Delegate)new Form1.MyInvoke(this.jdg));

        private void jd()
        {
            lock (Form1.locker)
            {
                if (this.m_jd < 0 || this.m_jd > 100)
                    return;
                this.jdt.Visible = true;
                this.jdt.Value = this.m_jd;
            }
        }

        private void hua_hong() => this.hua_ban.Refresh();

        private void jdg() => this.jdt.Visible = false;

        private void kg()
        {
            double num1;
            double num2;
            if (this.millimeters)
            {
                num1 = (double)(this.you - this.zuo) * this.fen_bian_lv;
                num2 = (double)(this.xia - this.shang) * this.fen_bian_lv;
            }
            else
            {
                num1 = (double)(this.you - this.zuo) * this.fen_bian_lv_in;
                num2 = (double)(this.xia - this.shang) * this.fen_bian_lv_in;
            }
            this.txtBoxWidth.Text = num1.ToString();
            this.txtBoxHeight.Text = num2.ToString();
        }

        private void zi_ti()
        {
            FontStyle style = FontStyle.Regular;
            if (this.radioButton5.Checked)
                style = FontStyle.Regular;
            if (this.radioButton2.Checked)
                style = FontStyle.Bold;
            if (this.radioButton3.Checked)
                style = FontStyle.Italic;
            if (this.radioButton4.Checked)
                style = FontStyle.Bold | FontStyle.Italic;
            try
            {
                this.txtBoxText.Font = new Font(this.listBox1.Text, (float)(this.trackBar5.Value * 2), style, GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
            }
            this.txtBoxText.Visible = true;
            this.txtBoxText.Focus();
            this.resizeNewTextBox();
        }

        private Bitmap qu_tu()
        {
            Bitmap bitmap = new Bitmap((int)((double)this.txtBoxText.Width * ((double)this.xian_k / (double)this.change_half.Width)), (int)((double)this.txtBoxText.Height * ((double)this.xian_k / (double)this.change_half.Width)));
            Graphics graphics = Graphics.FromImage((System.Drawing.Image)bitmap);
            graphics.Clear(Color.White);
            FontStyle style = FontStyle.Regular;
            if (this.radioButton5.Checked)
                style = FontStyle.Regular;
            if (this.radioButton2.Checked)
                style = FontStyle.Bold;
            if (this.radioButton3.Checked)
                style = FontStyle.Italic;
            if (this.radioButton4.Checked)
                style = FontStyle.Bold | FontStyle.Italic;
            Font font = new Font("宋体", 16f, style, GraphicsUnit.Pixel);
            try
            {
                font = this.xian_k != 1600 ? new Font(this.listBox1.Text, (float)(this.trackBar5.Value * 12), style, GraphicsUnit.Pixel) : new Font(this.listBox1.Text, (float)this.trackBar5.Value * 6.4f, style, GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
            }
            graphics.DrawString(this.txtBoxText.Text, font, Brushes.Black, 0.0f, 0.0f);
            graphics.Dispose();
            return bitmap;
        }

        private void resizeNewTextBox()
        {
            if (txtBoxText.Text == "")
                return;

            SizeF sizeF = txtBoxText.CreateGraphics().MeasureString(txtBoxText.Text, txtBoxText.Font);
            txtBoxText.Size = new Size((int)sizeF.Width, (int)sizeF.Height);
        }

        private void cl()
        {
            jinru = true;
            pictureScaling = resizeBitmap(tu_yuan, hua_ban.Width * (xian_k / change_half.Width), hua_ban.Height * (xian_k / change_half.Width));
            chu_li();
            ding_cl.Enabled = false;
            jinru = false;
        }

        public Bitmap resizeBitmap(Bitmap bmp, int newWidth, int newHeight)
        {
            try
            {
                Bitmap bitmap = new Bitmap(newWidth, newHeight);//Create an empty bitmap
                Graphics graphics = Graphics.FromImage(bitmap);//Create a graphics object from the empty bitmap
                graphics.InterpolationMode = InterpolationMode.Low;
                graphics.DrawImage(bmp, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);//Draw the old bitmap to the new object with the new size
                graphics.Dispose();
                return bitmap;
            }
            catch
            {
                return null;
            }
        }

        public void qu_bian()
        {
            if (tu_diaoke == null)
                return;
            Bitmap bitmap = new Bitmap(tu_diaoke);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr scan0 = bitmapdata.Scan0;
            bool flag = false;
            int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
            byte[] destination = new byte[length];
            Marshal.Copy(scan0, destination, 0, length);
            int num1 = bitmap.Width * 4;
            for (int index = 0; index < destination.Length; index += 4)
            {
                int num2 = ((int)destination[index] * 30 + (int)destination[index + 1] * 59 + (int)destination[index + 2] * 11) / 100;
                if (!flag)
                {
                    if (destination[index] == (byte)0)
                    {
                        flag = true;
                        shang = index / num1;
                        xia = shang;
                        zuo = index % num1 / 4;
                        you = zuo;
                    }
                }
                else if (destination[index] == (byte)0)
                {
                    if (zuo > index % num1 / 4)
                        zuo = index % num1 / 4;

                    if (you < index % num1 / 4)
                        you = index % num1 / 4;

                    if (xia < index / num1)
                        xia = index / num1;
                }
            }
            bitmap.UnlockBits(bitmapdata);
        }


        public Bitmap hui_du(Bitmap bb)
        {
            if (bb == null)
                return null;
            Bitmap bitmap = new Bitmap(bb);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr scan0 = bitmapdata.Scan0;
            int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
            byte[] destination = new byte[length];
            byte[] source = new byte[length];
            Marshal.Copy(scan0, destination, 0, length);

            for (int index = 0; index < destination.Length; index += 4)
            {
                //Multiply red channel by 30, green channel by 59, and blue by 11. Sum them together and divide by 100 to get a new brightness.
                int num = (destination[index] * 30 + destination[index + 1] * 59 + destination[index + 2] * 11) / 100;

                //This if block clamps num to 255
                if (num > byte.MaxValue)
                    num = byte.MaxValue;
                else if (num < 0)
                    num = 0;

                if (destination[index + 3] == 0)
                    num = byte.MaxValue;

                source[index] = (byte)num;
                source[index + 1] = (byte)num;
                source[index + 2] = (byte)num;
                source[index + 3] = byte.MaxValue;
            }

            Marshal.Copy(source, 0, scan0, length);
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        public Bitmap blackWhite(int zhi)
        {
            if (pictureScaling == null)
                return null;
            Bitmap bitmap = new Bitmap(pictureScaling);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr scan0 = bitmapdata.Scan0;
            int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
            byte[] destination = new byte[length];
            byte[] source = new byte[length];
            Marshal.Copy(scan0, destination, 0, length);
            for (int index = 0; index < destination.Length; index += 4)
            {
                int maxValue = ((int)destination[index] * 30 + (int)destination[index + 1] * 59 + (int)destination[index + 2] * 11) / 100 <= zhi ? 0 : (int)byte.MaxValue;
                if (destination[index + 3] == (byte)0)
                    maxValue = (int)byte.MaxValue;
                source[index] = (byte)maxValue;
                source[index + 1] = (byte)maxValue;
                source[index + 2] = (byte)maxValue;
                source[index + 3] = byte.MaxValue;
            }
            Marshal.Copy(source, 0, scan0, length);
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        public Bitmap dou_dong(Bitmap bb, int zhi)
        {
            Bitmap bitmap = new Bitmap((System.Drawing.Image)bb);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr scan0 = bitmapdata.Scan0;
            int length1 = Math.Abs(bitmapdata.Stride) * bitmap.Height;
            byte[] destination = new byte[length1];
            byte[] source = new byte[length1];
            Marshal.Copy(scan0, destination, 0, length1);
            int length2 = destination.Length;
            int width = bitmap.Width;
            for (int index1 = 0; index1 < length2; index1 += 4)
            {
                int num1 = (int)destination[index1];
                if (num1 > 128)
                    num1 += zhi;
                if (num1 < zhi)
                    num1 -= zhi;
                if (num1 > (int)byte.MaxValue)
                    num1 = (int)byte.MaxValue;
                if (num1 < 0)
                    num1 = 0;
                int num2;
                int num3;
                if (num1 > 128)
                {
                    if (num1 > (int)byte.MaxValue)
                        num1 = (int)byte.MaxValue;
                    num2 = num1 - (int)byte.MaxValue;
                    num3 = (int)byte.MaxValue;
                }
                else
                {
                    if (num1 < 0)
                        num1 = 0;
                    num2 = num1;
                    num3 = 0;
                }
                int num4 = 375 * num2 / 1000;
                int num5 = 25 * num2 / 100;
                int num6 = width * 4;
                int index2 = index1 + 4;
                int index3 = index1 + num6;
                if (index2 < length2)
                {
                    int num7 = (int)destination[index2] + num4;
                    if (num7 > (int)byte.MaxValue)
                        num7 = (int)byte.MaxValue;
                    if (num7 < 0)
                        num7 = 0;
                    destination[index2] = (byte)num7;
                }
                if (index3 < length2)
                {
                    int num8 = (int)destination[index1 + num6] + num4;
                    if (num8 > (int)byte.MaxValue)
                        num8 = (int)byte.MaxValue;
                    if (num8 < 0)
                        num8 = 0;
                    destination[index3] = (byte)num8;
                }
                if (index3 + 4 < length2)
                {
                    int num9 = (int)destination[index3 + 1] + num5;
                    if (num9 > (int)byte.MaxValue)
                        num9 = (int)byte.MaxValue;
                    if (num9 < 0)
                        num9 = 0;
                    destination[index3 + 4] = (byte)num9;
                }
                if (destination[index1 + 3] == (byte)0)
                    num3 = (int)byte.MaxValue;
                source[index1] = (byte)num3;
                source[index1 + 1] = (byte)num3;
                source[index1 + 2] = (byte)num3;
                source[index1 + 3] = byte.MaxValue;
            }
            Marshal.Copy(source, 0, scan0, length1);
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        public Bitmap fanse(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr scan0 = bitmapdata.Scan0;
            int length = Math.Abs(bitmapdata.Stride) * bmp.Height;
            byte[] destination = new byte[length];
            byte[] source = new byte[length];
            Marshal.Copy(scan0, destination, 0, length);
            for (int index = 0; index < destination.Length; index += 4)
            {
                int maxValue = destination[index] != (byte)0 ? 0 : (int)byte.MaxValue;
                source[index] = (byte)maxValue;
                source[index + 1] = (byte)maxValue;
                source[index + 2] = (byte)maxValue;
                source[index + 3] = byte.MaxValue;
            }
            Marshal.Copy(source, 0, scan0, length);
            bmp.UnlockBits(bitmapdata);
            return bmp;
        }

        public Bitmap qu_lunkuo(Bitmap bb)
        {
            Bitmap bitmap = new Bitmap((System.Drawing.Image)bb);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr scan0 = bitmapdata.Scan0;
            int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
            byte[] destination = new byte[length];
            byte[] source = new byte[length];
            for (int index = 0; index < length; ++index)
                source[index] = byte.MaxValue;
            Marshal.Copy(scan0, destination, 0, length);
            for (int index = bitmap.Width * 4; index < destination.Length; index += 4)
            {
                if ((int)destination[index] != (int)destination[index - 4] || (int)destination[index] != (int)destination[index - bitmap.Width * 4])
                {
                    source[index] = (byte)0;
                    source[index + 1] = (byte)0;
                    source[index + 2] = (byte)0;
                    source[index + 3] = byte.MaxValue;
                }
            }
            Marshal.Copy(source, 0, scan0, length);
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        public Bitmap fu_diao(Bitmap bb)
        {
            Bitmap bitmap = new Bitmap((System.Drawing.Image)bb);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr scan0 = bitmapdata.Scan0;
            int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
            byte[] destination = new byte[length];
            byte[] source = new byte[length];
            for (int index = 0; index < length; ++index)
                source[index] = byte.MaxValue;
            Marshal.Copy(scan0, destination, 0, length);
            int num1 = bitmap.Width * 4;
            for (int index = bitmap.Width * 4; index < destination.Length; index += 4)
            {
                if (index + num1 + 6 < num1)
                {
                    int num2 = (int)source[index];
                    int num3 = (int)source[index + 1];
                    int num4 = (int)source[index + 2];
                    int num5 = (int)source[index + num1 + 4];
                    int num6 = (int)source[index + num1 + 5];
                    int num7 = (int)source[index + num1 + 6];
                    int num8 = Math.Abs(num2 - num5 + 128);
                    int num9 = Math.Abs(num3 - num6 + 128);
                    int num10 = Math.Abs(num4 - num7 + 128);
                    if (num8 > (int)byte.MaxValue)
                        num8 = (int)byte.MaxValue;
                    if (num8 < 0)
                        num8 = 0;
                    if (num9 > (int)byte.MaxValue)
                        num9 = (int)byte.MaxValue;
                    if (num9 < 0)
                        num9 = 0;
                    if (num10 > (int)byte.MaxValue)
                        num10 = (int)byte.MaxValue;
                    if (num10 < 0)
                        num10 = 0;
                    source[index] = (byte)num8;
                    source[index + 1] = (byte)num9;
                    source[index + 2] = (byte)num10;
                    source[index + 3] = byte.MaxValue;
                }
            }
            Marshal.Copy(source, 0, scan0, length);
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        private void fu()
        {
            try
            {
                int height = this.tu_diaoke.Height;
                int width = this.tu_diaoke.Width;
                Bitmap bitmap = new Bitmap(width, height);
                Bitmap tuDiaoke = this.tu_diaoke;
                for (int x = 0; x < width - 1; ++x)
                {
                    for (int y = 0; y < height - 1; ++y)
                    {
                        Color pixel1 = tuDiaoke.GetPixel(x, y);
                        Color pixel2 = tuDiaoke.GetPixel(x + 1, y + 1);
                        int red = Math.Abs((int)pixel1.R - (int)pixel2.R + 128);
                        int green = Math.Abs((int)pixel1.G - (int)pixel2.G + 128);
                        int blue = Math.Abs((int)pixel1.B - (int)pixel2.B + 128);
                        if (red > (int)byte.MaxValue)
                            red = (int)byte.MaxValue;
                        if (red < 0)
                            red = 0;
                        if (green > (int)byte.MaxValue)
                            green = (int)byte.MaxValue;
                        if (green < 0)
                            green = 0;
                        if (blue > (int)byte.MaxValue)
                            blue = (int)byte.MaxValue;
                        if (blue < 0)
                            blue = 0;
                        bitmap.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }
                this.tu_diaoke = bitmap;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private Bitmap di_pian(Bitmap bb)
        {
            Bitmap bitmap = new Bitmap((System.Drawing.Image)bb);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr scan0 = bitmapdata.Scan0;
            int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
            byte[] destination = new byte[length];
            byte[] source = new byte[length];
            for (int index = 0; index < length; ++index)
                source[index] = byte.MaxValue;
            Marshal.Copy(scan0, destination, 0, length);
            for (int index = bitmap.Width * 4; index < destination.Length; index += 4)
            {
                source[index] = (byte)((uint)byte.MaxValue - (uint)source[index]);
                source[index + 1] = (byte)((uint)byte.MaxValue - (uint)source[index + 1]);
                source[index + 2] = (byte)((uint)byte.MaxValue - (uint)source[index + 2]);
                source[index + 3] = byte.MaxValue;
            }
            Marshal.Copy(source, 0, scan0, length);
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        private Bitmap gao_si(Bitmap bb)
        {
            int height = bb.Height;
            int width = bb.Width;
            Bitmap bitmap1 = new Bitmap(width, height);
            try
            {
                Bitmap bitmap2 = bb;
                int[] numArray = new int[9]
                {
          1,
          2,
          1,
          2,
          4,
          2,
          1,
          2,
          1
                };
                for (int index1 = 1; index1 < width - 1; ++index1)
                {
                    for (int index2 = 1; index2 < height - 1; ++index2)
                    {
                        int num1 = 0;
                        int num2 = 0;
                        int num3 = 0;
                        int index3 = 0;
                        for (int index4 = -1; index4 <= 1; ++index4)
                        {
                            for (int index5 = -1; index5 <= 1; ++index5)
                            {
                                Color pixel = bitmap2.GetPixel(index1 + index5, index2 + index4);
                                num1 += (int)pixel.R * numArray[index3];
                                num2 += (int)pixel.G * numArray[index3];
                                num3 += (int)pixel.B * numArray[index3];
                                ++index3;
                            }
                        }
                        int num4 = num1 / 16;
                        int num5 = num2 / 16;
                        int num6 = num3 / 16;
                        int num7 = num4 > (int)byte.MaxValue ? (int)byte.MaxValue : num4;
                        int red = num7 < 0 ? 0 : num7;
                        int num8 = num5 > (int)byte.MaxValue ? (int)byte.MaxValue : num5;
                        int green = num8 < 0 ? 0 : num8;
                        int num9 = num6 > (int)byte.MaxValue ? (int)byte.MaxValue : num6;
                        int blue = num9 < 0 ? 0 : num9;
                        bitmap1.SetPixel(index1 - 1, index2 - 1, Color.FromArgb(red, green, blue));
                    }
                }
                return bitmap1;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "信息提示");
            }
            return bitmap1;
        }

        private Bitmap su_miao(Bitmap hd, Bitmap gs)
        {
            Bitmap bitmap1 = new Bitmap((System.Drawing.Image)hd);
            Bitmap bitmap2 = new Bitmap((System.Drawing.Image)gs);
            Rectangle rect = new Rectangle(0, 0, bitmap1.Width, bitmap1.Height);
            BitmapData bitmapdata = bitmap1.LockBits(rect, ImageLockMode.ReadWrite, bitmap1.PixelFormat);
            BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadWrite, bitmap2.PixelFormat);
            IntPtr scan0_1 = bitmapdata.Scan0;
            IntPtr scan0_2 = bitmapData.Scan0;
            int length = Math.Abs(bitmapdata.Stride) * bitmap1.Height;
            byte[] destination1 = new byte[length];
            byte[] source = new byte[length];
            byte[] destination2 = new byte[length];
            for (int index = 0; index < length; ++index)
                source[index] = byte.MaxValue;
            Marshal.Copy(scan0_1, destination1, 0, length);
            Marshal.Copy(scan0_2, destination2, 0, length);
            for (int index = bitmap1.Width * 4; index < destination1.Length; index += 4)
            {
                int num = (int)destination1[index] + (int)destination1[index] * (int)destination2[index] / ((int)byte.MaxValue - (int)destination2[index]);
                if (num > 33)
                    num = (int)byte.MaxValue;
                source[index] = (byte)num;
                source[index + 1] = (byte)num;
                source[index + 2] = (byte)num;
                source[index + 3] = byte.MaxValue;
            }
            Marshal.Copy(source, 0, scan0_1, length);
            bitmap1.UnlockBits(bitmapdata);
            return bitmap1;
        }

        private void chu_li()
        {
            switch (fang_shi)
            {
                case 1:
                    tu_diaoke = blackWhite(128);
                    break;
                case 2:
                    tu_diaoke = dou_dong(pictureScaling, 30);
                    break;
                case 3:
                    tu_diaoke = blackWhite(128);
                    Bitmap bb = new Bitmap(tu_diaoke.Width + 4, tu_diaoke.Height + 4);
                    Graphics graphics = Graphics.FromImage(bb);
                    graphics.Clear(Color.White);
                    graphics.DrawImage(tu_diaoke, new PointF(2f, 2f));
                    graphics.Dispose();
                    tu_diaoke = qu_lunkuo(bb);
                    bb.Dispose();
                    break;
                case 4:
                    tu_diaoke = cartoonPaint_MouseDown(pictureScaling);
                    tu_diaoke = dou_dong(tu_diaoke, 0);
                    break;
            }
            if (fan_se)
                tu_diaoke = fanse(tu_diaoke);

            qu_bian();
            shua_xin_kg();
            hua_ban.BackgroundImage = tu_diaoke;
        }

        //Never used?
        public static int GetComNum()
        {
            int comNum = -1;
            foreach (string str in GetHarewareInfo(HardwareEnum.Win32_PnPEntity, "Name"))
            {
                if (str.Length >= 23 && str.Contains("CH340"))
                {
                    int num1 = str.IndexOf("(") + 3;
                    int num2 = str.IndexOf(")");
                    comNum = Convert.ToInt32(str.Substring(num1 + 1, num2 - num1 - 1));
                }
            }
            return comNum;
        }

        private static string[] GetHarewareInfo(Form1.HardwareEnum hardType, string propKey)
        {
            List<string> stringList = new List<string>();
            try
            {
                using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from " + (object)hardType))
                {
                    foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
                    {
                        if (managementBaseObject.Properties[propKey].Value != null)
                        {
                            string str = managementBaseObject.Properties[propKey].Value.ToString();
                            stringList.Add(str);
                        }
                    }
                }
                return stringList.ToArray();
            }
            catch
            {
                return (string[])null;
            }
            finally
            {
            }
        }

        private bool connection()
        {
            returnCode = false;
            bool flag = false;
            foreach (string portName in SerialPort.GetPortNames())
            {
                try
                {
                    com.Close();
                    com.PortName = portName;
                    com.Open();
                    com.Write(new byte[4]{10, 0, 4, 0 }, 0, 4);
                    int num = 40;
                    while (num-- > 0)
                    {
                        Application.DoEvents();
                        Thread.Sleep(10);
                        if (returnCode)
                            return true;
                    }
                }
                catch (Exception ex)
                {
                    com.Close();
                }
            }
            com.Close();
            return flag;
        }

        public Form1()
        {
            InitializeComponent();
            m_Form1 = this;
        }

        public bool settings()
        {
            if (!com.IsOpen)
                return false;
            try
            {
                com.Write(new byte[19]
                {
                40,
                0,
                19,
                ruo,
                (byte) (hang_yan_shi >> 8),
                (byte) hang_yan_shi,
                (byte) (TIM_chong_zhuang_zhi >> 8),
                (byte) TIM_chong_zhuang_zhi,
                BU,
                x_buchang,
                y_buchang,
                (byte) (SS >> 8),
                (byte) SS,
                (byte) (MM1 >> 8),
                (byte) MM1,
                (byte) (KUAI >> 8),
                (byte) KUAI,
                (byte) (kuang_sd >> 8),
                (byte) kuang_sd
                }, 0, 19);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            int num1 = 10;
            returnCode = false;
            //Sleep for 10ms 10 times
            while (0 < num1--)
            {
                Thread.Sleep(10);
                chuli_shijian();

                if (returnCode)
                    return true;
            }
            return false;
        }

        public void writeSettings(
          byte ruo_,
          int hang_yan_shi_,
          int TIM_chong_zhuang_zhi_,
          byte BU_,
          byte x_buchang_,
          byte y_buchang_,
          int SS_,
          int MM1_,
          int KUAI_,
          int kuang_sd_,
          string xh)
        {
            this.ruo = ruo_;
            this.hang_yan_shi = hang_yan_shi_;
            this.TIM_chong_zhuang_zhi = TIM_chong_zhuang_zhi_;
            this.BU = BU_;
            this.x_buchang = x_buchang_;
            this.y_buchang = y_buchang_;
            this.SS = SS_;
            this.MM1 = MM1_;
            this.KUAI = KUAI_;
            this.kuang_sd = kuang_sd_;
            this.modelNumber = xh;
            this.settings();
            this.xinghao();
            this.pifu();
            this.ini.IniWriteValue("set", "ruo", this.ruo.ToString());
            this.ini.IniWriteValue("set", "hang_yan_shi", this.hang_yan_shi.ToString());
            this.ini.IniWriteValue("set", "TIM_chong_zhuang_zhi", this.TIM_chong_zhuang_zhi.ToString());
            this.ini.IniWriteValue("set", "BU", this.BU.ToString());
            this.ini.IniWriteValue("set", "x_buchang", this.x_buchang.ToString());
            this.ini.IniWriteValue("set", "y_buchang", this.y_buchang.ToString());
            this.ini.IniWriteValue("set", "SS", this.SS.ToString());
            this.ini.IniWriteValue("set", "MM1", this.MM1.ToString());
            this.ini.IniWriteValue("set", "KUAI", this.KUAI.ToString());
            this.ini.IniWriteValue("set", "kuang_sd", this.kuang_sd.ToString());
            this.ini.IniWriteValue("selectedLanguge", "selectedLanguge", this.selectedLanguge);
            this.ini.IniWriteValue("modelNumber", "modelNumber", this.modelNumber);
        }

        private void xinghao()
        {
            int num = this.modelNumber.LastIndexOf(",");
            switch (this.modelNumber.Substring(num + 1, this.modelNumber.Length - num - 1))
            {
                case "22":
                    this.xian_k = 3100;
                    this.xian_g = 3500;
                    this.fen_bian_lv = 0.05;
                    this.fen_bian_lv_in = 0.001968505;
                    this.Height = 662;
                    this.change_half.Height = 564;
                    this.but_tuoji.Visible = false;
                    break;
                case "21":
                    this.xian_k = 3100;
                    this.xian_g = 3500;
                    this.fen_bian_lv = 0.05;
                    this.fen_bian_lv_in = 0.001968505;
                    this.Height = 662;
                    this.change_half.Height = 564;
                    this.but_tuoji.Visible = false;
                    break;
                case "4":
                    this.xian_k = 1600;
                    this.xian_g = 1520;
                    this.fen_bian_lv = 0.05;
                    this.fen_bian_lv_in = 0.001968505;
                    this.Height = 598;
                    this.change_half.Height = 500;
                    this.but_tuoji.Visible = true;
                    break;
                case "31":
                    this.xian_k = 1600;
                    this.xian_g = 1520;
                    this.fen_bian_lv = 0.05;
                    this.fen_bian_lv_in = 0.001968505;
                    this.Height = 598;
                    this.change_half.Height = 500;
                    this.but_tuoji.Visible = true;
                    break;
            }
            ini.IniWriteValue("modelNumber", "modelNumber", modelNumber);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            change_half.MouseWheel += new MouseEventHandler(hua_ban_MouseWheel);
            hua_ban.MouseWheel += new MouseEventHandler(hua_ban_MouseWheel);
            FontFamily[] families = new InstalledFontCollection().Families;

            for (int length = families.Length; length > 0; --length)
                listBox1.Items.Add(families[length - 1].Name);

            listBox1.SelectedIndex = 0;
            pictureProcessingDropDownMenu.SelectedIndex = 0;
            txtBoxText.Visible = false;

            if (ini.ExistINIFile())
            {
                ruo = Convert.ToByte(this.ini.IniReadValue("set", "ruo"));
                hang_yan_shi = Convert.ToInt32(this.ini.IniReadValue("set", "hang_yan_shi"));
                TIM_chong_zhuang_zhi = Convert.ToInt32(this.ini.IniReadValue("set", "TIM_chong_zhuang_zhi"));
                BU = Convert.ToByte(this.ini.IniReadValue("set", "BU"));
                x_buchang = Convert.ToByte(this.ini.IniReadValue("set", "x_buchang"));
                y_buchang = Convert.ToByte(this.ini.IniReadValue("set", "y_buchang"));
                SS = Convert.ToInt32(this.ini.IniReadValue("set", "SS"));
                MM1 = Convert.ToInt32(this.ini.IniReadValue("set", "MM1"));
                KUAI = Convert.ToInt32(this.ini.IniReadValue("set", "KUAI"));
                kuang_sd = Convert.ToInt32(this.ini.IniReadValue("set", "kuang_sd"));
                selectedLanguge = this.ini.IniReadValue("selectedLanguge", "selectedLanguge");
                modelNumber = this.ini.IniReadValue("modelNumber", "modelNumber");
                UpdateNewLanguage();
                xinghao();
                pifu();
            }
            else
            {
                this.ini.IniWriteValue("set", "ruo", this.ruo.ToString());
                this.ini.IniWriteValue("set", "hang_yan_shi", this.hang_yan_shi.ToString());
                this.ini.IniWriteValue("set", "TIM_chong_zhuang_zhi", this.TIM_chong_zhuang_zhi.ToString());
                this.ini.IniWriteValue("set", "BU", this.BU.ToString());
                this.ini.IniWriteValue("set", "x_buchang", this.x_buchang.ToString());
                this.ini.IniWriteValue("set", "y_buchang", this.y_buchang.ToString());
                this.ini.IniWriteValue("set", "SS", this.SS.ToString());
                this.ini.IniWriteValue("set", "MM1", this.MM1.ToString());
                this.ini.IniWriteValue("set", "KUAI", this.KUAI.ToString());
                this.ini.IniWriteValue("set", "kuang_sd", this.kuang_sd.ToString());
                this.ini.IniWriteValue("selectedLanguge", "selectedLanguge", this.selectedLanguge);
                this.ini.IniWriteValue("modelNumber", "modelNumber", this.modelNumber);
            }
        }

        private void UpdateNewLanguage()
        {
            if (selectedLanguge == "ch")
            {
                this.connectDeviceString = "连接设备";
                this.disconnectDeviceString = "断开设备";
                this.okString = "确定";
                this.str4 = "输入文字";
                this.str5 = "保存成功：";
                this.pauseString = "暂停";
                this.continueString = "继续";
                this.startString = "开始";
                this.str9 = "连接设备失败！请检查数据线是否插好？驱动是否安装好？";
                this.stopPreviewString = "请先停止预览位置！";
                this.pictureString = "图片";
                this.str12 = "设置";
                this.str13 = "皮肤";
                this.str14 = "图片处理方式";
                this.str15 = "激光功率";
                this.str16 = "雕刻深度";
                this.str17 = "预览位置";
                this.str18 = "重置坐标";
                this.widthString = "宽度";
                this.heightString = "高度";
                this.openPictureString = "打开图片";
                this.str22 = "请先连接设备";
                this.str23 = "批量转换到BMP";
                this.lockAspectString = "锁定宽高比例";
                this.stopString = "停止";
                if (this.engraverConnected)
                    this.btn_disconnectConnectDevice.Text = "断开设备";
                else
                    this.btn_disconnectConnectDevice.Text = "连接设备";
                this.str5 = "保存成功：";
                if (this.isRunning && this.pause)
                    this.btn_start.Text = "继续";
                else if (this.isRunning && !this.pause)
                    this.btn_start.Text = "暂停";
                else if (!this.isRunning)
                    this.btn_start.Text = "开始";
                this.str9 = "连接设备失败！请检查数据线是否插好？驱动是否安装好？";
                this.stopPreviewString = "请先停止预览位置！";
                this.bmpFileDialog.Filter = "图片|*.BMP;*.jpg;*.png|矢量图|*.nc;*.DXF";
                this.menu.Items[3].Text = "设置";
                this.menu.Items[4].Text = "皮肤";
                this.menu.Items[5].Text = str23;
                this.skinLabel1.Text = "图片处理方式:";
                this.skinLabel4.Text = "激光功率:";
                this.skinLabel5.Text = "雕刻深度:";
                this.btnPreview.Text = "预览位置";
                this.btnResetCoordinates.Text = "重置坐标";
                this.btnStop.Text = stopString;
                this.widthLabel.Text = "宽度";
                this.heightLabel.Text = "高度";
                this.btnOpenPicture.Text = "打开图片";
                int selectedIndex = pictureProcessingDropDownMenu.SelectedIndex;
                this.pictureProcessingDropDownMenu.Items.Clear();
                this.pictureProcessingDropDownMenu.Items.Add("黑白");
                this.pictureProcessingDropDownMenu.Items.Add("离散");
                this.pictureProcessingDropDownMenu.Items.Add("轮廓");
                this.pictureProcessingDropDownMenu.Items.Add("素描");
                this.pictureProcessingDropDownMenu.SelectedIndex = selectedIndex;
                this.label16.Text = "字体选择";
                this.radioButton5.Text = "常规";
                this.radioButton2.Text = "粗体";
                this.radioButton3.Text = "斜体";
                this.radioButton4.Text = "粗体/斜体";
                this.Text = "激光雕刻机 " + modelVersion;
                this.lockAspectRatioChkBox.Text = lockAspectString;
            }
            else if (selectedLanguge == "en")
            {
                connectDeviceString = "Attach device";
                disconnectDeviceString = "Disconnect device";
                okString = "Enter key";
                str4 = "Input text";
                str5 = "Save successfully：";
                pauseString = "Pause";
                continueString = "Continue";
                startString = "Start";
                str9 = "Failed to connect device,please check if USB is attatched and driver is properly installed？";
                stopPreviewString = "Please preview the location first！";
                pictureString = "pictures";
                str12 = "Set";
                str13 = "Skin";
                str14 = "Picture Processing:";
                str15 = "Laser power:";
                str16 = "Carving depth:";
                str17 = "Preview Position:";
                str18 = "Reset coordinates:";
                widthString = "Width:";
                heightString = "Height:";
                openPictureString = "Open the picture";
                str22 = "Please connect device first!";
                skinLabel1.Text = "Picture Processing:";
                skinLabel4.Text = "Laser power:";
                skinLabel5.Text = "Carving depth:";
                btnPreview.Text = "Preview Position";
                btnResetCoordinates.Text = "Reset coordinates";
                widthLabel.Text = "Width";
                heightLabel.Text = "Height";
                str23 = "Batch conversion to BMP";
                lockAspectString = "Lock the aspect ratio";
                stopString = "Stop";


                if (engraverConnected)
                    btn_disconnectConnectDevice.Text = "Disconnect device";
                else
                    btn_disconnectConnectDevice.Text = "Attach device";

                str5 = "Save successfully：";

                if (isRunning && pause)
                    btn_start.Text = "Continue";
                else if (isRunning && !pause)
                    btn_start.Text = "Pause";
                else if (!isRunning)
                    btn_start.Text = "Start";

                str9 = "Failed to connect device,please check if USB is attatched and driver is properly installed？";
                stopPreviewString = "Please preview the location first！";
                bmpFileDialog.Filter = "Pictures|*.BMP;*.jpg;*.png|Vector Graph|*.nc;*.DXF";
                menu.Items[3].Text = "Set";
                menu.Items[4].Text = "Skin";
                menu.Items[5].Text = str23;
                btnOpenPicture.Text = "Open the picture";
                btnStop.Text = stopString;
                int selectedIndex = pictureProcessingDropDownMenu.SelectedIndex;
                pictureProcessingDropDownMenu.Items.Clear();
                pictureProcessingDropDownMenu.Items.Add("Black and white");
                pictureProcessingDropDownMenu.Items.Add("Discrete engraving");
                pictureProcessingDropDownMenu.Items.Add("Outline");
                pictureProcessingDropDownMenu.Items.Add("Sketch");
                pictureProcessingDropDownMenu.SelectedIndex = selectedIndex;
                label16.Text = "Font selection";
                radioButton5.Text = "Routine";
                radioButton2.Text = "Bold";
                radioButton3.Text = "Italics";
                radioButton4.Text = "Bold/italic";
                Text = "Laser engraving machine " + modelVersion;
                lockAspectRatioChkBox.Text = lockAspectString;
            }
            else
            {
                if (!(this.selectedLanguge == "jp"))
                    return;
                this.connectDeviceString = "設備と接続";
                this.disconnectDeviceString = "設備と切断";
                this.okString = "確認";
                this.str4 = "テキスト挿入";
                this.str5 = "保存に成功する：";
                this.pauseString = "一時停止";
                this.continueString = "再開";
                this.startString = "スタート";
                this.str9 = "彫刻機と接続できません。彫刻機がUSBケーブルで接続されているか確認してください。彫刻機が接続されている場合は、接続ボタンを押してください。";
                this.stopPreviewString = "先にプレビューをやめてください！";
                this.pictureString = "画像";
                this.str12 = "設定";
                this.str13 = "皮膚";
                this.str14 = "画像処理方法:";
                this.str15 = "レーザーパワー:";
                this.str16 = "彫刻の深さ";
                this.str17 = "プレビューの位置:";
                this.str18 = "座標をリセットする:";
                this.widthString = "幅:";
                this.heightString = "高さ:";
                this.openPictureString = "画像を開く";
                this.str22 = "彫刻機が接続されている場合は、接続ボタンを押してください。";
                this.skinLabel1.Text = "画像処理方法:";
                this.skinLabel4.Text = "レーザーパワー:";
                this.skinLabel5.Text = "彫刻の深さ:";
                this.btnPreview.Text = "プレビューの位置:";
                this.btnResetCoordinates.Text = "座標をリセットする";
                this.widthLabel.Text = "幅:";
                this.heightLabel.Text = "高さ:";
                this.str23 = "BMPにロット変換する";
                this.lockAspectString = "高さを測る";
                this.stopString = "停止";
                if (this.engraverConnected)
                    this.btn_disconnectConnectDevice.Text = "設備と切断";
                else
                    this.btn_disconnectConnectDevice.Text = "設備と接続";
                this.str5 = "保存に成功する：";
                if (this.isRunning && this.pause)
                    this.btn_start.Text = "再開";
                else if (this.isRunning && !this.pause)
                    this.btn_start.Text = "一時停止";
                else if (!this.isRunning)
                    this.btn_start.Text = "スタート";
                this.str9 = "彫刻機と接続できません。彫刻機がUSBケーブルで接続されているか確認してください。彫刻機が接続されている場合は、接続ボタンを押してください。";
                this.stopPreviewString = "先にプレビューをやめてください！";
                this.bmpFileDialog.Filter = "画像|*.BMP;*.jpg;*.png|ベクトル図|*.nc;*.DXF";
                this.menu.Items[3].Text = "設定";
                this.menu.Items[4].Text = "皮膚";
                this.menu.Items[5].Text = this.str23;
                this.btnOpenPicture.Text = "画像を開く";
                this.btnStop.Text = this.stopString;
                int selectedIndex = this.pictureProcessingDropDownMenu.SelectedIndex;
                this.pictureProcessingDropDownMenu.Items.Clear();
                this.pictureProcessingDropDownMenu.Items.Add((object)"モノクロ");
                this.pictureProcessingDropDownMenu.Items.Add((object)"離散");
                this.pictureProcessingDropDownMenu.Items.Add((object)"輪郭");
                this.pictureProcessingDropDownMenu.Items.Add((object)"スケッチ");
                this.pictureProcessingDropDownMenu.SelectedIndex = selectedIndex;
                this.label16.Text = "フォントの選択";
                this.radioButton5.Text = "通常";
                this.radioButton2.Text = "粗体";
                this.radioButton3.Text = "斜体";
                this.radioButton4.Text = "粗体/斜体";
                this.Text = "レーザー彫刻機 " + this.modelVersion;
                this.lockAspectRatioChkBox.Text = this.lockAspectString;
            }
        }

        private void hua_ban_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!openText && !openImage || isRunning || tj_zt || pictureProcessingDropDownMenu.SelectedIndex == 2)
                return;
            if (e.Delta > 0)
            {
                if ((double)this.hua_ban.Width / (double)this.hua_ban.Height > (double)this.xian_k / (double)this.xian_g)
                {
                    if (this.hua_ban.Width + 10 > this.change_half.Width)
                    {
                        this.hua_ban.Width = this.change_half.Width;
                        this.hua_ban.Height = (int)((double)this.hua_ban.Width / this.bi);
                    }
                    else
                    {
                        this.hua_ban.Width += 10;
                        this.hua_ban.Height = (int)((double)this.hua_ban.Width / this.bi);
                    }
                }
                else if (this.hua_ban.Height + 10 > this.change_half.Height - 25)
                {
                    this.hua_ban.Height = this.change_half.Height - 25;
                    this.hua_ban.Width = (int)((double)this.hua_ban.Height * this.bi);
                }
                else
                {
                    this.hua_ban.Height += 10;
                    this.hua_ban.Width = (int)((double)this.hua_ban.Height * this.bi);
                }
            }
            else if (this.hua_ban.Width > 20 && this.hua_ban.Height > 20)
            {
                this.hua_ban.Width -= 10;
                this.hua_ban.Height = (int)((double)this.hua_ban.Width / this.bi);
            }
            this.ding_cl.Enabled = false;
            this.ding_cl.Enabled = true;
        }

        private System.Drawing.Point[] jiaru(System.Drawing.Point[] sz, System.Drawing.Point cy)
        {
            System.Drawing.Point[] pointArray = new System.Drawing.Point[sz.Length + 1];
            for (int index = 0; index < sz.Length; ++index)
                pointArray[index] = sz[index];
            pointArray[sz.Length] = cy;
            return pointArray;
        }

        private System.Drawing.Point[] huayuan(
          double yx,
          double yy,
          double q_jiao,
          double z_jiao,
          double radius,
          bool shun)
        {
            System.Drawing.Point[] sz1 = new System.Drawing.Point[0];
            System.Drawing.Point[] pointArray;
            if (shun)
            {
                if (z_jiao > q_jiao)
                {
                    System.Drawing.Point cy = new System.Drawing.Point(0, 0);
                    for (int index = (int)q_jiao; (double)index < z_jiao - (double)this.bu; index += this.bu)
                    {
                        cy.X = (int)(Math.Cos((double)index * (Math.PI / 180.0)) * radius + yx);
                        cy.Y = (int)(Math.Sin((double)index * (Math.PI / 180.0)) * radius + yy);
                        sz1 = this.jiaru(sz1, cy);
                    }
                    cy.X = (int)(Math.Cos(z_jiao * (Math.PI / 180.0)) * radius + yx);
                    cy.Y = (int)(Math.Sin(z_jiao * (Math.PI / 180.0)) * radius + yy);
                    pointArray = this.jiaru(sz1, cy);
                }
                else
                {
                    double num = z_jiao;
                    System.Drawing.Point cy = new System.Drawing.Point(0, 0);
                    for (int index = (int)q_jiao; index < 352; index += this.bu)
                    {
                        cy.X = (int)(Math.Cos((double)index * (Math.PI / 180.0)) * radius + yx);
                        cy.Y = (int)(Math.Sin((double)index * (Math.PI / 180.0)) * radius + yy);
                        sz1 = this.jiaru(sz1, cy);
                    }
                    cy.X = (int)(Math.Cos(359.0 * Math.PI / 180.0) * radius + yx);
                    cy.Y = (int)(Math.Sin(359.0 * Math.PI / 180.0) * radius + yy);
                    System.Drawing.Point[] sz2 = this.jiaru(sz1, cy);
                    for (int index = 0; (double)index < num - (double)this.bu; index += this.bu)
                    {
                        cy.X = (int)(Math.Cos((double)index * (Math.PI / 180.0)) * radius + yx);
                        cy.Y = (int)(Math.Sin((double)index * (Math.PI / 180.0)) * radius + yy);
                        sz2 = this.jiaru(sz2, cy);
                    }
                    cy.X = (int)(Math.Cos(num * (Math.PI / 180.0)) * radius + yx);
                    cy.Y = (int)(Math.Sin(num * (Math.PI / 180.0)) * radius + yy);
                    pointArray = this.jiaru(sz2, cy);
                }
            }
            else if (z_jiao < q_jiao)
            {
                System.Drawing.Point cy = new System.Drawing.Point(0, 0);
                for (int index = (int)q_jiao; (double)index > z_jiao + (double)this.bu; index -= this.bu)
                {
                    cy.X = (int)(Math.Cos((double)index * (Math.PI / 180.0)) * radius + yx);
                    cy.Y = (int)(Math.Sin((double)index * (Math.PI / 180.0)) * radius + yy);
                    sz1 = this.jiaru(sz1, cy);
                }
                cy.X = (int)(Math.Cos(z_jiao * (Math.PI / 180.0)) * radius + yx);
                cy.Y = (int)(Math.Sin(z_jiao * (Math.PI / 180.0)) * radius + yy);
                pointArray = this.jiaru(sz1, cy);
            }
            else
            {
                double num = z_jiao;
                System.Drawing.Point cy = new System.Drawing.Point(0, 0);
                for (int index = (int)q_jiao; index > this.bu; index -= this.bu)
                {
                    cy.X = (int)(Math.Cos((double)index * (Math.PI / 180.0)) * radius + yx);
                    cy.Y = (int)(Math.Sin((double)index * (Math.PI / 180.0)) * radius + yy);
                    sz1 = this.jiaru(sz1, cy);
                }
                cy.X = (int)(Math.Cos(0.0) * radius + yx);
                cy.Y = (int)(Math.Sin(0.0) * radius + yy);
                System.Drawing.Point[] sz3 = this.jiaru(sz1, cy);
                for (int index = 360; (double)index > num + (double)this.bu; index -= this.bu)
                {
                    cy.X = (int)(Math.Cos((double)index * (Math.PI / 180.0)) * radius + yx);
                    cy.Y = (int)(Math.Sin((double)index * (Math.PI / 180.0)) * radius + yy);
                    sz3 = this.jiaru(sz3, cy);
                }
                cy.X = (int)(Math.Cos(num * (Math.PI / 180.0)) * radius + yx);
                cy.Y = (int)(Math.Sin(num * (Math.PI / 180.0)) * radius + yy);
                pointArray = this.jiaru(sz3, cy);
            }
            return pointArray;
        }

        private void jie_dxf(string ss, float bili)
        {
            DxfDocument dxfDocument = new DxfDocument();
            try
            {
                dxfDocument = DxfDocument.Load(ss);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
            }
            this.xian.Clear();
            Form1.Xian xian;
            foreach (Circle circle in dxfDocument.Circles)
            {
                System.Drawing.Point[] pointArray = this.huayuan(circle.Center.X / (double)bili, circle.Center.Y / (double)bili, 0.0, 360.0, circle.Radius / (double)bili, true);
                for (int index = 1; index < pointArray.Length; ++index)
                {
                    xian.q = new Form1.Dian(pointArray[index - 1].X, pointArray[index - 1].Y);
                    xian.zh = new Form1.Dian(pointArray[index].X, pointArray[index].Y);
                    this.xian.Add(xian);
                }
            }
            foreach (Arc arc in dxfDocument.Arcs)
            {
                System.Drawing.Point[] pointArray = this.huayuan(arc.Center.X / (double)bili, arc.Center.Y / (double)bili, arc.StartAngle, arc.EndAngle, arc.Radius / (double)bili, true);
                for (int index = 1; index < pointArray.Length; ++index)
                {
                    xian.q = new Form1.Dian(pointArray[index - 1].X, pointArray[index - 1].Y);
                    xian.zh = new Form1.Dian(pointArray[index].X, pointArray[index].Y);
                    this.xian.Add(xian);
                }
            }
            foreach (Line line in dxfDocument.Lines)
            {
                xian.q = new Form1.Dian((int)(line.StartPoint.X / (double)bili), (int)(line.StartPoint.Y / (double)bili));
                xian.zh = new Form1.Dian((int)(line.EndPoint.X / (double)bili), (int)(line.EndPoint.Y / (double)bili));
                this.xian.Add(xian);
            }
            foreach (Spline spline in dxfDocument.Splines)
            {
                List<PointF> plist = new List<PointF>();
                for (int index = 0; index < spline.ControlPoints.Count; ++index)
                    plist.Add(new PointF((float)spline.ControlPoints[index].Location.X, (float)spline.ControlPoints[index].Location.Y));
                BsplineCurve bsplineCurve = new BsplineCurve(BsplineType.Uniform, (int)spline.Degree, plist);
                bsplineCurve.knots_value = new List<double>((IEnumerable<double>)spline.Knots);
                bsplineCurve.CreateCurve();
                for (int index = 1; index < bsplineCurve.CurvePoint.Count; ++index)
                {
                    xian.q = new Form1.Dian((int)((double)bsplineCurve.CurvePoint[index - 1].X / (double)bili), (int)((double)bsplineCurve.CurvePoint[index - 1].Y / (double)bili));
                    xian.zh = new Form1.Dian((int)((double)bsplineCurve.CurvePoint[index].X / (double)bili), (int)((double)bsplineCurve.CurvePoint[index].Y / (double)bili));
                    this.xian.Add(xian);
                }
            }
            foreach (LwPolyline lwPolyline in dxfDocument.LwPolylines)
            {
                LwPolylineVertex[] array = lwPolyline.Vertexes.ToArray();
                for (int index = 1; index < array.Length; ++index)
                {
                    xian.q = new Form1.Dian((int)(array[index - 1].Location.X / (double)bili), (int)(array[index - 1].Location.Y / (double)bili));
                    xian.zh = new Form1.Dian((int)(array[index].Location.X / (double)bili), (int)(array[index].Location.Y / (double)bili));
                    this.xian.Add(xian);
                }
            }
        }

        private Form1.Dian qu_ling_dian()
        {
            Form1.Dian dian1 = new Form1.Dian();
            Form1.Dian dian2 = new Form1.Dian();
            bool flag = false;
            foreach (Form1.Xian xian in this.xian)
            {
                if (!flag)
                {
                    dian1.x = xian.q.x;
                    dian1.y = xian.q.y;
                    dian2.x = xian.q.x;
                    dian2.y = xian.q.y;
                    flag = true;
                }
                if (xian.q.x < dian1.x)
                    dian1.x = xian.q.x;
                if (xian.q.y < dian1.y)
                    dian1.y = xian.q.y;
                if (xian.zh.x < dian1.x)
                    dian1.x = xian.zh.x;
                if (xian.zh.y < dian1.y)
                    dian1.y = xian.zh.y;
                if (xian.q.x > dian2.x)
                    dian2.x = xian.q.x;
                if (xian.q.y > dian2.y)
                    dian2.y = xian.q.y;
                if (xian.zh.x > dian2.x)
                    dian2.x = xian.zh.x;
                if (xian.zh.y > dian2.y)
                    dian2.y = xian.zh.y;
            }
            this.k_kuan = dian2.x - dian1.x;
            this.k_gao = dian2.y - dian1.y;
            return dian1;
        }

        private List<PointF[]> zhuan_huan(System.Drawing.Point[] pp)
        {
            List<PointF[]> pointFArrayList = new List<PointF[]>();
            List<PointF> pointFList = new List<PointF>();
            bool flag1 = false;
            bool flag2 = false;
            for (int index = 0; index < pp.Length; ++index)
            {
                if (pp[index].X == 50001)
                {
                    flag1 = true;
                    flag2 = true;
                    pointFList.Add(new PointF((float)pp[index - 1].X, (float)pp[index - 1].Y));
                }
                else if (pp[index].X == 50000)
                {
                    flag1 = false;
                    pointFArrayList.Add(pointFList.ToArray());
                    pointFList.Clear();
                }
                else if (flag2 && flag1)
                    pointFList.Add(new PointF((float)pp[index].X, (float)pp[index].Y));
            }
            return pointFArrayList;
        }

        private Form1.Dian qu_g_kg()
        {
            float xx = 0.0f;
            float num1 = 0.0f;
            float yy = 0.0f;
            float num2 = 0.0f;
            bool flag = false;
            foreach (PointF[] pointFArray in this.dian_shu_zu)
            {
                for (int index = 0; index < pointFArray.Length; ++index)
                {
                    if (!flag)
                    {
                        xx = pointFArray[index].X;
                        yy = pointFArray[index].Y;
                        num2 = pointFArray[index].X;
                        num1 = pointFArray[index].Y;
                        flag = true;
                    }
                    else
                    {
                        if ((double)xx > (double)pointFArray[index].X)
                            xx = pointFArray[index].X;
                        if ((double)yy > (double)pointFArray[index].Y)
                            yy = pointFArray[index].Y;
                        if ((double)num2 < (double)pointFArray[index].X)
                            num2 = pointFArray[index].X;
                        if ((double)num1 < (double)pointFArray[index].Y)
                            num1 = pointFArray[index].Y;
                    }
                }
            }
            this.k_kuan = (int)((double)num2 - (double)xx);
            this.k_gao = (int)((double)num1 - (double)yy);
            return new Form1.Dian((int)xx, (int)yy);
        }

        private void da_kai(string ss)
        {
            switch (Path.GetExtension(ss).ToUpper())
            {
                case ".DXF":
                    this.jie_dxf(ss, 0.05f);
                    Form1.Dian dian1 = this.qu_ling_dian();
                    Bitmap original1 = new Bitmap(this.k_kuan + 16, this.k_gao + 16);
                    Graphics graphics1 = Graphics.FromImage((System.Drawing.Image)original1);
                    foreach (Form1.Xian xian in this.xian)
                        graphics1.DrawLine(Pens.Blue, new PointF((float)(xian.q.x - dian1.x + 8), (float)(xian.q.y - dian1.y + 8)), new PointF((float)(xian.zh.x - dian1.x + 8), (float)(xian.zh.y - dian1.y + 8)));
                    graphics1.Dispose();
                    this.tu_yuan = new Bitmap((System.Drawing.Image)original1);
                    this.tu_yuan = this.hui_du(this.tu_yuan);
                    this.pictureScaling = new Bitmap((System.Drawing.Image)this.tu_yuan);
                    this.bi = (double)this.pictureScaling.Width / (double)this.pictureScaling.Height;
                    this.hua_ban.Width = (int)((double)this.pictureScaling.Width * ((double)this.change_half.Width / (double)this.xian_k));
                    this.hua_ban.Height = (int)((double)this.pictureScaling.Height * ((double)this.change_half.Width / (double)this.xian_k));
                    this.chu_li();
                    this.pictureProcessingDropDownMenu.SelectedIndex = 2;
                    break;
                case ".NC":
                    this.dian_shu_zu = this.zhuan_huan(g_dai_ma.jie_xi(File.ReadAllText(ss)));
                    Form1.Dian dian2 = this.qu_g_kg();
                    Bitmap original2 = new Bitmap(this.k_kuan + 16, this.k_gao + 16);
                    Graphics graphics2 = Graphics.FromImage((System.Drawing.Image)original2);
                    foreach (PointF[] pointFArray in this.dian_shu_zu)
                    {
                        for (int index = 1; index < pointFArray.Length; ++index)
                            graphics2.DrawLine(Pens.Blue, new System.Drawing.Point((int)((double)pointFArray[index - 1].X - (double)dian2.x + 8.0), (int)pointFArray[index - 1].Y - dian2.y + 8), new System.Drawing.Point((int)pointFArray[index].X - dian2.x + 8, (int)pointFArray[index].Y - dian2.y + 8));
                    }
                    graphics2.Dispose();
                    this.tu_yuan = new Bitmap((System.Drawing.Image)original2);
                    this.tu_yuan = this.hui_du(this.tu_yuan);
                    this.pictureScaling = new Bitmap((System.Drawing.Image)this.tu_yuan);
                    this.bi = (double)this.pictureScaling.Width / (double)this.pictureScaling.Height;
                    this.hua_ban.Width = (int)((double)this.pictureScaling.Width * ((double)this.change_half.Width / (double)this.xian_k));
                    this.hua_ban.Height = (int)((double)this.pictureScaling.Height * ((double)this.change_half.Width / (double)this.xian_k));
                    this.chu_li();
                    this.pictureProcessingDropDownMenu.SelectedIndex = 2;
                    break;
                default:
                    this.tu_yuan = new Bitmap(ss);
                    if (this.tu_yuan.Width > this.xian_k || this.tu_yuan.Height > this.xian_g)
                    {
                        int newH;
                        int newW;
                        if (this.tu_yuan.Width - this.xian_k > this.tu_yuan.Height - this.xian_g)
                        {
                            newH = (int)((double)this.tu_yuan.Height * ((double)this.xian_k / (double)this.tu_yuan.Width));
                            newW = this.xian_k;
                        }
                        else
                        {
                            newW = (int)((double)this.tu_yuan.Width * ((double)this.xian_g / (double)this.tu_yuan.Height));
                            newH = this.xian_g;
                        }
                        this.tu_yuan = this.resizeBitmap(this.tu_yuan, newW, newH);
                    }
                    this.tu_yuan = this.hui_du(this.tu_yuan);
                    this.pictureScaling = new Bitmap((System.Drawing.Image)this.tu_yuan);
                    this.bi = (double)this.pictureScaling.Width / (double)this.pictureScaling.Height;
                    this.hua_ban.Width = (int)((double)this.pictureScaling.Width * ((double)this.change_half.Width / (double)this.xian_k));
                    this.hua_ban.Height = (int)((double)this.pictureScaling.Height * ((double)this.change_half.Width / (double)this.xian_k));
                    this.chu_li();
                    this.pictureProcessingDropDownMenu.SelectedIndex = 0;
                    break;
            }
            this.qi_dian = this.hua_ban.Location;
            this.hua_ban.Location = new System.Drawing.Point((this.change_half.Width - this.hua_ban.Width) / 2, (this.change_half.Height - this.hua_ban.Height) / 2);
            this.yidong((int)((double)(this.hua_ban.Location.X - this.qi_dian.X) * ((double)this.xian_k / (double)this.change_half.Width)), (int)((double)(this.hua_ban.Location.Y - this.qi_dian.Y) * ((double)this.xian_k / (double)this.change_half.Width)));
            this.openImage = true;
        }

        private void but_dakai_Click(object sender, EventArgs e)
        {
            if (isRunning || bmpFileDialog.ShowDialog() != DialogResult.OK)
                return;

            da_kai(bmpFileDialog.FileName);
        }

        private void but_lianjie_Click(object sender, EventArgs e)
        {
            if (engraverConnected)
            {
                if (showingPreview)
                    guan_kuang();

                if (isRunning)
                    ting_zhi();

                engraverConnected = false;
                btn_disconnectConnectDevice.Text = connectDeviceString;
                com.Close();
                LED.Visible = false;
            }
            else if (this.connection())
            {
                this.engraverConnected = true;
                this.btn_disconnectConnectDevice.Text = this.disconnectDeviceString;
                this.LED.Visible = true;
                this.settings();
                this.qu_xinghao = true;
                this.du_ban_ben();
                this.dao_yuandian();
                this.hua_ban.Location = new System.Drawing.Point(0, 0);
                this.xinghao();
            }
            else
            {
                int num = (int)MessageBox.Show(this.str9);
            }
        }

        public string StrReverse(string str)
        {
            char[] charArray = str.ToCharArray();
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < charArray.Length; ++index)
                stringBuilder.Append(charArray[charArray.Length - 1 - index]);
            return stringBuilder.ToString();
        }

        private void huan_ban_Click(object sender, EventArgs e) => this.change_half.Focus();

        private void hua_ban_Click(object sender, EventArgs e) => this.hua_ban.Focus();

        private void ding_cl_Tick(object sender, EventArgs e)
        {
            if (jinru)
                return;
            new Thread(new ThreadStart(cl)).Start();
        }

        private void text_wenzi_TextChanged(object sender, EventArgs e) => this.resizeNewTextBox();

        private void but_ziti_Click(object sender, EventArgs e)
        {
            if (this.isRunning || this.txtBoxText.Visible)
                return;
            this.txtBoxText.Location = new System.Drawing.Point(this.hua_ban.Location.X, this.hua_ban.Location.Y);
            this.txtBoxText.Visible = true;
            this.txtBoxText.Focus();
        }

        private void label16_MouseDown(object sender, MouseEventArgs e)
        {
            this.z_anxia = true;
            this.z_x = e.X;
            this.z_y = e.Y;
        }

        private void label16_MouseMove(object sender, MouseEventArgs e)
        {
            if (!z_anxia)
                return;
            panel6.Location = new System.Drawing.Point(this.panel6.Location.X + (e.X - this.z_x), this.panel6.Location.Y + (e.Y - this.z_y));
        }

        private void label16_MouseUp(object sender, MouseEventArgs e) => this.z_anxia = false;

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            this.label17.Text = this.trackBar5.Value.ToString();
            this.zi_ti();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) => this.zi_ti();

        private void radioButton5_CheckedChanged(object sender, EventArgs e) => this.zi_ti();

        private void radioButton2_CheckedChanged(object sender, EventArgs e) => this.zi_ti();

        private void radioButton3_CheckedChanged(object sender, EventArgs e) => this.zi_ti();

        private void radioButton4_CheckedChanged(object sender, EventArgs e) => this.zi_ti();

        private void skinLabel6_Click(object sender, EventArgs e) => this.panel6.Visible = !this.panel6.Visible;

        private void hua_ban_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.isRunning || !this.engraverConnected)
                return;
            this.an_xia = true;
            this.yi_dian = new System.Drawing.Point(e.X, e.Y);
            this.qi_dian = this.hua_ban.Location;
        }

        private void hua_ban_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.an_xia)
                return;
            int x = this.hua_ban.Location.X + (e.X - this.yi_dian.X);
            int y = this.hua_ban.Location.Y + (e.Y - this.yi_dian.Y);
            if (x < 0)
                x = 0;
            if (x > this.change_half.Width - this.hua_ban.Width)
                x = this.change_half.Width - this.hua_ban.Width;
            if (y < 0)
                y = 0;
            if (y > this.change_half.Height - this.hua_ban.Height)
                y = this.change_half.Height - this.hua_ban.Height;
            this.hua_ban.Location = new System.Drawing.Point(x, y);
        }

        public bool yidong(int xx, int yy)
        {
            if (!this.com.IsOpen)
                return false;
            try
            {
                this.com.Write(new byte[7]
                {
          (byte) 1,
          (byte) 0,
          (byte) 7,
          (byte) (xx >> 8),
          (byte) xx,
          (byte) (yy >> 8),
          (byte) yy
                }, 0, 7);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            int num1 = 10;
            this.returnCode = false;
            while (0 < num1--)
            {
                Thread.Sleep(10);
                this.chuli_shijian();
                if (this.returnCode)
                    return true;
            }
            return false;
        }

        private void hua_ban_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.an_xia)
                return;
            this.an_xia = false;
            this.yidong((int)((double)(this.hua_ban.Location.X - this.qi_dian.X) * ((double)this.xian_k / (double)this.change_half.Width)), (int)((double)(this.hua_ban.Location.Y - this.qi_dian.Y) * ((double)this.xian_k / (double)this.change_half.Width)));
        }


        //text_wenzi Is renamed to txtBoxText in designer. Edit event names of these below
        private void text_wenzi_MouseDown(object sender, MouseEventArgs e)
        {
            an_xia_wz = true;
            yi_dian = new System.Drawing.Point(e.X, e.Y);
        }

        private void text_wenzi_MouseMove(object sender, MouseEventArgs e)
        {
            if (!an_xia_wz)
                return;

            int x = txtBoxText.Location.X + (e.X - yi_dian.X);
            int y = txtBoxText.Location.Y + (e.Y - yi_dian.Y);

            if (x < hua_ban.Location.X)
                x = hua_ban.Location.X;

            if (x > hua_ban.Location.X + hua_ban.Width - txtBoxText.Width)
                x = hua_ban.Location.X + hua_ban.Width - txtBoxText.Width;

            if (y < hua_ban.Location.Y)
                y = hua_ban.Location.Y;

            if (y > hua_ban.Location.Y + hua_ban.Height - txtBoxText.Height)
                y = hua_ban.Location.Y + hua_ban.Height - txtBoxText.Height;

            txtBoxText.Location = new System.Drawing.Point(x, y);
        }

        private void text_wenzi_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.an_xia_wz)
                return;
            this.an_xia_wz = false;
        }

        public bool kai_kuang(int k, int g, int t_x, int t_y)
        {
            if (!com.IsOpen)
                return false;
            try
            {
                com.Write(new byte[11]
                {
                    (byte) 32,
                    (byte) 0,
                    (byte) 11,
                    (byte) (k >> 8),
                    (byte) k,
                    (byte) (g >> 8),
                    (byte) g,
                    (byte) (t_x >> 8),
                    (byte) t_x,
                    (byte) (t_y >> 8),
                    (byte) t_y
                }, 0, 11);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            int num1 = 300;
            returnCode = false;

            while (0 < num1--)
            {
                Thread.Sleep(10);
                chuli_shijian();
                if (returnCode)
                    return true;
            }
            return false;
        }

        public bool guan_kuang()
        {
            if (!com.IsOpen)
                return false;
            try
            {
                com.Write(new byte[4]
                {
                    33,
                    0,
                    4,
                    0
                }, 0, 4);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }

            int num1 = 300;
            returnCode = false;

            while (0 < num1--)
            {
                Thread.Sleep(10);
                chuli_shijian();

                if (returnCode)
                    return true;
            }
            return false;
        }

        private void but_yulan_Click(object sender, EventArgs e)
        {
            if (!this.engraverConnected)
            {
                int num = (int)MessageBox.Show(this.str22);
            }
            else
            {
                if (isRunning || tj_zt || !openImage && !openText)
                    return;

                showingPreview = !showingPreview;

                if (showingPreview)
                    kai_kuang(you - zuo, xia - shang, zuo, shang);
                else
                    guan_kuang();

                hua_ban.Refresh();
            }
        }

        private void hua_ban_Paint(object sender, PaintEventArgs e)
        {
            if (this.showingPreview)
            {
                double num = (double)this.change_half.Width / (double)this.xian_k;
                int x = (int)((double)this.zuo * num);
                int y = (int)((double)this.shang * num);
                int width = (int)((double)this.you * num - (double)this.zuo * num);
                int height = (int)((double)this.xia * num - (double)this.shang * num);
                e.Graphics.DrawRectangle(Pens.Red, x, y, width, height);
            }
            if (!this.isRunning)
                return;
            int num1 = (int)((double)(int)((double)this.tu_diaoke.Height * ((double)this.m_jd / 100.0)) * ((double)this.change_half.Width / (double)this.xian_k));
            e.Graphics.DrawLine(Pens.Red, 0, num1, this.hua_ban.Width, num1);
        }

        private void text_kuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (pictureProcessingDropDownMenu.SelectedIndex == 2)
                return;

            if (e.KeyChar == '\r')
            {
                double num1 = (double)(this.you - this.zuo) / (double)(this.xia - this.shang);
                int num2;
                int num3;
                if (!this.lockAspectRatioChkBox.Checked)
                {
                    if (this.millimeters)
                    {
                        num2 = (int)(Convert.ToDouble(this.txtBoxWidth.Text) / this.fen_bian_lv);
                        num3 = (int)(Convert.ToDouble(this.txtBoxHeight.Text) / this.fen_bian_lv);
                    }
                    else
                    {
                        num2 = (int)(Convert.ToDouble(this.txtBoxWidth.Text) / this.fen_bian_lv_in);
                        num3 = (int)(Convert.ToDouble(this.txtBoxHeight.Text) / this.fen_bian_lv_in);
                    }
                }
                else if (this.millimeters)
                {
                    num2 = (int)(Convert.ToDouble(this.txtBoxWidth.Text) / this.fen_bian_lv);
                    num3 = (int)((double)num2 / num1);
                }
                else
                {
                    num2 = (int)(Convert.ToDouble(this.txtBoxWidth.Text) / this.fen_bian_lv_in);
                    num3 = (int)((double)num2 / num1);
                }
                double num4 = (double)this.tu_diaoke.Width / (double)(this.you - this.zuo);
                int num5 = (int)((double)num2 * num4);
                double num6 = (double)this.tu_diaoke.Height / (double)(this.xia - this.shang);
                int num7 = (int)((double)num3 * num6);
                if (num5 > this.xian_k || num7 > this.xian_g)
                {
                    if (num5 > num7)
                    {
                        num5 = this.xian_k;
                        num7 = (int)((double)num5 / this.bi);
                    }
                    else
                    {
                        num7 = this.xian_g;
                        num5 = (int)((double)num5 * this.bi);
                    }
                }
                else if (num5 < 1 || num7 < 1)
                    return;

                hua_ban.Width = (int)((double)num5 * ((double)this.change_half.Width / (double)this.xian_k));
                hua_ban.Height = (int)((double)num7 * ((double)this.change_half.Width / (double)this.xian_k));
                ding_cl_Tick(null, null);
            }
            else
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b' || e.KeyChar == '.' || e.KeyChar == '-')
                    return;
                e.Handled = true;
            }
        }

        private void text_gao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.pictureProcessingDropDownMenu.SelectedIndex == 2)
                return;
            if (e.KeyChar == '\r')
            {
                double num1 = (double)(this.you - this.zuo) / (double)(this.xia - this.shang);
                int num2;
                int num3;
                if (!this.lockAspectRatioChkBox.Checked)
                {
                    if (this.millimeters)
                    {
                        num2 = (int)(Convert.ToDouble(this.txtBoxWidth.Text) / this.fen_bian_lv);
                        num3 = (int)(Convert.ToDouble(this.txtBoxHeight.Text) / this.fen_bian_lv);
                    }
                    else
                    {
                        num2 = (int)(Convert.ToDouble(this.txtBoxWidth.Text) / this.fen_bian_lv_in);
                        num3 = (int)(Convert.ToDouble(this.txtBoxHeight.Text) / this.fen_bian_lv_in);
                    }
                }
                else if (this.millimeters)
                {
                    num3 = (int)(Convert.ToDouble(this.txtBoxHeight.Text) / this.fen_bian_lv);
                    num2 = (int)((double)num3 * num1);
                }
                else
                {
                    num3 = (int)(Convert.ToDouble(this.txtBoxHeight.Text) / this.fen_bian_lv_in);
                    num2 = (int)((double)num3 * num1);
                }
                double num4 = (double)this.tu_diaoke.Width / (double)(this.you - this.zuo);
                int num5 = (int)((double)num2 * num4);
                double num6 = (double)this.tu_diaoke.Height / (double)(this.xia - this.shang);
                int num7 = (int)((double)num3 * num6);
                if (num5 > this.xian_k || num7 > this.xian_g)
                {
                    if (num5 > num7)
                    {
                        num5 = this.xian_k;
                        num7 = (int)((double)num5 / this.bi);
                    }
                    else
                    {
                        num7 = this.xian_g;
                        num5 = (int)((double)num5 * this.bi);
                    }
                }
                else if (num5 < 1 || num7 < 1)
                    return;
                hua_ban.Width = (int)((double)num5 * ((double)this.change_half.Width / (double)this.xian_k));
                hua_ban.Height = (int)((double)num7 * ((double)this.change_half.Width / (double)this.xian_k));
                ding_cl_Tick(null, null);
            }
            else
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b' || e.KeyChar == '.' || e.KeyChar == '-')
                    return;
                e.Handled = true;
            }
        }

        private void btnMmToInch_Click(object sender, EventArgs e)
        {
            if (!openImage && !openText)
                return;

            if (millimeters)
            {
                millimeters = false;
                txtBoxWidth.Text = (Convert.ToDouble(txtBoxWidth.Text) * 0.0393701).ToString();
                txtBoxHeight.Text = (Convert.ToDouble(txtBoxHeight.Text) * 0.0393701).ToString();
                mmInchLabel1.Text = "in";
                mmInchLabel2.Text = "in";
            }
            else
            {
                millimeters = true;
                txtBoxWidth.Text = (Convert.ToDouble(txtBoxWidth.Text) / 0.0393701).ToString();
                txtBoxHeight.Text = (Convert.ToDouble(txtBoxHeight.Text) / 0.0393701).ToString();
                mmInchLabel1.Text = "mm";
                mmInchLabel2.Text = "mm";
            }
        }

        private void but_jingxiang_Click(object sender, EventArgs e)
        {
            if (this.pictureProcessingDropDownMenu.SelectedIndex == 2 || this.isRunning || this.tj_zt || !this.openImage && !this.openText)
                return;
            this.tu_yuan.RotateFlip(RotateFlipType.RotateNoneFlipX);
            this.ding_cl_Tick((object)null, (EventArgs)null);
        }

        private void but_fanzhuan_Click(object sender, EventArgs e)
        {
            if (this.pictureProcessingDropDownMenu.SelectedIndex == 2 || this.isRunning || this.tj_zt || !this.openImage && !this.openText)
                return;
            this.tu_yuan.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.pictureScaling = new Bitmap((System.Drawing.Image)this.tu_yuan);
            this.bi = (double)this.pictureScaling.Width / (double)this.pictureScaling.Height;
            this.hua_ban.Width = (int)((double)this.pictureScaling.Width * ((double)this.change_half.Width / (double)this.xian_k));
            this.hua_ban.Height = (int)((double)this.pictureScaling.Height * ((double)this.change_half.Width / (double)this.xian_k));
            this.ding_cl_Tick((object)null, (EventArgs)null);
        }

        private void but_fanse_Click(object sender, EventArgs e)
        {
            if (this.pictureProcessingDropDownMenu.SelectedIndex == 2 || this.isRunning || this.tj_zt || !this.openImage && !this.openText)
                return;
            this.fan_se = !this.fan_se;
            this.ding_cl_Tick((object)null, (EventArgs)null);
        }

        private void but_shanchu_Click(object sender, EventArgs e)
        {
            if (this.isRunning || this.tj_zt || !this.openImage && !this.openText)
                return;
            this.tu_yuan = new Bitmap(1, 1);
            this.pictureScaling = new Bitmap(1, 1);
            this.tu_diaoke = new Bitmap(1, 1);
            this.openImage = false;
            this.openText = false;
            this.hua_ban.Width = 20;
            this.hua_ban.Height = 20;
            this.hua_ban.BackgroundImage = (System.Drawing.Image)new Bitmap(20, 20);
        }

        private void but_baocun_Click(object sender, EventArgs e)
        {
            if (!this.openImage && !this.openText || this.tu_diaoke == null)
                return;
            DateTime dateTime = new DateTime();
            DateTime now = DateTime.Now;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;
            string str1 = month.ToString() + day.ToString() + hour.ToString() + minute.ToString() + second.ToString();
            string str2 = Directory.GetCurrentDirectory() + "\\";
            try
            {
                this.tu_diaoke.Save(str2 + str1 + ".bmp", ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                return;
            }
            int num = (int)MessageBox.Show(this.str5 + str2 + str1 + ".bmp");
        }

        public bool kai_shi_tuo_ji(int zuo, int ding, int kuan, int gao, int gong_lv, int shen_du)
        {
            if (!this.com.IsOpen)
                return false;
            try
            {
                int num = kuan * gao / 8 / 4069 + 1;
                this.com.Write(new byte[17]
                {
          (byte) 35,
          (byte) 0,
          (byte) 17,
          (byte) (zuo >> 8),
          (byte) zuo,
          (byte) (ding >> 8),
          (byte) ding,
          (byte) (kuan >> 8),
          (byte) kuan,
          (byte) (gao >> 8),
          (byte) gao,
          (byte) (gong_lv >> 8),
          (byte) gong_lv,
          (byte) (shen_du >> 8),
          (byte) shen_du,
          (byte) (num >> 8),
          (byte) num
                }, 0, 17);
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        private byte get_jiayan(byte[] bao)
        {
            int num = 0;
            for (int index = 0; index < bao.Length - 1; ++index)
                num += (int)bao[index];
            if (num > (int)byte.MaxValue)
                num = ~num + 1;
            return (byte)(num & (int)byte.MaxValue);
        }

        private void chuli_shijian() => Application.DoEvents();

        private void tuo_ji()
        {
            this.fs_wc = false;
            this.kai_shi_tuo_ji((int)(byte)((double)((this.hua_ban.Location.X + this.zuo) * this.xian_k) / (double)this.change_half.Width), (int)(byte)((double)((this.hua_ban.Location.Y + this.shang) * this.xian_k) / (double)this.change_half.Width), this.tu_diaoke.Width, this.tu_diaoke.Height, this.tiao_gonglv.Value * 10, this.tiao_shendu.Value);
            this.m_jd = 0;
            int width = this.tu_diaoke.Width;
            int height = this.tu_diaoke.Height;
            Bitmap bitmap = new Bitmap((System.Drawing.Image)this.tu_diaoke);
            while (!this.fs_wc)
            {
                this.jin_du_();
                this.chuli_shijian();
                lock (Form1.locker)
                    this.m_jd += 5;
                Thread.Sleep(500);
                if (this.m_jd > 1200)
                    break;
            }
            byte[] numArray1 = bitmap.Width % 8 <= 0 ? new byte[width / 8 + 4] : new byte[width / 8 + 5];
            byte[] numArray2 = new byte[8]
            {
        (byte) 128,
        (byte) 64,
        (byte) 32,
        (byte) 16,
        (byte) 8,
        (byte) 4,
        (byte) 2,
        (byte) 1
            };
            for (int y = 0; y < height; ++y)
            {
                int num1 = 0;
                for (int index1 = 0; index1 < numArray1.Length - 4; ++index1)
                {
                    byte num2 = 0;
                    for (int index2 = 0; index2 < 8; ++index2)
                    {
                        if (index1 * 8 + index2 < width && bitmap.GetPixel(index1 * 8 + index2, y).R == (byte)0)
                            num2 |= numArray2[index2];
                    }
                    byte num3 = (byte)~num2;
                    numArray1[num1 + 3] = num3;
                    ++num1;
                }
                numArray1[0] = (byte)34;
                numArray1[1] = (byte)(numArray1.Length >> 8);
                numArray1[2] = (byte)numArray1.Length;
                numArray1[numArray1.Length - 1] = this.get_jiayan(numArray1);
            label_18:
                do
                {
                    try
                    {
                        this.returnCode = false;
                        this.com.Write(numArray1, 0, numArray1.Length);
                    }
                    catch (Exception ex)
                    {
                        this.com.Close();
                        Thread.Sleep(500);
                        string portName1 = this.com.PortName;
                        bool flag = false;
                        do
                        {
                            foreach (string portName2 in SerialPort.GetPortNames())
                            {
                                if (portName2 == portName1)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            Thread.Sleep(100);
                            Application.DoEvents();
                        }
                        while (!flag);
                        this.com.Open();
                        continue;
                    }
                    while (!this.returnCode)
                    {
                        if (this.com.IsOpen)
                        {
                            Application.DoEvents();
                            Thread.Sleep(10);
                        }
                        else
                            goto label_18;
                    }
                }
                while (this.returnValue == 8);
                Application.DoEvents();
                lock (Form1.locker)
                    this.m_jd = (int)((double)y / (double)height * 100.0);
                this.jin_du_();
            }
            this.jin_du_guan();
            this.ji_huo();
            this.tj_zt = false;
        }

        public bool ji_huo()
        {
            if (!this.com.IsOpen)
                return false;
            int num1 = 2;
            do
            {
                this.returnCode = false;
                try
                {
                    this.com.Write(new byte[4]
                    {
            (byte) 10,
            (byte) 0,
            (byte) 4,
            (byte) 0
                    }, 0, 4);
                }
                catch (Exception ex)
                {
                    this.com.Close();
                    this.com.Open();
                }
                int num2 = 10;
                while (0 < num2--)
                {
                    Thread.Sleep(10);
                    this.chuli_shijian();
                    if (this.returnCode)
                        return true;
                }
            }
            while (--num1 > 0);
            this.com.Close();
            return false;
        }

        private void but_tuoji_Click(object sender, EventArgs e)
        {
            if (!this.engraverConnected)
            {
                int num = (int)MessageBox.Show(this.str22);
            }
            else
            {
                if (!this.openImage && !this.openText || !this.engraverConnected || this.tj_zt || this.isRunning)
                    return;
                this.tj_zt = true;
                new Thread(new ThreadStart(this.tuo_ji)).Start();
            }
        }

        public bool fu_wei()
        {
            if (!this.com.IsOpen)
                return false;
            try
            {
                this.com.Write(new byte[4]
                {
          (byte) 6,
          (byte) 0,
          (byte) 4,
          (byte) 0
                }, 0, 4);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            int num1 = 10;
            this.returnCode = false;
            while (0 < num1--)
            {
                Thread.Sleep(10);
                this.chuli_shijian();
                if (this.returnCode)
                    return true;
            }
            return false;
        }

        public bool fa_(int m)
        {
            if (!this.com.IsOpen)
                return false;
            try
            {
                this.com.Write(new byte[4]
                {
          (byte) m,
          (byte) 0,
          (byte) 4,
          (byte) 0
                }, 0, 4);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }

        public bool kai_shi(int xx, int yy)
        {
            if (!this.com.IsOpen)
                return false;
            try
            {
                this.com.Write(new byte[7]
                {
          (byte) 20,
          (byte) 0,
          (byte) 7,
          (byte) (xx >> 8),
          (byte) xx,
          (byte) (yy >> 8),
          (byte) yy
                }, 0, 7);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            int num1 = 10;
            this.returnCode = false;
            while (0 < num1--)
            {
                Thread.Sleep(10);
                this.chuli_shijian();
                if (this.returnCode)
                    return true;
            }
            return false;
        }

        public bool zan_ting()
        {
            if (!this.com.IsOpen)
                return false;
            try
            {
                this.com.Write(new byte[4]
                {
          (byte) 24,
          (byte) 0,
          (byte) 4,
          (byte) 0
                }, 0, 4);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            int num1 = 10;
            this.returnCode = false;
            while (0 < num1--)
            {
                Thread.Sleep(10);
                this.chuli_shijian();
                if (this.returnCode)
                    return true;
            }
            return false;
        }

        public bool ji_xu()
        {
            if (!this.com.IsOpen)
                return false;
            try
            {
                this.com.Write(new byte[4]
                {
          (byte) 25,
          (byte) 0,
          (byte) 4,
          (byte) 0
                }, 0, 4);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            int num1 = 10;
            this.returnCode = false;
            while (0 < num1--)
            {
                Thread.Sleep(10);
                this.chuli_shijian();
                if (this.returnCode)
                    return true;
            }
            return false;
        }

        public bool ting_zhi()
        {
            isRunning = false;
            if (!com.IsOpen)
                return false;

            try
            {
                com.Write(new byte[4]
                {
                    22,
                    0,
                    4,
                    0
                }, 0, 4);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }

        private bool closeComConnection()
        {
            try
            {
                com.Close();
                com.Open();

                if (!com.IsOpen)
                    return false;

                com.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool diaoke2()
        {
            Bitmap bitmap = new Bitmap((System.Drawing.Image)this.tu_diaoke);
            this.hf_bmp = bitmap;
            this.fu_wei();
            this.kai_shi((int)((double)this.hua_ban.Location.X * ((double)this.xian_k / (double)this.change_half.Width)), (int)((double)this.hua_ban.Location.Y * ((double)this.xian_k / (double)this.change_half.Width)));
            byte[] buffer = bitmap.Width % 8 <= 0 ? new byte[bitmap.Width / 8 + 9] : new byte[bitmap.Width / 8 + 10];
            byte[] numArray = new byte[8]
            {
        (byte) 128,
        (byte) 64,
        (byte) 32,
        (byte) 16,
        (byte) 8,
        (byte) 4,
        (byte) 2,
        (byte) 1
            };
            this.com.DiscardInBuffer();
            for (int y = 0; y < bitmap.Height; ++y)
            {
                int num1 = 0;
                for (int index1 = 0; index1 < buffer.Length - 9; ++index1)
                {
                    byte num2 = 0;
                    for (int index2 = 0; index2 < 8; ++index2)
                    {
                        if (index1 * 8 + index2 < bitmap.Width && bitmap.GetPixel(index1 * 8 + index2, y).R == (byte)0)
                            num2 |= numArray[index2];
                    }
                    buffer[num1 + 9] = num2;
                    ++num1;
                }
                buffer[0] = (byte)9;
                buffer[1] = (byte)(buffer.Length >> 8);
                buffer[2] = (byte)buffer.Length;
                buffer[3] = (byte)(this.tiao_shendu.Value >> 8);
                buffer[4] = (byte)this.tiao_shendu.Value;
                buffer[5] = (byte)(this.tiao_gonglv.Value * 10 >> 8);
                buffer[6] = (byte)(this.tiao_gonglv.Value * 10);
                buffer[7] = (byte)(y >> 8);
                buffer[8] = (byte)y;
                bool flag1 = false;
                for (int index = 9; index < buffer.Length; ++index)
                {
                    if (buffer[index] != (byte)0)
                    {
                        flag1 = true;
                        break;
                    }
                }
                if (flag1)
                {
                label_15:
                    do
                    {
                        try
                        {
                            this.com.DiscardInBuffer();
                            this.returnCode = false;
                            this.com.Write(buffer, 0, buffer.Length);
                        }
                        catch (Exception ex)
                        {
                            this.com.Close();
                            Thread.Sleep(500);
                            string portName1 = this.com.PortName;
                            bool flag2 = false;
                            do
                            {
                                foreach (string portName2 in SerialPort.GetPortNames())
                                {
                                    if (portName2 == portName1)
                                    {
                                        flag2 = true;
                                        while (!this.closeComConnection())
                                            ;
                                        break;
                                    }
                                }
                                Thread.Sleep(100);
                                this.chuli_shijian();
                            }
                            while (!flag2);
                            this.com.Open();
                            continue;
                        }
                        int num3 = 0;
                        while (!this.returnCode)
                        {
                            if (this.com.IsOpen)
                            {
                                ++num3;
                                if (this.stopped)
                                {
                                    this.ting_zhi_dk();
                                    return false;
                                }
                                if (this.zanting)
                                {
                                    if (this.pause)
                                        this.zan_ting();
                                    else
                                        this.ji_xu();
                                    this.zanting = false;
                                }
                                this.chuli_shijian();
                                Thread.Sleep(10);
                            }
                            else
                                goto label_15;
                        }
                        this.chuli_shijian();
                        Thread.Sleep(10);
                    }
                    while (this.returnValue == 8);
                }
                lock (Form1.locker)
                    this.m_jd = (int)((double)y / (double)bitmap.Height * 100.0);
                this.jin_du_();
                this.shua_xin();
            }
            this.ting_zhi_dk();
            return true;
        }

        private void diaoke_lijing()
        {
            Bitmap bitmap = new Bitmap((System.Drawing.Image)this.tu_diaoke);
            List<byte> byteList = new List<byte>();
            this.fu_wei();
            this.kai_shi((int)((double)this.hua_ban.Location.X * ((double)this.xian_k / (double)this.change_half.Width)), (int)((double)this.hua_ban.Location.Y * ((double)this.xian_k / (double)this.change_half.Width)));
            for (int index = 0; index < this.xian.Count; ++index)
            {
                byteList.Add((byte)(this.xian[index].q.x >> 8));
                byteList.Add((byte)this.xian[index].q.x);
                byteList.Add((byte)(this.xian[index].q.y >> 8));
                byteList.Add((byte)this.xian[index].q.y);
                byteList.Add((byte)(this.xian[index].zh.x >> 8));
                byteList.Add((byte)this.xian[index].zh.x);
                byteList.Add((byte)(this.xian[index].zh.y >> 8));
                byteList.Add((byte)this.xian[index].zh.y);
                lock (bitmap)
                {
                    Graphics graphics = Graphics.FromImage((System.Drawing.Image)bitmap);
                    Pen pen = new Pen(Color.Red, 5f);
                    graphics.DrawLine(pen, new System.Drawing.Point(this.xian[index].q.x, this.xian[index].q.y), new System.Drawing.Point(this.xian[index].zh.x, this.xian[index].zh.y));
                    graphics.Dispose();
                    pen.Dispose();
                }
                if (byteList.Count == 640)
                {
                    byteList.Insert(0, (byte)(this.tiao_gonglv.Value * 10));
                    byteList.Insert(0, (byte)(this.tiao_gonglv.Value * 10 >> 8));
                    byteList.Insert(0, (byte)this.tiao_shendu.Value);
                    byteList.Insert(0, (byte)(this.tiao_shendu.Value >> 8));
                    byteList.Insert(0, (byte)135);
                    byteList.Insert(0, (byte)2);
                    byteList.Insert(0, (byte)29);
                label_8:
                    do
                    {
                        try
                        {
                            this.returnCode = false;
                            this.com.Write(byteList.ToArray(), 0, byteList.ToArray().Length);
                            byteList.Clear();
                        }
                        catch (Exception ex)
                        {
                            this.com.Close();
                            Thread.Sleep(500);
                            string portName1 = this.com.PortName;
                            bool flag = false;
                            do
                            {
                                foreach (string portName2 in SerialPort.GetPortNames())
                                {
                                    if (portName2 == portName1)
                                    {
                                        flag = true;
                                        while (!this.closeComConnection())
                                            ;
                                        break;
                                    }
                                }
                                Thread.Sleep(100);
                                this.chuli_shijian();
                            }
                            while (!flag);
                            this.com.Open();
                            continue;
                        }
                        int num = 0;
                        while (!this.returnCode)
                        {
                            if (this.com.IsOpen)
                            {
                                ++num;
                                if (this.stopped)
                                {
                                    this.ting_zhi_dk();
                                    return;
                                }
                                if (this.zanting)
                                {
                                    if (this.pause)
                                        this.zan_ting();
                                    else
                                        this.ji_xu();
                                    this.zanting = false;
                                }
                                this.chuli_shijian();
                                Thread.Sleep(10);
                            }
                            else
                                goto label_8;
                        }
                    }
                    while (this.returnValue == 8);
                }
            }
            if (byteList.Count > 0)
            {
                int num1 = byteList.Count + 7;
                byteList.Insert(0, (byte)(this.tiao_gonglv.Value * 10));
                byteList.Insert(0, (byte)(this.tiao_gonglv.Value * 10 >> 8));
                byteList.Insert(0, (byte)this.tiao_shendu.Value);
                byteList.Insert(0, (byte)(this.tiao_shendu.Value >> 8));
                byteList.Insert(0, (byte)num1);
                byteList.Insert(0, (byte)(num1 >> 8));
                byteList.Insert(0, (byte)29);
                try
                {
                    if (!this.com.IsOpen)
                        return;
                    this.returnCode = false;
                    this.com.Write(byteList.ToArray(), 0, byteList.ToArray().Length);
                    byteList.Clear();
                }
                catch (Exception ex)
                {
                    int num2 = (int)MessageBox.Show(ex.ToString());
                }
                int num3 = 0;
                while (!this.returnCode)
                {
                    ++num3;
                    if (this.stopped)
                    {
                        this.ting_zhi_dk();
                        return;
                    }
                    if (this.zanting)
                    {
                        if (this.pause)
                            this.zan_ting();
                        else
                            this.ji_xu();
                        this.zanting = false;
                    }
                    this.chuli_shijian();
                    Thread.Sleep(10);
                }
            }
            this.ting_zhi_dk();
        }

        private void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!com.IsOpen)
                return;
            if (com.BytesToRead == 1)
            {
                switch (com.ReadByte())
                {
                    case 8:
                        returnValue = 8;
                        returnCode = true;
                        com.DiscardInBuffer();
                        break;
                    case 9:
                        returnValue = 9;
                        returnCode = true;
                        com.DiscardInBuffer();
                        break;
                }
            }
            else if (com.BytesToRead == 4)
            {
                int num1 = com.ReadByte();
                int num2 = com.ReadByte();
                int num3 = com.ReadByte();
                int num4 = com.ReadByte();

                //Check if bytes 1-3 are max value and byte 4 has the first bit 0
                if (num1 == byte.MaxValue && num2 == byte.MaxValue && num3 == byte.MaxValue && num4 == 254)
                    fs_wc = true;
                
                com.DiscardInBuffer();
            }
            else if (com.BytesToRead == 3)
            {
                //This is likely something with serial or model number?
                if (qu_xinghao)
                {
                    qu_xinghao = false;
                    modelNumber = com.ReadByte().ToString() + ",";
                    modelNumber = modelNumber + com.ReadByte().ToString() + ",";
                    modelNumber += com.ReadByte().ToString();
                    returnCode = true;
                }
                com.DiscardInBuffer();
            }
            else
            {
                if (9 == com.ReadByte())
                    returnCode = true;

                com.DiscardInBuffer();
            }
        }

        //"kaishi" - Start/Initialize
        private void but_kaishi_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                zanting = true;
                pause = !pause;

                if (pause == true)
                {
                    btn_start.Text = continueString;
                    elapsedTimeTimer.Enabled = false;
                }
                else
                {
                    btn_start.Text = pauseString;
                    elapsedTimeTimer.Enabled = true;
                }
            }
            else if (!this.engraverConnected)
            {
                int num1 = (int)MessageBox.Show(str22);
            }
            else if (this.showingPreview)
            {
                int num2 = (int)MessageBox.Show(stopPreviewString);
            }
            else
            {
                elapsedTimeTimer.Enabled = true; //timer object
                btn_start.Text = pauseString;
                time = 0;
                isRunning = true;
                stopped = false;
                shi_liang = this.pictureProcessingDropDownMenu.SelectedIndex == 2;
                m_jd = 0;
                jdt.Value = 0;
                new Thread(new ThreadStart(this.dk)).Start();
                this.jdt.Visible = true;
                do
                {
                    this.chuli_shijian();
                    Thread.Sleep(10);
                    if (this.shu_ > 0)
                        this.jdt.Value = (int)((double)this.progress / (double)this.shu_ * 100.0);
                }
                while (this.jdt.Value < 98);
                this.jdt.Visible = false;
            }
        }

        private double qu_cha(Form1.Dian dd1, Form1.Dian dd2)//translated to - go to check??
        {
            int num1 = Math.Abs(dd1.y - dd2.y);
            int num2 = Math.Abs(dd1.x - dd2.x);
            return Math.Sqrt((num1 * num1 + num2 * num2));
        }

        private List<Form1.Dian> qu_dian1111() //translated to - outgoing call??
        {
            int index1 = 0;
            List<Form1.Dian> dianList1 = new List<Form1.Dian>();
            List<Form1.Dian> dianList2 = new List<Form1.Dian>(dian);
            this.shu_ = this.dian.Count;
            this.progress = 0;
            for (int index2 = 0; index2 < this.shu_; ++index2)
            {
                this.progress = index2;
                if (index2 == 0)
                {
                    dianList1.Add(dianList2[0]);
                    dianList2.RemoveAt(0);
                }
                else
                {
                    bool flag1 = false;
                    bool flag2 = false;
                    int count = dianList2.Count;
                    for (int index3 = 0; index3 < count; ++index3)
                    {
                        double num = qu_cha(dianList1[dianList1.Count - 1], dianList2[index3]);
                        if (num == 1.0)
                        {
                            dianList1.Add(dianList2[index3]);
                            dianList2.RemoveAt(index3);
                            flag2 = true;
                            break;
                        }
                        if (!flag1)
                        {
                            index1 = index3;
                            flag1 = true;
                        }
                        if (qu_cha(dianList1[dianList1.Count - 1], dianList2[index1]) > num)
                            index1 = index3;
                    }
                    if (!flag2)
                    {
                        dianList1.Add(dianList2[index1]);
                        dianList2.RemoveAt(index1);
                    }
                }
            }
            return dianList1;
        }

        private bool xiang_lian(Form1.Dian dd1, Form1.Dian dd2) => Math.Abs(dd1.x - dd2.x) <= 1 && Math.Abs(dd1.y - dd2.y) <= 1;

        private void qu_xian()
        {
            bool flag = false;
            this.xian.Clear();
            for (int index = 0; index < this.dian.Count; ++index)
            {
                if (index == 0)
                {
                    xian_linshi.q = new Dian(50001, 50001);
                    xian_linshi.zh = new Dian(50001, 50001);
                    xian.Add(xian_linshi);
                    xian_linshi.q = dian[0];
                    flag = true;
                }
                else if (flag)
                {
                    if (this.xiang_lian(this.xian_linshi.q, this.dian[index]))
                    {
                        this.xian_linshi.zh = this.dian[index];
                        this.xian.Add(this.xian_linshi);
                        flag = false;
                    }
                    else
                    {
                        this.xian_linshi.zh = this.xian_linshi.q;
                        this.xian.Add(this.xian_linshi);
                        this.xian_linshi.q = new Form1.Dian(50000, 50000);
                        this.xian_linshi.zh = new Form1.Dian(50000, 50000);
                        this.xian.Add(this.xian_linshi);
                        this.xian_linshi.q = this.xian[this.xian.Count - 2].zh;
                        this.xian_linshi.zh = this.dian[index];
                        this.xian.Add(this.xian_linshi);
                        this.xian_linshi.q = new Form1.Dian(50001, 50001);
                        this.xian_linshi.zh = new Form1.Dian(50001, 50001);
                        this.xian.Add(this.xian_linshi);
                        this.xian_linshi.q = this.dian[index];
                        flag = true;
                    }
                }
                else if (this.xiang_lian(this.xian[this.xian.Count - 1].zh, this.dian[index]))
                {
                    this.xian_linshi.q = this.xian[this.xian.Count - 1].zh;
                    this.xian_linshi.zh = this.dian[index];
                    this.xian.Add(this.xian_linshi);
                }
                else
                {
                    this.xian_linshi.q = new Form1.Dian(50000, 50000);
                    this.xian_linshi.zh = new Form1.Dian(50000, 50000);
                    this.xian.Add(this.xian_linshi);
                    this.xian_linshi.q = this.xian[this.xian.Count - 2].zh;
                    this.xian_linshi.zh = this.dian[index];
                    this.xian.Add(this.xian_linshi);
                    this.xian_linshi.q = new Form1.Dian(50001, 50001);
                    this.xian_linshi.zh = new Form1.Dian(50001, 50001);
                    this.xian.Add(this.xian_linshi);
                    this.xian_linshi.q = this.dian[index];
                    flag = true;
                }
            }
            this.xian_linshi.q = new Form1.Dian(50000, 50000);
            this.xian_linshi.zh = new Form1.Dian(50000, 50000);
            this.xian.Add(this.xian_linshi);
        }

        private void qu_lujing()
        {
            qu_dian1(this.tu_diaoke);
            dian = this.qu_dian1111();
            qu_xian();
        }

        public void qu_dian1(Bitmap bb)
        {
            Bitmap bitmap = new Bitmap((System.Drawing.Image)bb);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr scan0 = bitmapData.Scan0;
            dian.Clear();
            int length1 = Math.Abs(bitmapData.Stride) * bitmap.Height;
            byte[] destination = new byte[length1];
            Marshal.Copy(scan0, destination, 0, length1);
            int num = bitmap.Width * 4;
            int length2 = destination.Length;
            for (int index = num; index < length2; index += 4)
            {
                if (destination[index] == (byte)0)
                {
                    dian_lishi.x = (int)(ushort)(index % num / 4 - 1);
                    dian_lishi.y = (int)(ushort)(index / num - 1);
                    dian.Add(this.dian_lishi);
                }
            }
        }

        private void dk()
        {
            if (shi_liang)
            {
                hf_bmp = new Bitmap(tu_diaoke);
                qu_lujing();
                diaoke_lijing();
            }
            else
                diaoke2();
            elapsedTimeTimer.Enabled = false;
        }

        private void tz()
        {
            isRunning = false;
            pause = false;
            zanting = false;
            jin_du_guan();
            btn_start.Text = startString;
            hui_fu();
            ting_zhi();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!isRunning)
                return;

            stopped = true;
        }

        private void tiao_gonglv_Scroll(object sender, EventArgs e) => this.skinLabel2.Text = this.tiao_gonglv.Value.ToString() + "%";

        private void tiao_shendu_Scroll(object sender, EventArgs e) => this.skinLabel3.Text = this.tiao_shendu.Value.ToString() + "%";

        public bool dao_yuandian()
        {
            if (!com.IsOpen)
                return false;
            try
            {
                this.com.Write(new byte[4]
                {
                    23,
                    0,
                    4,
                    0
                }, 0, 4);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            int num1 = 300;
            returnCode = false;

            while (0 < num1--)
            {
                Thread.Sleep(10);
                chuli_shijian();
                if (returnCode)
                    return true;
            }
            return false;
        }

        public bool du_ban_ben()
        {
            if (!com.IsOpen)
                return false;
            try
            {
                com.Write(new byte[4]
                {
                    byte.MaxValue,
                    0,
                    4,
                    0
                }, 0, 4);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            int num1 = 300;
            this.returnCode = false;
            while (0 < num1--)
            {
                Thread.Sleep(10);
                this.chuli_shijian();
                if (this.returnCode)
                    return true;
            }
            return false;
        }

        private void but_chongzhi_Click(object sender, EventArgs e)
        {
            if (!this.engraverConnected)
            {
                int num = (int)MessageBox.Show(str22);
            }
            else
            {
                if (this.isRunning || !this.engraverConnected || tj_zt)
                    return;
                this.hua_ban.Location = new System.Drawing.Point();
                this.dao_yuandian();
            }
        }

        private void xuan_ze_SelectedIndexChanged(object sender, EventArgs e)
        {
            fang_shi = pictureProcessingDropDownMenu.SelectedIndex + 1;
            chu_li();
            if (pictureProcessingDropDownMenu.SelectedIndex == 3)
            {
                tiao_shendu.Value = 20;
                skinLabel3.Text = "20%";
                txtBoxWidth.Enabled = true;
                txtBoxHeight.Enabled = true;
            }
            else if (this.pictureProcessingDropDownMenu.SelectedIndex == 0 || pictureProcessingDropDownMenu.SelectedIndex == 1)
            {
                tiao_shendu.Value = 10;
                skinLabel3.Text = "10%";
                txtBoxWidth.Enabled = true;
                txtBoxHeight.Enabled = true;
            }
            else
            {
                tiao_shendu.Value = 10;
                skinLabel3.Text = "10%";
                txtBoxWidth.Enabled = false;
                txtBoxHeight.Enabled = false;
            }
        }

        private void move(int k)
        {
            switch (k)
            {
                case 37:
                    this.an_xia = true;
                    this.yi_dian = new System.Drawing.Point(0, 0);
                    this.qi_dian = this.hua_ban.Location;
                    this.hua_ban_MouseMove((object)null, new MouseEventArgs(MouseButtons.Left, 0, -this.bushu, 0, 0));
                    this.hua_ban_MouseUp((object)null, (MouseEventArgs)null);
                    this.hua_ban.Focus();
                    break;
                case 38:
                    this.an_xia = true;
                    this.yi_dian = new System.Drawing.Point(0, 0);
                    this.qi_dian = this.hua_ban.Location;
                    this.hua_ban_MouseMove((object)null, new MouseEventArgs(MouseButtons.Left, 0, 0, -this.bushu, 0));
                    this.hua_ban_MouseUp((object)null, (MouseEventArgs)null);
                    this.hua_ban.Focus();
                    break;
                case 39:
                    this.an_xia = true;
                    this.yi_dian = new System.Drawing.Point(0, 0);
                    this.qi_dian = this.hua_ban.Location;
                    this.hua_ban_MouseMove((object)null, new MouseEventArgs(MouseButtons.Left, 0, this.bushu, 0, 0));
                    this.hua_ban_MouseUp((object)null, (MouseEventArgs)null);
                    this.hua_ban.Focus();
                    break;
                case 40:
                    this.an_xia = true;
                    this.yi_dian = new System.Drawing.Point(0, 0);
                    this.qi_dian = this.hua_ban.Location;
                    this.hua_ban_MouseMove((object)null, new MouseEventArgs(MouseButtons.Left, 0, 0, this.bushu, 0));
                    this.hua_ban_MouseUp((object)null, (MouseEventArgs)null);
                    this.hua_ban.Focus();
                    break;
            }
        }

        private void hua_ban_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (this.isRunning || !this.engraverConnected)
                return;
            for (int index = 0; index < 10; ++index)
            {
                Thread.Sleep(2);
                this.change_half.Refresh();
            }
            this.move(e.KeyValue);
        }

        private void huan_ban_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (this.isRunning || !this.engraverConnected)
                return;
            this.move(e.KeyValue);
        }

        private void skinButton1_Click(object sender, EventArgs e) => this.menu.Show((Control)(sender as Button), (sender as Button).PointToClient(Cursor.Position), ToolStripDropDownDirection.BelowRight);

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.selectedLanguge = "ch";
            this.ini.IniWriteValue("selectedLanguge", "selectedLanguge", this.selectedLanguge);
            this.UpdateNewLanguage();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.selectedLanguge = "en";
            this.ini.IniWriteValue("selectedLanguge", "selectedLanguge", this.selectedLanguge);
            this.UpdateNewLanguage();
        }

        private void japaneseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.selectedLanguge = "jp";
            this.ini.IniWriteValue("selectedLanguge", "selectedLanguge", this.selectedLanguge);
            this.UpdateNewLanguage();
        }

        private void SetUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new set().Show();
            set.m_formA.zhi(this.ruo, this.hang_yan_shi, this.TIM_chong_zhuang_zhi, this.BU, this.x_buchang, this.y_buchang, this.SS, this.MM1, this.KUAI, this.kuang_sd, this.modelNumber);
        }

        private void pifu()
        {
            if (!this.ini.ExistINIFile())
                return; //If .ini file does not exist

            string str = ini.IniReadValue("pi_fu", "pi_fu");
            if (!File.Exists(str))
                return;
            Bitmap bitmap1 = new Bitmap(Width, Height);
            Bitmap bitmap2 = new Bitmap(str);
            Graphics graphics = Graphics.FromImage(bitmap1);
            graphics.DrawImage(bitmap2, 0, 0, Width, Height);
            graphics.Dispose();
            BackgroundImage = bitmap1;
        }

        private void SkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.pi_fu.ShowDialog() != DialogResult.OK)
                return;
            this.ini.IniWriteValue("pi_fu", "pi_fu", this.pi_fu.FileName);
            this.pifu();
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            if (this.isRunning)
                return;
            string ss = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            this.bmpFileDialog.FileName = ss;
            this.da_kai(ss);
        }

        private void text_wenzi_Leave(object sender, EventArgs e)
        {
            if (!this.txtBoxText.Visible || this.panel6.Visible)
                return;
            this.txtBoxText.Visible = false;
            if (this.openImage)
            {
                Bitmap bitmap = this.qu_tu();
                int num1 = (int)((double)(this.txtBoxText.Location.X - this.hua_ban.Location.X) * (double)this.xian_k / (double)this.change_half.Width);
                int num2 = (int)((double)(this.txtBoxText.Location.Y - this.hua_ban.Location.Y) * (double)this.xian_k / (double)this.change_half.Width);
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    for (int y = 0; y < bitmap.Height; ++y)
                    {
                        if (bitmap.GetPixel(x, y).R < (byte)1 && x + num1 > 0 && x + num1 < this.tu_diaoke.Width && y + num2 > 0 && y + num2 < this.tu_diaoke.Height)
                            this.tu_diaoke.SetPixel(x + num1, y + num2, Color.Black);
                    }
                }
                this.qu_bian();
                this.hua_ban.BackgroundImage = (System.Drawing.Image)this.tu_diaoke;
                this.hua_ban.Refresh();
            }
            else
            {
                this.openText = true;
                this.tu_yuan = this.qu_tu();
                if (this.tu_yuan.Width > this.xian_k || this.tu_yuan.Height > this.xian_g)
                {
                    int newH;
                    int newW;
                    if (this.tu_yuan.Width - this.xian_k > this.tu_yuan.Height - this.xian_g)
                    {
                        newH = (int)((double)this.tu_yuan.Height * ((double)this.xian_k / (double)this.tu_yuan.Width));
                        newW = this.xian_k;
                    }
                    else
                    {
                        newW = (int)((double)this.tu_yuan.Width * ((double)this.xian_g / (double)this.tu_yuan.Height));
                        newH = this.xian_g;
                    }
                    this.tu_yuan = this.resizeBitmap(this.tu_yuan, newW, newH);
                }
                this.pictureScaling = new Bitmap((System.Drawing.Image)this.tu_yuan);
                this.hua_ban.Width = (int)((double)this.pictureScaling.Width * ((double)this.change_half.Width / (double)this.xian_k));
                this.hua_ban.Height = (int)((double)this.pictureScaling.Height * ((double)this.change_half.Width / (double)this.xian_k));
                this.bi = (double)this.hua_ban.Width / (double)this.hua_ban.Height;
                this.chu_li();
            }
        }

        private void kg_bi_suoding_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.openText && !this.openImage)
                return;
            this.da_kai(this.bmpFileDialog.FileName);
        }

        private void to_bmp(object ss2)
        {
            string[] strArray = (string[])ss2;
            int num1 = strArray[0].LastIndexOf("\\");
            string path = strArray[0].Substring(0, num1 + 1) + "BMP";
            Directory.CreateDirectory(path);
            Bitmap bitmap = new Bitmap(1, 1);
            this.shu_ = strArray.Length;
            for (int index = 0; index < strArray.Length; ++index)
            {
                this.progress = index + 1;
                int num2 = strArray[index].LastIndexOf("\\");
                int num3 = strArray[index].LastIndexOf(".");
                string str = strArray[index].Substring(num2 + 1, num3 - num2 - 1);
                bitmap = new Bitmap(strArray[index]);
                bitmap.Save(path + "\\" + str + ".bmp", ImageFormat.Bmp);
            }
            bitmap.Dispose();
            Process.Start(new ProcessStartInfo("Explorer.exe")
            {
                Arguments = "/e," + path
            });
        }

        private void 批量转换到BMP格式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = this.pictureString + "|*.jpg;*.jpge;*.png;";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            new Thread(new ParameterizedThreadStart(to_bmp)).Start(openFileDialog.FileNames);
            jdt.Visible = true;
            do
            {
                this.chuli_shijian();
                Thread.Sleep(10);
                if (shu_ > 0)
                    jdt.Value = (int)(progress / shu_ * 100.0);
            }
            while (jdt.Value < 100);
            jdt.Visible = false;
        }

        private void elapsedTimeTimer_Tick(object sender, EventArgs e)
        {
            ++time;
            int hours = time / 3600;
            int minutes = time % 3600 / 60;
            int seconds = time % 3600 % 60;
            elapsedTimeLbl.Text = hours.ToString() + "," + minutes.ToString() + "," + seconds.ToString();
        }

        private void text_wenzi_DoubleClick(object sender, EventArgs e)
        {
            if (isRunning)
                return;
            panel6.Visible = true;
        }

        private void text_kuan_Leave(object sender, EventArgs e) => this.text_kuan_KeyPress((object)null, new KeyPressEventArgs('\r'));

        private void text_gao_Leave(object sender, EventArgs e) => this.text_gao_KeyPress((object)null, new KeyPressEventArgs('\r'));

        private void button1_Click(object sender, EventArgs e) => this.yi_dong_z(true);

        private void button2_Click(object sender, EventArgs e) => this.yi_dong_z(false);

        public bool yi_dong_z(bool j)
        {
            if (!com.IsOpen)
                return false;
            try
            {
                if (j)
                    com.Write(new byte[4]
                    {
                        253, 0, 4, 0
                    }
                    , 0, 4);
                else
                    com.Write(new byte[4]
                    {
                        254, 0, 4, 0
                    }
                    , 0, 4);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                return false;
            }
            int num1 = 300;
            returnCode = false;

            while (0 < num1--)
            {
                Thread.Sleep(10);
                chuli_shijian();

                if (returnCode)
                    return true;
            }
            return false;
        }

        private void huan_ban_Paint(object sender, PaintEventArgs e)
        {
            for (int index = 0; index < 18; ++index)
            {
                e.Graphics.DrawLine(Pens.LightGray, new PointF(0.0f, (float)(index * 6.25 * 5.0)), new PointF(500f, (float)(index * 6.25 * 5.0)));
                e.Graphics.DrawLine(Pens.LightGray, new PointF((float)(index * 6.25 * 5.0), 0.0f), new PointF((float)(index * 6.25 * 5.0), 500f));
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.change_half = new CCWin.SkinControl.SkinPanel();
            this.jdt = new CCWin.SkinControl.SkinProgressBar();
            this.txtBoxText = new System.Windows.Forms.TextBox();
            this.hua_ban = new CCWin.SkinControl.SkinPictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.btnFlip = new CCWin.SkinControl.SkinButton();
            this.btnRotate = new CCWin.SkinControl.SkinButton();
            this.but_trash = new CCWin.SkinControl.SkinButton();
            this.but_fanse = new CCWin.SkinControl.SkinButton();
            this.btn_mmToInch = new CCWin.SkinControl.SkinButton();
            this.btnAddText = new CCWin.SkinControl.SkinButton();
            this.btn_disconnectConnectDevice = new CCWin.SkinControl.SkinButton();
            this.btnOpenPicture = new CCWin.SkinControl.SkinButton();
            this.btn_start = new CCWin.SkinControl.SkinButton();
            this.btnStop = new CCWin.SkinControl.SkinButton();
            this.pictureProcessingDropDownMenu = new CCWin.SkinControl.SkinComboBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.tiao_gonglv = new CCWin.SkinControl.SkinTrackBar();
            this.tiao_shendu = new CCWin.SkinControl.SkinTrackBar();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.btnPreview = new CCWin.SkinControl.SkinButton();
            this.btnResetCoordinates = new CCWin.SkinControl.SkinButton();
            this.widthLabel = new CCWin.SkinControl.SkinLabel();
            this.heightLabel = new CCWin.SkinControl.SkinLabel();
            this.mmInchLabel1 = new CCWin.SkinControl.SkinLabel();
            this.mmInchLabel2 = new CCWin.SkinControl.SkinLabel();
            this.btn_save = new CCWin.SkinControl.SkinButton();
            this.com = new System.IO.Ports.SerialPort(this.components);
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.LED = new CCWin.SkinControl.SkinPanel();
            this.bmpFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ding_cl = new System.Windows.Forms.Timer(this.components);
            this.txtBoxWidth = new System.Windows.Forms.TextBox();
            this.txtBoxHeight = new System.Windows.Forms.TextBox();
            this.but_tuoji = new CCWin.SkinControl.SkinButton();
            this.btnSettings = new CCWin.SkinControl.SkinButton();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pi_fu = new System.Windows.Forms.OpenFileDialog();
            this.lockAspectRatioChkBox = new System.Windows.Forms.CheckBox();
            this.elapsedTimeLbl = new CCWin.SkinControl.SkinLabel();
            this.elapsedTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.change_half.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hua_ban)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiao_gonglv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiao_shendu)).BeginInit();
            this.skinPanel2.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // change_half
            // 
            this.change_half.BackColor = System.Drawing.Color.Transparent;
            this.change_half.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.change_half.Controls.Add(this.jdt);
            this.change_half.Controls.Add(this.txtBoxText);
            this.change_half.Controls.Add(this.hua_ban);
            this.change_half.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.change_half.DownBack = null;
            this.change_half.Location = new System.Drawing.Point(7, 88);
            this.change_half.MouseBack = null;
            this.change_half.Name = "change_half";
            this.change_half.NormlBack = null;
            this.change_half.Size = new System.Drawing.Size(500, 500);
            this.change_half.TabIndex = 0;
            this.change_half.Click += new System.EventHandler(this.huan_ban_Click);
            this.change_half.Paint += new System.Windows.Forms.PaintEventHandler(this.huan_ban_Paint);
            this.change_half.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.huan_ban_PreviewKeyDown);
            // 
            // jdt
            // 
            this.jdt.Back = null;
            this.jdt.BackColor = System.Drawing.Color.Transparent;
            this.jdt.BarBack = null;
            this.jdt.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.jdt.ForeColor = System.Drawing.Color.Red;
            this.jdt.Location = new System.Drawing.Point(91, 458);
            this.jdt.Name = "jdt";
            this.jdt.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.jdt.Size = new System.Drawing.Size(311, 37);
            this.jdt.TabIndex = 3;
            this.jdt.TrackFore = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.jdt.Visible = false;
            // 
            // txtBoxText
            // 
            this.txtBoxText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxText.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.txtBoxText.Font = new System.Drawing.Font("SimSun", 32F);
            this.txtBoxText.Location = new System.Drawing.Point(26, 6);
            this.txtBoxText.Multiline = true;
            this.txtBoxText.Name = "txtBoxText";
            this.txtBoxText.Size = new System.Drawing.Size(79, 42);
            this.txtBoxText.TabIndex = 2;
            this.txtBoxText.Text = "ABC";
            this.txtBoxText.Visible = false;
            this.txtBoxText.TextChanged += new System.EventHandler(this.text_wenzi_TextChanged);
            this.txtBoxText.DoubleClick += new System.EventHandler(this.text_wenzi_DoubleClick);
            this.txtBoxText.Leave += new System.EventHandler(this.text_wenzi_Leave);
            this.txtBoxText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.text_wenzi_MouseDown);
            this.txtBoxText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.text_wenzi_MouseMove);
            this.txtBoxText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.text_wenzi_MouseUp);
            // 
            // hua_ban
            // 
            this.hua_ban.BackColor = System.Drawing.Color.White;
            this.hua_ban.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hua_ban.Location = new System.Drawing.Point(0, 0);
            this.hua_ban.Name = "hua_ban";
            this.hua_ban.Size = new System.Drawing.Size(20, 20);
            this.hua_ban.TabIndex = 1;
            this.hua_ban.TabStop = false;
            this.hua_ban.Click += new System.EventHandler(this.hua_ban_Click);
            this.hua_ban.Paint += new System.Windows.Forms.PaintEventHandler(this.hua_ban_Paint);
            this.hua_ban.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hua_ban_MouseDown);
            this.hua_ban.MouseMove += new System.Windows.Forms.MouseEventHandler(this.hua_ban_MouseMove);
            this.hua_ban.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hua_ban_MouseUp);
            this.hua_ban.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.hua_ban_PreviewKeyDown);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Honeydew;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.skinLabel6);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.radioButton4);
            this.panel6.Controls.Add(this.radioButton3);
            this.panel6.Controls.Add(this.radioButton2);
            this.panel6.Controls.Add(this.radioButton5);
            this.panel6.Controls.Add(this.listBox1);
            this.panel6.Controls.Add(this.trackBar5);
            this.panel6.Location = new System.Drawing.Point(105, 298);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(303, 290);
            this.panel6.TabIndex = 78;
            this.panel6.Visible = false;
            // 
            // skinLabel6
            // 
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skinLabel6.Font = new System.Drawing.Font("Microsoft YaHei", 18F);
            this.skinLabel6.ForeColor = System.Drawing.Color.Red;
            this.skinLabel6.Location = new System.Drawing.Point(277, 2);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(20, 20);
            this.skinLabel6.TabIndex = 14;
            this.skinLabel6.Text = "*";
            this.skinLabel6.Click += new System.EventHandler(this.skinLabel6_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "16";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(303, 24);
            this.label16.TabIndex = 12;
            this.label16.Text = "字体选择";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label16_MouseDown);
            this.label16.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label16_MouseMove);
            this.label16.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label16_MouseUp);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(198, 253);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(73, 17);
            this.radioButton4.TabIndex = 11;
            this.radioButton4.Text = "粗体斜体";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(198, 192);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(49, 17);
            this.radioButton3.TabIndex = 10;
            this.radioButton3.Text = "斜体";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(198, 131);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(49, 17);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.Text = "粗体";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Checked = true;
            this.radioButton5.Location = new System.Drawing.Point(198, 70);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(49, 17);
            this.radioButton5.TabIndex = 8;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "常规";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(20, 68);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(172, 199);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(38, 29);
            this.trackBar5.Maximum = 100;
            this.trackBar5.Minimum = 1;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(244, 45);
            this.trackBar5.TabIndex = 6;
            this.trackBar5.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar5.Value = 16;
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
            // 
            // btnFlip
            // 
            this.btnFlip.BackColor = System.Drawing.Color.Transparent;
            this.btnFlip.BaseColor = System.Drawing.Color.Transparent;
            this.btnFlip.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnFlip.DownBack = null;
            this.btnFlip.GlowColor = System.Drawing.Color.Aqua;
            this.btnFlip.Image = ((System.Drawing.Image)(resources.GetObject("btnFlip.Image")));
            this.btnFlip.ImageSize = new System.Drawing.Size(24, 24);
            this.btnFlip.Location = new System.Drawing.Point(7, 31);
            this.btnFlip.MouseBack = null;
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.NormlBack = null;
            this.btnFlip.Radius = 10;
            this.btnFlip.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnFlip.Size = new System.Drawing.Size(40, 40);
            this.btnFlip.TabIndex = 2;
            this.btnFlip.UseVisualStyleBackColor = false;
            this.btnFlip.Click += new System.EventHandler(this.but_jingxiang_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.BackColor = System.Drawing.Color.Transparent;
            this.btnRotate.BaseColor = System.Drawing.Color.Transparent;
            this.btnRotate.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnRotate.DownBack = null;
            this.btnRotate.GlowColor = System.Drawing.Color.Aqua;
            this.btnRotate.Image = ((System.Drawing.Image)(resources.GetObject("btnRotate.Image")));
            this.btnRotate.ImageSize = new System.Drawing.Size(24, 24);
            this.btnRotate.Location = new System.Drawing.Point(64, 31);
            this.btnRotate.MouseBack = null;
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.NormlBack = null;
            this.btnRotate.Radius = 10;
            this.btnRotate.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnRotate.Size = new System.Drawing.Size(40, 40);
            this.btnRotate.TabIndex = 3;
            this.btnRotate.UseVisualStyleBackColor = false;
            this.btnRotate.Click += new System.EventHandler(this.but_fanzhuan_Click);
            // 
            // but_trash
            // 
            this.but_trash.BackColor = System.Drawing.Color.Transparent;
            this.but_trash.BaseColor = System.Drawing.Color.Transparent;
            this.but_trash.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.but_trash.DownBack = null;
            this.but_trash.GlowColor = System.Drawing.Color.Aqua;
            this.but_trash.Image = ((System.Drawing.Image)(resources.GetObject("but_trash.Image")));
            this.but_trash.ImageSize = new System.Drawing.Size(24, 24);
            this.but_trash.Location = new System.Drawing.Point(178, 31);
            this.but_trash.MouseBack = null;
            this.but_trash.Name = "but_trash";
            this.but_trash.NormlBack = null;
            this.but_trash.Radius = 10;
            this.but_trash.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.but_trash.Size = new System.Drawing.Size(40, 40);
            this.but_trash.TabIndex = 5;
            this.but_trash.UseVisualStyleBackColor = false;
            this.but_trash.Click += new System.EventHandler(this.but_shanchu_Click);
            // 
            // but_fanse
            // 
            this.but_fanse.BackColor = System.Drawing.Color.Transparent;
            this.but_fanse.BaseColor = System.Drawing.Color.Transparent;
            this.but_fanse.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.but_fanse.DownBack = null;
            this.but_fanse.GlowColor = System.Drawing.Color.Aqua;
            this.but_fanse.Image = ((System.Drawing.Image)(resources.GetObject("but_fanse.Image")));
            this.but_fanse.ImageSize = new System.Drawing.Size(24, 24);
            this.but_fanse.Location = new System.Drawing.Point(121, 31);
            this.but_fanse.MouseBack = null;
            this.but_fanse.Name = "but_fanse";
            this.but_fanse.NormlBack = null;
            this.but_fanse.Radius = 10;
            this.but_fanse.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.but_fanse.Size = new System.Drawing.Size(40, 40);
            this.but_fanse.TabIndex = 4;
            this.but_fanse.UseVisualStyleBackColor = false;
            this.but_fanse.Click += new System.EventHandler(this.but_fanse_Click);
            // 
            // btn_mmToInch
            // 
            this.btn_mmToInch.BackColor = System.Drawing.Color.Transparent;
            this.btn_mmToInch.BaseColor = System.Drawing.Color.Transparent;
            this.btn_mmToInch.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_mmToInch.DownBack = null;
            this.btn_mmToInch.GlowColor = System.Drawing.Color.Aqua;
            this.btn_mmToInch.Image = ((System.Drawing.Image)(resources.GetObject("btn_mmToInch.Image")));
            this.btn_mmToInch.ImageSize = new System.Drawing.Size(24, 24);
            this.btn_mmToInch.Location = new System.Drawing.Point(292, 31);
            this.btn_mmToInch.MouseBack = null;
            this.btn_mmToInch.Name = "btn_mmToInch";
            this.btn_mmToInch.NormlBack = null;
            this.btn_mmToInch.Radius = 10;
            this.btn_mmToInch.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btn_mmToInch.Size = new System.Drawing.Size(40, 40);
            this.btn_mmToInch.TabIndex = 7;
            this.btn_mmToInch.UseVisualStyleBackColor = false;
            this.btn_mmToInch.Click += new System.EventHandler(this.btnMmToInch_Click);
            // 
            // btnAddText
            // 
            this.btnAddText.BackColor = System.Drawing.Color.Transparent;
            this.btnAddText.BaseColor = System.Drawing.Color.Transparent;
            this.btnAddText.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnAddText.DownBack = null;
            this.btnAddText.GlowColor = System.Drawing.Color.Aqua;
            this.btnAddText.Image = ((System.Drawing.Image)(resources.GetObject("btnAddText.Image")));
            this.btnAddText.ImageSize = new System.Drawing.Size(24, 24);
            this.btnAddText.Location = new System.Drawing.Point(235, 31);
            this.btnAddText.MouseBack = null;
            this.btnAddText.Name = "btnAddText";
            this.btnAddText.NormlBack = null;
            this.btnAddText.Radius = 10;
            this.btnAddText.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnAddText.Size = new System.Drawing.Size(40, 40);
            this.btnAddText.TabIndex = 6;
            this.btnAddText.UseVisualStyleBackColor = false;
            this.btnAddText.Click += new System.EventHandler(this.but_ziti_Click);
            // 
            // btn_disconnectConnectDevice
            // 
            this.btn_disconnectConnectDevice.BackColor = System.Drawing.Color.Transparent;
            this.btn_disconnectConnectDevice.BaseColor = System.Drawing.Color.Transparent;
            this.btn_disconnectConnectDevice.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_disconnectConnectDevice.DownBack = null;
            this.btn_disconnectConnectDevice.GlowColor = System.Drawing.Color.Aqua;
            this.btn_disconnectConnectDevice.ImageSize = new System.Drawing.Size(24, 24);
            this.btn_disconnectConnectDevice.Location = new System.Drawing.Point(531, 31);
            this.btn_disconnectConnectDevice.MouseBack = null;
            this.btn_disconnectConnectDevice.Name = "btn_disconnectConnectDevice";
            this.btn_disconnectConnectDevice.NormlBack = null;
            this.btn_disconnectConnectDevice.Radius = 10;
            this.btn_disconnectConnectDevice.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btn_disconnectConnectDevice.Size = new System.Drawing.Size(112, 40);
            this.btn_disconnectConnectDevice.TabIndex = 8;
            this.btn_disconnectConnectDevice.Text = "连接设备";
            this.btn_disconnectConnectDevice.UseVisualStyleBackColor = false;
            this.btn_disconnectConnectDevice.Click += new System.EventHandler(this.but_lianjie_Click);
            // 
            // btnOpenPicture
            // 
            this.btnOpenPicture.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenPicture.BaseColor = System.Drawing.Color.Transparent;
            this.btnOpenPicture.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOpenPicture.DownBack = null;
            this.btnOpenPicture.GlowColor = System.Drawing.Color.Aqua;
            this.btnOpenPicture.ImageSize = new System.Drawing.Size(24, 24);
            this.btnOpenPicture.Location = new System.Drawing.Point(531, 88);
            this.btnOpenPicture.MouseBack = null;
            this.btnOpenPicture.Name = "btnOpenPicture";
            this.btnOpenPicture.NormlBack = null;
            this.btnOpenPicture.Radius = 10;
            this.btnOpenPicture.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnOpenPicture.Size = new System.Drawing.Size(229, 40);
            this.btnOpenPicture.TabIndex = 9;
            this.btnOpenPicture.Text = "打开图片";
            this.btnOpenPicture.UseVisualStyleBackColor = false;
            this.btnOpenPicture.Click += new System.EventHandler(this.but_dakai_Click);
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.Transparent;
            this.btn_start.BaseColor = System.Drawing.Color.Transparent;
            this.btn_start.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_start.DownBack = null;
            this.btn_start.GlowColor = System.Drawing.Color.Aqua;
            this.btn_start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_start.ImageSize = new System.Drawing.Size(24, 24);
            this.btn_start.Location = new System.Drawing.Point(531, 143);
            this.btn_start.MouseBack = null;
            this.btn_start.Name = "btn_start";
            this.btn_start.NormlBack = null;
            this.btn_start.Radius = 10;
            this.btn_start.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btn_start.Size = new System.Drawing.Size(112, 40);
            this.btn_start.TabIndex = 11;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.but_kaishi_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BaseColor = System.Drawing.Color.Transparent;
            this.btnStop.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnStop.DownBack = null;
            this.btnStop.GlowColor = System.Drawing.Color.Aqua;
            this.btnStop.ImageSize = new System.Drawing.Size(24, 24);
            this.btnStop.Location = new System.Drawing.Point(649, 143);
            this.btnStop.MouseBack = null;
            this.btnStop.Name = "btnStop";
            this.btnStop.NormlBack = null;
            this.btnStop.Radius = 10;
            this.btnStop.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnStop.Size = new System.Drawing.Size(112, 40);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pictureProcessingDropDownMenu
            // 
            this.pictureProcessingDropDownMenu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pictureProcessingDropDownMenu.FormattingEnabled = true;
            this.pictureProcessingDropDownMenu.Items.AddRange(new object[] {
            "black and white",
            "Discrete",
            "Contour",
            "Sketch"});
            this.pictureProcessingDropDownMenu.Location = new System.Drawing.Point(531, 222);
            this.pictureProcessingDropDownMenu.Name = "pictureProcessingDropDownMenu";
            this.pictureProcessingDropDownMenu.Size = new System.Drawing.Size(229, 21);
            this.pictureProcessingDropDownMenu.TabIndex = 14;
            this.pictureProcessingDropDownMenu.WaterText = "";
            this.pictureProcessingDropDownMenu.SelectedIndexChanged += new System.EventHandler(this.xuan_ze_SelectedIndexChanged);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 11F);
            this.skinLabel1.Location = new System.Drawing.Point(531, 195);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(103, 20);
            this.skinLabel1.TabIndex = 15;
            this.skinLabel1.Text = "图片处理方式:";
            // 
            // tiao_gonglv
            // 
            this.tiao_gonglv.BackColor = System.Drawing.Color.Transparent;
            this.tiao_gonglv.Bar = null;
            this.tiao_gonglv.BarStyle = CCWin.SkinControl.HSLTrackBarStyle.Opacity;
            this.tiao_gonglv.BaseColor = System.Drawing.Color.CornflowerBlue;
            this.tiao_gonglv.Location = new System.Drawing.Point(531, 269);
            this.tiao_gonglv.Name = "tiao_gonglv";
            this.tiao_gonglv.Size = new System.Drawing.Size(190, 45);
            this.tiao_gonglv.TabIndex = 0;
            this.tiao_gonglv.Track = null;
            this.tiao_gonglv.Value = 100;
            this.tiao_gonglv.Scroll += new System.EventHandler(this.tiao_gonglv_Scroll);
            // 
            // tiao_shendu
            // 
            this.tiao_shendu.BackColor = System.Drawing.Color.Transparent;
            this.tiao_shendu.Bar = null;
            this.tiao_shendu.BarStyle = CCWin.SkinControl.HSLTrackBarStyle.Opacity;
            this.tiao_shendu.BaseColor = System.Drawing.Color.CornflowerBlue;
            this.tiao_shendu.Location = new System.Drawing.Point(531, 333);
            this.tiao_shendu.Name = "tiao_shendu";
            this.tiao_shendu.Size = new System.Drawing.Size(190, 45);
            this.tiao_shendu.TabIndex = 0;
            this.tiao_shendu.Track = null;
            this.tiao_shendu.Value = 10;
            this.tiao_shendu.Scroll += new System.EventHandler(this.tiao_shendu_Scroll);
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(726, 281);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(40, 17);
            this.skinLabel2.TabIndex = 17;
            this.skinLabel2.Text = "100%";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(727, 345);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(33, 17);
            this.skinLabel3.TabIndex = 18;
            this.skinLabel3.Text = "10%";
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("Microsoft YaHei", 11F);
            this.skinLabel4.Location = new System.Drawing.Point(531, 255);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(98, 20);
            this.skinLabel4.TabIndex = 19;
            this.skinLabel4.Text = "laser power:";
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("Microsoft YaHei", 11F);
            this.skinLabel5.Location = new System.Drawing.Point(531, 310);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(73, 20);
            this.skinLabel5.TabIndex = 20;
            this.skinLabel5.Text = "雕刻深度:";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.BaseColor = System.Drawing.Color.Transparent;
            this.btnPreview.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnPreview.DownBack = null;
            this.btnPreview.GlowColor = System.Drawing.Color.Aqua;
            this.btnPreview.ImageSize = new System.Drawing.Size(24, 24);
            this.btnPreview.Location = new System.Drawing.Point(531, 384);
            this.btnPreview.MouseBack = null;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.NormlBack = null;
            this.btnPreview.Radius = 10;
            this.btnPreview.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnPreview.Size = new System.Drawing.Size(229, 40);
            this.btnPreview.TabIndex = 21;
            this.btnPreview.Text = "预览位置";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.but_yulan_Click);
            // 
            // btnResetCoordinates
            // 
            this.btnResetCoordinates.BackColor = System.Drawing.Color.Transparent;
            this.btnResetCoordinates.BaseColor = System.Drawing.Color.Transparent;
            this.btnResetCoordinates.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnResetCoordinates.DownBack = null;
            this.btnResetCoordinates.GlowColor = System.Drawing.Color.Aqua;
            this.btnResetCoordinates.ImageSize = new System.Drawing.Size(24, 24);
            this.btnResetCoordinates.Location = new System.Drawing.Point(531, 444);
            this.btnResetCoordinates.MouseBack = null;
            this.btnResetCoordinates.Name = "btnResetCoordinates";
            this.btnResetCoordinates.NormlBack = null;
            this.btnResetCoordinates.Radius = 10;
            this.btnResetCoordinates.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnResetCoordinates.Size = new System.Drawing.Size(229, 40);
            this.btnResetCoordinates.TabIndex = 22;
            this.btnResetCoordinates.Text = "reset coordinates";
            this.btnResetCoordinates.UseVisualStyleBackColor = false;
            this.btnResetCoordinates.Click += new System.EventHandler(this.but_chongzhi_Click);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.BackColor = System.Drawing.Color.Transparent;
            this.widthLabel.BorderColor = System.Drawing.Color.White;
            this.widthLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.widthLabel.Location = new System.Drawing.Point(528, 503);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 17);
            this.widthLabel.TabIndex = 29;
            this.widthLabel.Text = "宽度:";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.BackColor = System.Drawing.Color.Transparent;
            this.heightLabel.BorderColor = System.Drawing.Color.White;
            this.heightLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.heightLabel.Location = new System.Drawing.Point(651, 503);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(35, 17);
            this.heightLabel.TabIndex = 30;
            this.heightLabel.Text = "高度:";
            // 
            // mmInchLabel1
            // 
            this.mmInchLabel1.AutoSize = true;
            this.mmInchLabel1.BackColor = System.Drawing.Color.Transparent;
            this.mmInchLabel1.BorderColor = System.Drawing.Color.White;
            this.mmInchLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mmInchLabel1.Location = new System.Drawing.Point(614, 502);
            this.mmInchLabel1.Name = "mmInchLabel1";
            this.mmInchLabel1.Size = new System.Drawing.Size(30, 17);
            this.mmInchLabel1.TabIndex = 31;
            this.mmInchLabel1.Text = "mm";
            // 
            // mmInchLabel2
            // 
            this.mmInchLabel2.AutoSize = true;
            this.mmInchLabel2.BackColor = System.Drawing.Color.Transparent;
            this.mmInchLabel2.BorderColor = System.Drawing.Color.White;
            this.mmInchLabel2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mmInchLabel2.Location = new System.Drawing.Point(736, 505);
            this.mmInchLabel2.Name = "mmInchLabel2";
            this.mmInchLabel2.Size = new System.Drawing.Size(30, 17);
            this.mmInchLabel2.TabIndex = 32;
            this.mmInchLabel2.Text = "mm";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.BaseColor = System.Drawing.Color.Transparent;
            this.btn_save.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_save.DownBack = null;
            this.btn_save.GlowColor = System.Drawing.Color.Aqua;
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.ImageSize = new System.Drawing.Size(24, 24);
            this.btn_save.Location = new System.Drawing.Point(349, 31);
            this.btn_save.MouseBack = null;
            this.btn_save.Name = "btn_save";
            this.btn_save.NormlBack = null;
            this.btn_save.Radius = 10;
            this.btn_save.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btn_save.Size = new System.Drawing.Size(40, 40);
            this.btn_save.TabIndex = 33;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.but_baocun_Click);
            // 
            // com
            // 
            this.com.BaudRate = 115200;
            this.com.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.com_DataReceived);
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skinPanel2.BackgroundImage")));
            this.skinPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skinPanel2.Controls.Add(this.LED);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(701, 36);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(33, 32);
            this.skinPanel2.TabIndex = 34;
            // 
            // LED
            // 
            this.LED.BackColor = System.Drawing.Color.Transparent;
            this.LED.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LED.BackgroundImage")));
            this.LED.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LED.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.LED.DownBack = null;
            this.LED.Location = new System.Drawing.Point(0, 0);
            this.LED.MouseBack = null;
            this.LED.Name = "LED";
            this.LED.NormlBack = null;
            this.LED.Size = new System.Drawing.Size(33, 32);
            this.LED.TabIndex = 79;
            this.LED.Visible = false;
            // 
            // bmpFileDialog
            // 
            this.bmpFileDialog.FileName = "openFileDialog1";
            // 
            // ding_cl
            // 
            this.ding_cl.Interval = 1000;
            this.ding_cl.Tick += new System.EventHandler(this.ding_cl_Tick);
            // 
            // txtBoxWidth
            // 
            this.txtBoxWidth.Location = new System.Drawing.Point(569, 500);
            this.txtBoxWidth.Name = "txtBoxWidth";
            this.txtBoxWidth.Size = new System.Drawing.Size(39, 20);
            this.txtBoxWidth.TabIndex = 36;
            this.txtBoxWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_kuan_KeyPress);
            this.txtBoxWidth.Leave += new System.EventHandler(this.text_kuan_Leave);
            // 
            // txtBoxHeight
            // 
            this.txtBoxHeight.Location = new System.Drawing.Point(692, 500);
            this.txtBoxHeight.Name = "txtBoxHeight";
            this.txtBoxHeight.Size = new System.Drawing.Size(42, 20);
            this.txtBoxHeight.TabIndex = 37;
            this.txtBoxHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_gao_KeyPress);
            this.txtBoxHeight.Leave += new System.EventHandler(this.text_gao_Leave);
            // 
            // but_tuoji
            // 
            this.but_tuoji.BackColor = System.Drawing.Color.Transparent;
            this.but_tuoji.BaseColor = System.Drawing.Color.Transparent;
            this.but_tuoji.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.but_tuoji.DownBack = null;
            this.but_tuoji.GlowColor = System.Drawing.Color.Aqua;
            this.but_tuoji.Image = ((System.Drawing.Image)(resources.GetObject("but_tuoji.Image")));
            this.but_tuoji.ImageSize = new System.Drawing.Size(24, 24);
            this.but_tuoji.Location = new System.Drawing.Point(463, 31);
            this.but_tuoji.MouseBack = null;
            this.but_tuoji.Name = "but_tuoji";
            this.but_tuoji.NormlBack = null;
            this.but_tuoji.Radius = 10;
            this.but_tuoji.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.but_tuoji.Size = new System.Drawing.Size(40, 40);
            this.but_tuoji.TabIndex = 79;
            this.but_tuoji.UseVisualStyleBackColor = false;
            this.but_tuoji.Click += new System.EventHandler(this.but_tuoji_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BaseColor = System.Drawing.Color.Transparent;
            this.btnSettings.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSettings.DownBack = null;
            this.btnSettings.GlowColor = System.Drawing.Color.Aqua;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSettings.Location = new System.Drawing.Point(406, 31);
            this.btnSettings.MouseBack = null;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.NormlBack = null;
            this.btnSettings.Radius = 10;
            this.btnSettings.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSettings.Size = new System.Drawing.Size(40, 40);
            this.btnSettings.TabIndex = 80;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chineseToolStripMenuItem,
            this.englishToolStripMenuItem,
            this.japaneseToolStripMenuItem,
            this.setUpToolStripMenuItem,
            this.skinToolStripMenuItem,
            this.BMPToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(186, 136);
            // 
            // chineseToolStripMenuItem
            // 
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            this.chineseToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.chineseToolStripMenuItem.Text = "Chinese";
            this.chineseToolStripMenuItem.Click += new System.EventHandler(this.中文ToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // japaneseToolStripMenuItem
            // 
            this.japaneseToolStripMenuItem.Name = "japaneseToolStripMenuItem";
            this.japaneseToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.japaneseToolStripMenuItem.Text = "日本語";
            this.japaneseToolStripMenuItem.Click += new System.EventHandler(this.japaneseToolStripMenuItem_Click);
            // 
            // setUpToolStripMenuItem
            // 
            this.setUpToolStripMenuItem.Name = "setUpToolStripMenuItem";
            this.setUpToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.setUpToolStripMenuItem.Text = "设置";
            this.setUpToolStripMenuItem.Click += new System.EventHandler(this.SetUpToolStripMenuItem_Click);
            // 
            // skinToolStripMenuItem
            // 
            this.skinToolStripMenuItem.Name = "skinToolStripMenuItem";
            this.skinToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.skinToolStripMenuItem.Text = "皮肤";
            this.skinToolStripMenuItem.Click += new System.EventHandler(this.SkinToolStripMenuItem_Click);
            // 
            // BMPToolStripMenuItem
            // 
            this.BMPToolStripMenuItem.Name = "BMPToolStripMenuItem";
            this.BMPToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.BMPToolStripMenuItem.Text = "批量转换到BMP格式";
            this.BMPToolStripMenuItem.Click += new System.EventHandler(this.批量转换到BMP格式ToolStripMenuItem_Click);
            // 
            // pi_fu
            // 
            this.pi_fu.FileName = "openFileDialog1";
            this.pi_fu.Filter = "Pictures|*.BMP;*.jpg;*.png";
            // 
            // lockAspectRatioChkBox
            // 
            this.lockAspectRatioChkBox.AutoSize = true;
            this.lockAspectRatioChkBox.BackColor = System.Drawing.Color.Transparent;
            this.lockAspectRatioChkBox.Checked = true;
            this.lockAspectRatioChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lockAspectRatioChkBox.Location = new System.Drawing.Point(531, 527);
            this.lockAspectRatioChkBox.Name = "lockAspectRatioChkBox";
            this.lockAspectRatioChkBox.Size = new System.Drawing.Size(74, 17);
            this.lockAspectRatioChkBox.TabIndex = 81;
            this.lockAspectRatioChkBox.Text = "锁定比例";
            this.lockAspectRatioChkBox.UseVisualStyleBackColor = false;
            this.lockAspectRatioChkBox.CheckedChanged += new System.EventHandler(this.kg_bi_suoding_CheckedChanged);
            // 
            // elapsedTimeLbl
            // 
            this.elapsedTimeLbl.BackColor = System.Drawing.Color.Transparent;
            this.elapsedTimeLbl.BorderColor = System.Drawing.Color.White;
            this.elapsedTimeLbl.Font = new System.Drawing.Font("Microsoft YaHei", 16F);
            this.elapsedTimeLbl.Location = new System.Drawing.Point(531, 558);
            this.elapsedTimeLbl.Name = "elapsedTimeLbl";
            this.elapsedTimeLbl.Size = new System.Drawing.Size(230, 23);
            this.elapsedTimeLbl.TabIndex = 82;
            this.elapsedTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // elapsedTimeTimer
            // 
            this.elapsedTimeTimer.Interval = 1000;
            this.elapsedTimeTimer.Tick += new System.EventHandler(this.elapsedTimeTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 8F);
            this.label1.Location = new System.Drawing.Point(4, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 11);
            this.label1.TabIndex = 83;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 8F);
            this.label2.Location = new System.Drawing.Point(66, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 11);
            this.label2.TabIndex = 84;
            this.label2.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 8F);
            this.label3.Location = new System.Drawing.Point(128, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 11);
            this.label3.TabIndex = 85;
            this.label3.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 8F);
            this.label4.Location = new System.Drawing.Point(190, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 11);
            this.label4.TabIndex = 86;
            this.label4.Text = "30";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 8F);
            this.label5.Location = new System.Drawing.Point(252, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 11);
            this.label5.TabIndex = 87;
            this.label5.Text = "40";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 8F);
            this.label6.Location = new System.Drawing.Point(314, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 11);
            this.label6.TabIndex = 88;
            this.label6.Text = "50";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 8F);
            this.label7.Location = new System.Drawing.Point(376, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 11);
            this.label7.TabIndex = 89;
            this.label7.Text = "60";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 8F);
            this.label8.Location = new System.Drawing.Point(438, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 11);
            this.label8.TabIndex = 90;
            this.label8.Text = "70";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SimSun", 8F);
            this.label9.Location = new System.Drawing.Point(500, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 11);
            this.label9.TabIndex = 91;
            this.label9.Text = "80";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimSun", 8F);
            this.label10.Location = new System.Drawing.Point(511, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 11);
            this.label10.TabIndex = 92;
            this.label10.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("SimSun", 8F);
            this.label11.Location = new System.Drawing.Point(511, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 11);
            this.label11.TabIndex = 93;
            this.label11.Text = "10";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("SimSun", 8F);
            this.label12.Location = new System.Drawing.Point(511, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 11);
            this.label12.TabIndex = 94;
            this.label12.Text = "20";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("SimSun", 8F);
            this.label13.Location = new System.Drawing.Point(511, 270);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 11);
            this.label13.TabIndex = 95;
            this.label13.Text = "30";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("SimSun", 8F);
            this.label14.Location = new System.Drawing.Point(511, 332);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 11);
            this.label14.TabIndex = 96;
            this.label14.Text = "40";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("SimSun", 8F);
            this.label15.Location = new System.Drawing.Point(511, 394);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 11);
            this.label15.TabIndex = 97;
            this.label15.Text = "50";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("SimSun", 8F);
            this.label18.Location = new System.Drawing.Point(511, 456);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 11);
            this.label18.TabIndex = 98;
            this.label18.Text = "60";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("SimSun", 8F);
            this.label19.Location = new System.Drawing.Point(511, 518);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 11);
            this.label19.TabIndex = 99;
            this.label19.Text = "70";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("SimSun", 8F);
            this.label20.Location = new System.Drawing.Point(511, 580);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 11);
            this.label20.TabIndex = 100;
            this.label20.Text = "80";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.BackLayout = false;
            this.BorderColor = System.Drawing.Color.DarkGray;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(775, 598);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elapsedTimeLbl);
            this.Controls.Add(this.lockAspectRatioChkBox);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.but_tuoji);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.txtBoxHeight);
            this.Controls.Add(this.txtBoxWidth);
            this.Controls.Add(this.skinPanel2);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.mmInchLabel2);
            this.Controls.Add(this.mmInchLabel1);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.btnResetCoordinates);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.skinLabel5);
            this.Controls.Add(this.skinLabel4);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.tiao_shendu);
            this.Controls.Add(this.tiao_gonglv);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.pictureProcessingDropDownMenu);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btnOpenPicture);
            this.Controls.Add(this.btn_disconnectConnectDevice);
            this.Controls.Add(this.btn_mmToInch);
            this.Controls.Add(this.btnAddText);
            this.Controls.Add(this.but_trash);
            this.Controls.Add(this.but_fanse);
            this.Controls.Add(this.btnRotate);
            this.Controls.Add(this.btnFlip);
            this.Controls.Add(this.change_half);
            this.DropBack = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Laser Engraving Machine";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form1_DragOver);
            this.change_half.ResumeLayout(false);
            this.change_half.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hua_ban)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiao_gonglv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiao_shendu)).EndInit();
            this.skinPanel2.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public delegate void MyInvoke();

        private struct Dian
        {
            public int x;
            public int y;

            public Dian(int xx, int yy)
            {
                x = xx;
                y = yy;
            }
        }

        private struct Xian
        {
            public Dian q;
            public Dian zh;
        }

        public enum HardwareEnum
        {
            Win32_Processor,
            Win32_PhysicalMemory,
            Win32_Keyboard,
            Win32_PointingDevice,
            Win32_FloppyDrive,
            Win32_DiskDrive,
            Win32_CDROMDrive,
            Win32_BaseBoard,
            Win32_BIOS,
            Win32_ParallelPort,
            Win32_SerialPort,
            Win32_SerialPortConfiguration,
            Win32_SoundDevice,
            Win32_SystemSlot,
            Win32_USBController,
            Win32_NetworkAdapter,
            Win32_NetworkAdapterConfiguration,
            Win32_Printer,
            Win32_PrinterConfiguration,
            Win32_PrintJob,
            Win32_TCPIPPrinterPort,
            Win32_POTSModem,
            Win32_POTSModemToSerialPort,
            Win32_DesktopMonitor,
            Win32_DisplayConfiguration,
            Win32_DisplayControllerConfiguration,
            Win32_VideoController,
            Win32_VideoSettings,
            Win32_TimeZone,
            Win32_SystemDriver,
            Win32_DiskPartition,
            Win32_LogicalDisk,
            Win32_LogicalDiskToPartition,
            Win32_LogicalMemoryConfiguration,
            Win32_PageFile,
            Win32_PageFileSetting,
            Win32_BootConfiguration,
            Win32_ComputerSystem,
            Win32_OperatingSystem,
            Win32_StartupCommand,
            Win32_Service,
            Win32_Group,
            Win32_GroupUser,
            Win32_UserAccount,
            Win32_Process,
            Win32_Thread,
            Win32_Share,
            Win32_NetworkClient,
            Win32_NetworkProtocol,
            Win32_PnPEntity,
        }
    }
}
