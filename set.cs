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

    //Textbox and label 1 - 10 seems to be unsused? Not visible at least.
    private TextBox textBox10;
    private Label previewSpeedLbl;
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
    private Label laserIntensityLbl;
    private Button saveBtn;
    private TextBox modelTxtBox;
    private Label modelLbl;
    private Button idleLaserMinusBtn;
    private Button idleLaserPlusBtn;
    private TextBox idleLaserValueTxtBox;
    private TextBox previewSpeedValueTxtBox;
    private Button previewSpeedPlusBtn;
    private Button previewSpeedMinusBtn;

    public set()
    {
      InitializeComponent();
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
      previewSpeedValueTxtBox.Text = kuang_sd_.ToString();
      modelTxtBox.Text = xh;
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      Form1.m_Form1.writeSettings(Convert.ToByte(this.textBox1.Text), (int) Convert.ToInt16(this.textBox2.Text), (int) Convert.ToInt16(this.textBox3.Text), Convert.ToByte(this.textBox4.Text), Convert.ToByte(this.textBox5.Text), Convert.ToByte(this.textBox6.Text), (int) Convert.ToInt16(this.textBox7.Text), (int) Convert.ToInt16(this.textBox8.Text), (int) Convert.ToInt16(this.textBox9.Text), (int) Convert.ToInt16(this.textBox10.Text), this.modelTxtBox.Text);
      Close();
    }

    private void previewSpeedMinus_Click(object sender, EventArgs e)
    {
      int int32 = Convert.ToInt32(this.previewSpeedValueTxtBox.Text);
      if (int32 > 1)
      {
        int num = int32 - 1;
        this.previewSpeedValueTxtBox.Text = num.ToString();
        this.textBox10.Text = num.ToString();
      }
      Form1.m_Form1.writeSettings(Convert.ToByte(this.textBox1.Text), (int) Convert.ToInt16(this.textBox2.Text), (int) Convert.ToInt16(this.textBox3.Text), Convert.ToByte(this.textBox4.Text), Convert.ToByte(this.textBox5.Text), Convert.ToByte(this.textBox6.Text), (int) Convert.ToInt16(this.textBox7.Text), (int) Convert.ToInt16(this.textBox8.Text), (int) Convert.ToInt16(this.textBox9.Text), (int) Convert.ToInt16(this.textBox10.Text), this.modelTxtBox.Text);
    }

    private void previewSpeedPlus_Click(object sender, EventArgs e)
    {
      int int32 = Convert.ToInt32(this.previewSpeedValueTxtBox.Text);
      if (int32 < 10)
      {
        int num = int32 + 1;
        this.previewSpeedValueTxtBox.Text = num.ToString();
        this.textBox10.Text = num.ToString();
      }
      Form1.m_Form1.writeSettings(Convert.ToByte(this.textBox1.Text), (int) Convert.ToInt16(this.textBox2.Text), (int) Convert.ToInt16(this.textBox3.Text), Convert.ToByte(this.textBox4.Text), Convert.ToByte(this.textBox5.Text), Convert.ToByte(this.textBox6.Text), (int) Convert.ToInt16(this.textBox7.Text), (int) Convert.ToInt16(this.textBox8.Text), (int) Convert.ToInt16(this.textBox9.Text), (int) Convert.ToInt16(this.textBox10.Text), this.modelTxtBox.Text);
    }

    private void idleLaserIntensityMinus_Click(object sender, EventArgs e)
    {
      int int32 = Convert.ToInt32(this.idleLaserValueTxtBox.Text);
      if (int32 > 1)
      {
        int num = int32 - 1;
        this.idleLaserValueTxtBox.Text = num.ToString();
        this.textBox1.Text = ((int) (50.0 + (double) (150 * num) * 0.1)).ToString();
      }
      Form1.m_Form1.writeSettings(Convert.ToByte(this.textBox1.Text), (int) Convert.ToInt16(this.textBox2.Text), (int) Convert.ToInt16(this.textBox3.Text), Convert.ToByte(this.textBox4.Text), Convert.ToByte(this.textBox5.Text), Convert.ToByte(this.textBox6.Text), (int) Convert.ToInt16(this.textBox7.Text), (int) Convert.ToInt16(this.textBox8.Text), (int) Convert.ToInt16(this.textBox9.Text), (int) Convert.ToInt16(this.textBox10.Text), this.modelTxtBox.Text);
    }

    private void idleLaserIntensityPlus_Click(object sender, EventArgs e)
    {
      int int32 = Convert.ToInt32(this.idleLaserValueTxtBox.Text);
      if (int32 < 10)
      {
        int num = int32 + 1;
        this.idleLaserValueTxtBox.Text = num.ToString();
        this.textBox1.Text = ((int) (50.0 + (double) (150 * num) * 0.1)).ToString();
      }
      Form1.m_Form1.writeSettings(Convert.ToByte(this.textBox1.Text), (int) Convert.ToInt16(this.textBox2.Text), (int) Convert.ToInt16(this.textBox3.Text), Convert.ToByte(this.textBox4.Text), Convert.ToByte(this.textBox5.Text), Convert.ToByte(this.textBox6.Text), (int) Convert.ToInt16(this.textBox7.Text), (int) Convert.ToInt16(this.textBox8.Text), (int) Convert.ToInt16(this.textBox9.Text), (int) Convert.ToInt16(this.textBox10.Text), this.modelTxtBox.Text);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.previewSpeedLbl = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.laserIntensityLbl = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.modelTxtBox = new System.Windows.Forms.TextBox();
            this.modelLbl = new System.Windows.Forms.Label();
            this.idleLaserMinusBtn = new System.Windows.Forms.Button();
            this.idleLaserPlusBtn = new System.Windows.Forms.Button();
            this.idleLaserValueTxtBox = new System.Windows.Forms.TextBox();
            this.previewSpeedValueTxtBox = new System.Windows.Forms.TextBox();
            this.previewSpeedPlusBtn = new System.Windows.Forms.Button();
            this.previewSpeedMinusBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(362, 72);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(41, 20);
            this.textBox10.TabIndex = 41;
            this.textBox10.Text = "5";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // previewSpeedLbl
            // 
            this.previewSpeedLbl.AutoSize = true;
            this.previewSpeedLbl.Location = new System.Drawing.Point(40, 74);
            this.previewSpeedLbl.Name = "previewSpeedLbl";
            this.previewSpeedLbl.Size = new System.Drawing.Size(82, 13);
            this.previewSpeedLbl.TabIndex = 40;
            this.previewSpeedLbl.Text = "Preview Speed:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(866, 218);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(156, 20);
            this.textBox9.TabIndex = 39;
            this.textBox9.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(710, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "速度上限:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(866, 191);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(156, 20);
            this.textBox8.TabIndex = 37;
            this.textBox8.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(710, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "速度下限:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(866, 164);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(156, 20);
            this.textBox7.TabIndex = 35;
            this.textBox7.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(710, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "变速阶梯数:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(872, 332);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(156, 20);
            this.textBox6.TabIndex = 33;
            this.textBox6.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(716, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Y轴换向补偿:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(872, 305);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(156, 20);
            this.textBox5.TabIndex = 31;
            this.textBox5.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(716, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "X轴换向补偿:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(866, 85);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(156, 20);
            this.textBox4.TabIndex = 29;
            this.textBox4.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(710, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "细分数:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(866, 58);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(156, 20);
            this.textBox3.TabIndex = 27;
            this.textBox3.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(710, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "最大激光功率:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(866, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 20);
            this.textBox2.TabIndex = 25;
            this.textBox2.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(710, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "行延时:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(362, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(41, 20);
            this.textBox1.TabIndex = 23;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // laserIntensityLbl
            // 
            this.laserIntensityLbl.AutoSize = true;
            this.laserIntensityLbl.Location = new System.Drawing.Point(40, 40);
            this.laserIntensityLbl.Name = "laserIntensityLbl";
            this.laserIntensityLbl.Size = new System.Drawing.Size(98, 13);
            this.laserIntensityLbl.TabIndex = 22;
            this.laserIntensityLbl.Text = "Idle Laser Intensity:";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(165, 145);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(117, 37);
            this.saveBtn.TabIndex = 21;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // modelTxtBox
            // 
            this.modelTxtBox.Enabled = false;
            this.modelTxtBox.Location = new System.Drawing.Point(185, 103);
            this.modelTxtBox.Name = "modelTxtBox";
            this.modelTxtBox.Size = new System.Drawing.Size(97, 20);
            this.modelTxtBox.TabIndex = 43;
            this.modelTxtBox.Text = "k";
            // 
            // modelLbl
            // 
            this.modelLbl.AutoSize = true;
            this.modelLbl.Location = new System.Drawing.Point(40, 106);
            this.modelLbl.Name = "modelLbl";
            this.modelLbl.Size = new System.Drawing.Size(39, 13);
            this.modelLbl.TabIndex = 42;
            this.modelLbl.Text = "Model:";
            // 
            // idleLaserMinusBtn
            // 
            this.idleLaserMinusBtn.Location = new System.Drawing.Point(185, 35);
            this.idleLaserMinusBtn.Name = "idleLaserMinusBtn";
            this.idleLaserMinusBtn.Size = new System.Drawing.Size(26, 22);
            this.idleLaserMinusBtn.TabIndex = 44;
            this.idleLaserMinusBtn.Text = "-";
            this.idleLaserMinusBtn.UseVisualStyleBackColor = true;
            this.idleLaserMinusBtn.Click += new System.EventHandler(this.idleLaserIntensityMinus_Click);
            // 
            // idleLaserPlusBtn
            // 
            this.idleLaserPlusBtn.Location = new System.Drawing.Point(258, 35);
            this.idleLaserPlusBtn.Name = "idleLaserPlusBtn";
            this.idleLaserPlusBtn.Size = new System.Drawing.Size(24, 22);
            this.idleLaserPlusBtn.TabIndex = 45;
            this.idleLaserPlusBtn.Text = "+";
            this.idleLaserPlusBtn.UseVisualStyleBackColor = true;
            this.idleLaserPlusBtn.Click += new System.EventHandler(this.idleLaserIntensityPlus_Click);
            // 
            // idleLaserValueTxtBox
            // 
            this.idleLaserValueTxtBox.Location = new System.Drawing.Point(214, 35);
            this.idleLaserValueTxtBox.Name = "idleLaserValueTxtBox";
            this.idleLaserValueTxtBox.Size = new System.Drawing.Size(41, 20);
            this.idleLaserValueTxtBox.TabIndex = 46;
            this.idleLaserValueTxtBox.Text = "5";
            this.idleLaserValueTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // previewSpeedValueTxtBox
            // 
            this.previewSpeedValueTxtBox.Location = new System.Drawing.Point(214, 70);
            this.previewSpeedValueTxtBox.Name = "previewSpeedValueTxtBox";
            this.previewSpeedValueTxtBox.Size = new System.Drawing.Size(41, 20);
            this.previewSpeedValueTxtBox.TabIndex = 49;
            this.previewSpeedValueTxtBox.Text = "5";
            this.previewSpeedValueTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // previewSpeedPlusBtn
            // 
            this.previewSpeedPlusBtn.Location = new System.Drawing.Point(258, 70);
            this.previewSpeedPlusBtn.Name = "previewSpeedPlusBtn";
            this.previewSpeedPlusBtn.Size = new System.Drawing.Size(24, 22);
            this.previewSpeedPlusBtn.TabIndex = 48;
            this.previewSpeedPlusBtn.Text = "+";
            this.previewSpeedPlusBtn.UseVisualStyleBackColor = true;
            this.previewSpeedPlusBtn.Click += new System.EventHandler(this.previewSpeedPlus_Click);
            // 
            // previewSpeedMinusBtn
            // 
            this.previewSpeedMinusBtn.Location = new System.Drawing.Point(185, 70);
            this.previewSpeedMinusBtn.Name = "previewSpeedMinusBtn";
            this.previewSpeedMinusBtn.Size = new System.Drawing.Size(26, 22);
            this.previewSpeedMinusBtn.TabIndex = 47;
            this.previewSpeedMinusBtn.Text = "-";
            this.previewSpeedMinusBtn.UseVisualStyleBackColor = true;
            this.previewSpeedMinusBtn.Click += new System.EventHandler(this.previewSpeedMinus_Click);
            // 
            // set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 194);
            this.Controls.Add(this.previewSpeedValueTxtBox);
            this.Controls.Add(this.previewSpeedPlusBtn);
            this.Controls.Add(this.previewSpeedMinusBtn);
            this.Controls.Add(this.idleLaserValueTxtBox);
            this.Controls.Add(this.idleLaserPlusBtn);
            this.Controls.Add(this.idleLaserMinusBtn);
            this.Controls.Add(this.modelTxtBox);
            this.Controls.Add(this.modelLbl);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.previewSpeedLbl);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.laserIntensityLbl);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "set";
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
