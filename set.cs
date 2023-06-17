// Decompiled with JetBrains decompiler
// Type: diao.set
// Assembly: diao, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9B9CD16-F024-45F9-8D13-D1172328D6F7
// Assembly location: F:\engraver\LaserEngraver\Laser Framework4.exe

using CCWin;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace diao
{
  public class set : CCSkinMain
  {
    private SerialPort com = new SerialPort();
    private object fanhui = (object) false;
    public static set m_formA;
    private IContainer components;
    private TextBox textBox10;
    private Label label10;
    private TextBox textBox9;
    private Label label9;
    private TextBox textBox8;
    private Label label8;
    private TextBox textBox7;
    private Label label7;
    private TextBox textBox6;
    private Label label6;
    private TextBox textBox5;
    private Label label5;
    private TextBox textBox4;
    private Label label4;
    private TextBox textBox3;
    private Label label3;
    private TextBox textBox2;
    private Label label2;
    private TextBox textBox1;
    private Label label1;
    private Button button1;
    private TextBox textBox11;
    private Label label11;
    private Button but_jian_ruo;
    private Button but_jia_ruo;
    private TextBox textBox12;
    private TextBox textBox13;
    private Button but_jia_kuang;
    private Button but_jian_kuang;

    public set()
    {
      this.InitializeComponent();
      m_formA = this;
    }

    public void zhi(
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
      textBox1.Text = ruo_.ToString();
      textBox2.Text = hang_yan_shi_.ToString();
      textBox3.Text = TIM_chong_zhuang_zhi_.ToString();
      textBox4.Text = BU_.ToString();
      textBox5.Text = x_buchang_.ToString();
      textBox6.Text = y_buchang_.ToString();
      textBox7.Text = SS_.ToString();
      textBox8.Text = MM1_.ToString();
      textBox9.Text = KUAI_.ToString();
      textBox10.Text = kuang_sd_.ToString();
      textBox13.Text = kuang_sd_.ToString();
      textBox11.Text = xh;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Form1.m_Form1.she_zhi(Convert.ToByte(this.textBox1.Text), (int) Convert.ToInt16(this.textBox2.Text), (int) Convert.ToInt16(this.textBox3.Text), Convert.ToByte(this.textBox4.Text), Convert.ToByte(this.textBox5.Text), Convert.ToByte(this.textBox6.Text), (int) Convert.ToInt16(this.textBox7.Text), (int) Convert.ToInt16(this.textBox8.Text), (int) Convert.ToInt16(this.textBox9.Text), (int) Convert.ToInt16(this.textBox10.Text), this.textBox11.Text);
      this.Close();
    }

    private void set_Load(object sender, EventArgs e)
    {
    }

    private void but_jian_kuang_Click(object sender, EventArgs e)
    {
      int int32 = Convert.ToInt32(this.textBox13.Text);
      if (int32 > 1)
      {
        int num = int32 - 1;
        this.textBox13.Text = num.ToString();
        this.textBox10.Text = num.ToString();
      }
      Form1.m_Form1.she_zhi(Convert.ToByte(this.textBox1.Text), (int) Convert.ToInt16(this.textBox2.Text), (int) Convert.ToInt16(this.textBox3.Text), Convert.ToByte(this.textBox4.Text), Convert.ToByte(this.textBox5.Text), Convert.ToByte(this.textBox6.Text), (int) Convert.ToInt16(this.textBox7.Text), (int) Convert.ToInt16(this.textBox8.Text), (int) Convert.ToInt16(this.textBox9.Text), (int) Convert.ToInt16(this.textBox10.Text), this.textBox11.Text);
    }

    private void but_jia_kuang_Click(object sender, EventArgs e)
    {
      int int32 = Convert.ToInt32(this.textBox13.Text);
      if (int32 < 10)
      {
        int num = int32 + 1;
        this.textBox13.Text = num.ToString();
        this.textBox10.Text = num.ToString();
      }
      Form1.m_Form1.she_zhi(Convert.ToByte(this.textBox1.Text), (int) Convert.ToInt16(this.textBox2.Text), (int) Convert.ToInt16(this.textBox3.Text), Convert.ToByte(this.textBox4.Text), Convert.ToByte(this.textBox5.Text), Convert.ToByte(this.textBox6.Text), (int) Convert.ToInt16(this.textBox7.Text), (int) Convert.ToInt16(this.textBox8.Text), (int) Convert.ToInt16(this.textBox9.Text), (int) Convert.ToInt16(this.textBox10.Text), this.textBox11.Text);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      int int32 = Convert.ToInt32(this.textBox12.Text);
      if (int32 > 1)
      {
        int num = int32 - 1;
        this.textBox12.Text = num.ToString();
        this.textBox1.Text = ((int) (50.0 + (double) (150 * num) * 0.1)).ToString();
      }
      Form1.m_Form1.she_zhi(Convert.ToByte(this.textBox1.Text), (int) Convert.ToInt16(this.textBox2.Text), (int) Convert.ToInt16(this.textBox3.Text), Convert.ToByte(this.textBox4.Text), Convert.ToByte(this.textBox5.Text), Convert.ToByte(this.textBox6.Text), (int) Convert.ToInt16(this.textBox7.Text), (int) Convert.ToInt16(this.textBox8.Text), (int) Convert.ToInt16(this.textBox9.Text), (int) Convert.ToInt16(this.textBox10.Text), this.textBox11.Text);
    }

    private void but_jia_ruo_Click(object sender, EventArgs e)
    {
      int int32 = Convert.ToInt32(this.textBox12.Text);
      if (int32 < 10)
      {
        int num = int32 + 1;
        this.textBox12.Text = num.ToString();
        this.textBox1.Text = ((int) (50.0 + (double) (150 * num) * 0.1)).ToString();
      }
      Form1.m_Form1.she_zhi(Convert.ToByte(this.textBox1.Text), (int) Convert.ToInt16(this.textBox2.Text), (int) Convert.ToInt16(this.textBox3.Text), Convert.ToByte(this.textBox4.Text), Convert.ToByte(this.textBox5.Text), Convert.ToByte(this.textBox6.Text), (int) Convert.ToInt16(this.textBox7.Text), (int) Convert.ToInt16(this.textBox8.Text), (int) Convert.ToInt16(this.textBox9.Text), (int) Convert.ToInt16(this.textBox10.Text), this.textBox11.Text);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager();
      textBox10 = new TextBox();
      label10 = new Label();
      textBox9 = new TextBox();
      label9 = new Label();
      textBox8 = new TextBox();
      label8 = new Label();
      textBox7 = new TextBox();
      label7 = new Label();
      textBox6 = new TextBox();
      label6 = new Label();
      textBox5 = new TextBox();
      label5 = new Label();
      textBox4 = new TextBox();
      label4 = new Label();
      textBox3 = new TextBox();
      label3 = new Label();
      textBox2 = new TextBox();
      label2 = new Label();
      textBox1 = new TextBox();
      label1 = new Label();
      button1 = new Button();
      textBox11 = new TextBox();
      label11 = new Label();
      but_jian_ruo = new Button();
      but_jia_ruo = new Button();
      textBox12 = new TextBox();
      textBox13 = new TextBox();
      but_jia_kuang = new Button();
      but_jian_kuang = new Button();
      SuspendLayout();
      textBox10.Location = new Point(362, 72);
      textBox10.Name = "textBox10";
      textBox10.Size = new Size(41, 21);
      textBox10.TabIndex = 41;
      textBox10.Text = "5";
      textBox10.TextAlign = HorizontalAlignment.Center;
      label10.AutoSize = true;
      label10.Location = new Point(40, 74);
      label10.Name = "label10";
      label10.Size = new Size(71, 12);
      label10.TabIndex = 40;
      label10.Text = "框定位速度:";
      textBox9.Location = new Point(866, 218);
      textBox9.Name = "textBox9";
      textBox9.Size = new Size(156, 21);
      textBox9.TabIndex = 39;
      textBox9.Text = "0";
      label9.AutoSize = true;
      label9.Location = new Point(710, 225);
      label9.Name = "label9";
      label9.Size = new Size(59, 12);
      label9.TabIndex = 38;
      label9.Text = "速度上限:";
      textBox8.Location = new Point(866, 191);
      textBox8.Name = "textBox8";
      textBox8.Size = new Size(156, 21);
      textBox8.TabIndex = 37;
      textBox8.Text = "0";
      label8.AutoSize = true;
      label8.Location = new Point(710, 198);
      label8.Name = "label8";
      label8.Size = new Size(59, 12);
      label8.TabIndex = 36;
      label8.Text = "速度下限:";
      textBox7.Location = new Point(866, 164);
      textBox7.Name = "textBox7";
      textBox7.Size = new Size(156, 21);
      textBox7.TabIndex = 35;
      textBox7.Text = "0";
      label7.AutoSize = true;
      label7.Location = new Point(710, 171);
      label7.Name = "label7";
      label7.Size = new Size(71, 12);
      label7.TabIndex = 34;
      label7.Text = "变速阶梯数:";
      textBox6.Location = new Point(872, 332);
      textBox6.Name = "textBox6";
      textBox6.Size = new Size(156, 21);
      textBox6.TabIndex = 33;
      textBox6.Text = "0";
      label6.AutoSize = true;
      label6.Location = new Point(716, 339);
      label6.Name = "label6";
      label6.Size = new Size(77, 12);
      label6.TabIndex = 32;
      label6.Text = "Y轴换向补偿:";
      textBox5.Location = new Point(872, 305);
      textBox5.Name = "textBox5";
      textBox5.Size = new Size(156, 21);
      textBox5.TabIndex = 31;
      textBox5.Text = "0";
      label5.AutoSize = true;
      label5.Location = new Point(716, 312);
      label5.Name = "label5";
      label5.Size = new Size(77, 12);
      label5.TabIndex = 30;
      label5.Text = "X轴换向补偿:";
      textBox4.Location = new Point(866, 85);
      textBox4.Name = "textBox4";
      textBox4.Size = new Size(156, 21);
      textBox4.TabIndex = 29;
      textBox4.Text = "0";
      label4.AutoSize = true;
      label4.Location = new Point(710, 92);
      label4.Name = "label4";
      label4.Size = new Size(47, 12);
      label4.TabIndex = 28;
      label4.Text = "细分数:";
      textBox3.Location = new Point(866, 58);
      textBox3.Name = "textBox3";
      textBox3.Size = new Size(156, 21);
      textBox3.TabIndex = 27;
      textBox3.Text = "0";
      label3.AutoSize = true;
      label3.Location = new Point(710, 65);
      label3.Name = "label3";
      label3.Size = new Size(83, 12);
      label3.TabIndex = 26;
      label3.Text = "最大激光功率:";
      textBox2.Location = new Point(866, 31);
      textBox2.Name = "textBox2";
      textBox2.Size = new Size(156, 21);
      textBox2.TabIndex = 25;
      textBox2.Text = "0";
      label2.AutoSize = true;
      label2.Location = new Point(710, 38);
      label2.Name = "label2";
      label2.Size = new Size(47, 12);
      label2.TabIndex = 24;
      label2.Text = "行延时:";
      textBox1.Location = new Point(362, 35);
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(41, 21);
      textBox1.TabIndex = 23;
      textBox1.Text = "0";
      textBox1.TextAlign = HorizontalAlignment.Center;
      label1.AutoSize = true;
      label1.Location = new Point(40, 40);
      label1.Name = "label1";
      label1.Size = new Size(83, 12);
      label1.TabIndex = 22;
      label1.Text = "待机激光强度:";
      button1.Location = new Point(165, 145);
      button1.Name = "button1";
      button1.Size = new Size(117, 37);
      button1.TabIndex = 21;
      button1.Text = "写入";
      button1.UseVisualStyleBackColor = true;
      button1.Click += new EventHandler(this.button1_Click);
      textBox11.Enabled = false;
      textBox11.Location = new Point(185, 103);
      textBox11.Name = "textBox11";
      textBox11.Size = new Size(97, 21);
      textBox11.TabIndex = 43;
      textBox11.Text = "k";
      label11.AutoSize = true;
      label11.Location = new Point(40, 106);
      label11.Name = "label11";
      label11.Size = new Size(35, 12);
      label11.TabIndex = 42;
      label11.Text = "型号:";
      but_jian_ruo.Location = new Point(185, 35);
      but_jian_ruo.Name = "but_jian_ruo";
      but_jian_ruo.Size = new Size(26, 22);
      but_jian_ruo.TabIndex = 44;
      but_jian_ruo.Text = "-";
      but_jian_ruo.UseVisualStyleBackColor = true;
      but_jian_ruo.Click += new EventHandler(this.button2_Click);
      but_jia_ruo.Location = new Point(258, 35);
      but_jia_ruo.Name = "but_jia_ruo";
      but_jia_ruo.Size = new Size(24, 22);
      but_jia_ruo.TabIndex = 45;
      but_jia_ruo.Text = "+";
      but_jia_ruo.UseVisualStyleBackColor = true;
      but_jia_ruo.Click += new EventHandler(this.but_jia_ruo_Click);
      textBox12.Location = new Point(214, 35);
      textBox12.Name = "textBox12";
      textBox12.Size = new Size(41, 21);
      textBox12.TabIndex = 46;
      textBox12.Text = "5";
      textBox12.TextAlign = HorizontalAlignment.Center;
      textBox13.Location = new Point(214, 70);
      textBox13.Name = "textBox13";
      textBox13.Size = new Size(41, 21);
      textBox13.TabIndex = 49;
      textBox13.Text = "5";
      textBox13.TextAlign = HorizontalAlignment.Center;
      but_jia_kuang.Location = new Point(258, 70);
      but_jia_kuang.Name = "but_jia_kuang";
      but_jia_kuang.Size = new Size(24, 22);
      but_jia_kuang.TabIndex = 48;
      but_jia_kuang.Text = "+";
      but_jia_kuang.UseVisualStyleBackColor = true;
      but_jia_kuang.Click += new EventHandler(this.but_jia_kuang_Click);
      but_jian_kuang.Location = new Point(185, 70);
      but_jian_kuang.Name = "but_jian_kuang";
      but_jian_kuang.Size = new Size(26, 22);
      but_jian_kuang.TabIndex = 47;
      but_jian_kuang.Text = "-";
      but_jian_kuang.UseVisualStyleBackColor = true;
      but_jian_kuang.Click += new EventHandler(this.but_jian_kuang_Click);
      AutoScaleDimensions = new SizeF(6f, 12f);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(323, 194);
      Controls.Add(textBox13);
      Controls.Add(but_jia_kuang);
      Controls.Add(but_jian_kuang);
      Controls.Add(textBox12);
      Controls.Add(but_jia_ruo);
      Controls.Add(but_jian_ruo);
      Controls.Add(textBox11);
      Controls.Add(label11);
      Controls.Add(textBox10);
      Controls.Add(label10);
      Controls.Add(textBox9);
      Controls.Add(label9);
      Controls.Add(textBox8);
      Controls.Add(label8);
      Controls.Add(textBox7);
      Controls.Add(label7);
      Controls.Add(textBox6);
      Controls.Add(label6);
      Controls.Add(textBox5);
      Controls.Add(label5);
      Controls.Add(textBox4);
      Controls.Add(label4);
      Controls.Add(textBox3);
      Controls.Add(label3);
      Controls.Add(textBox2);
      Controls.Add(label2);
      Controls.Add(textBox1);
      Controls.Add(label1);
      Controls.Add(button1);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Icon = (Icon) resources.GetObject("$this.Icon");
      Name = "set";
      Text = "";
      Load += new EventHandler(this.set_Load);
      ResumeLayout(false);
      PerformLayout();
    }
  }
}
