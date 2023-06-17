// Decompiled with JetBrains decompiler
// Type: diao.BsplineCurve
// Assembly: diao, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9B9CD16-F024-45F9-8D13-D1172328D6F7
// Assembly location: F:\engraver\LaserEngraver\Laser Framework4.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace diao
{
  internal class BsplineCurve
  {
    private int n;
    private int k;
    public BsplineType curve_type;
    private List<double> Bvalue = new List<double>();
    public List<double> knots_value = new List<double>();
    public List<int> knots_muti = new List<int>();
    public List<PointF> ControlPoint = new List<PointF>();
    public List<double> wlist = new List<double>();
    public List<PointF> CurvePoint = new List<PointF>();
    public List<List<PointF>> BasicFuncPoint = new List<List<PointF>>();

    public BsplineCurve()
    {
      this.n = 0;
      this.k = 0;
      this.curve_type = BsplineType.QuasiUniform;
    }

    public BsplineCurve(BsplineType type, int times, List<PointF> plist)
    {
      this.curve_type = type;
      this.k = times;
      this.n = plist.Count - 1;
      this.ControlPoint.AddRange((IEnumerable<PointF>) plist);
      for (int index = 0; index <= this.n; ++index)
        this.wlist.Add(1.0);
    }

    private void GenerateKnots()
    {
      switch (this.curve_type)
      {
        case BsplineType.Uniform:
          this.CreateKnots_Uniform();
          break;
        case BsplineType.QuasiUniform:
          this.CreateKnots_QuasiUniform();
          break;
        case BsplineType.PiecewiseBezier:
          this.CreateKnots_PiecewiseBezier();
          break;
        case BsplineType.NonUniform:
          this.CreateKnots_NonUniform();
          break;
        default:
          int num = (int) MessageBox.Show("节点矢量生成出错!!");
          break;
      }
    }

    private void CreateKnots_Uniform()
    {
      this.knots_muti.Clear();
      double num1 = 1.0 / (double) (this.n - this.k + 1);
      double num2 = (double) -this.k * num1;
      for (int index = 0; index <= this.n + this.k + 1; ++index)
      {
        this.knots_muti.Add(1);
        num2 += num1;
      }
    }

    private void CreateKnots_QuasiUniform()
    {
      this.knots_muti.Clear();
      this.knots_value.Clear();
      double num1 = 1.0 / (double) (this.n - this.k + 1);
      double num2 = 0.0;
      for (int index = 0; index <= this.n - this.k + 1; ++index)
      {
        this.knots_value.Add(num2);
        this.knots_muti.Add(1);
        num2 += num1;
      }
      this.knots_muti[0] = this.k + 1;
      this.knots_muti[this.n - this.k + 1] = this.k + 1;
    }

    private void CreateKnots_PiecewiseBezier()
    {
      this.knots_muti.Clear();
      this.knots_value.Clear();
      if (this.n % this.k == 0)
      {
        int num1 = this.n / this.k;
        double num2 = 1.0 / (double) num1;
        double num3 = 0.0;
        for (int index = 0; index <= num1; ++index)
        {
          this.knots_value.Add(num3);
          this.knots_muti.Add(this.k);
          num3 += num2;
        }
        List<int> knotsMuti1;
        (knotsMuti1 = this.knots_muti)[0] = knotsMuti1[0] + 1;
        List<int> knotsMuti2;
        int index1;
        (knotsMuti2 = this.knots_muti)[index1 = num1] = knotsMuti2[index1] + 1;
      }
      else
      {
        int num = (int) MessageBox.Show("n/k != 整数");
      }
    }

    private void CreateKnots_NonUniform()
    {
      this.knots_muti.Clear();
      this.knots_value.Clear();
      List<double> doubleList1 = new List<double>();
      List<double> doubleList2 = new List<double>();
      doubleList2.Clear();
      doubleList1.Clear();
      double num1 = 0.0;
      for (int index = 1; index <= this.n; ++index)
      {
        double num2 = (double) this.ControlPoint[index].X - (double) this.ControlPoint[index - 1].X;
        double num3 = (double) this.ControlPoint[index].Y - (double) this.ControlPoint[index - 1].Y;
        double num4 = Math.Sqrt(num2 * num2 + num3 * num3);
        doubleList1.Add(num4);
      }
      this.knots_value.Add(0.0);
      this.knots_muti.Add(this.k + 1);
      for (int index1 = 1; index1 <= this.n - this.k + 1; ++index1)
      {
        double num5 = 0.0;
        for (int index2 = index1; index2 <= index1 + this.k - 1; ++index2)
        {
          num5 += doubleList1[index2 - 1];
          num1 += doubleList1[index2 - 1];
        }
        doubleList2.Add(num5);
      }
      for (int index = 1; index <= this.n - this.k; ++index)
      {
        this.knots_value.Add(this.knots_value[index - 1] + doubleList2[index - 1] / num1);
        this.knots_muti.Add(1);
      }
      this.knots_value.Add(1.0);
      this.knots_muti.Add(this.k + 1);
    }

    public void CreateCurve()
    {
      this.Bvalue.Clear();
      for (int index = 0; index <= this.k; ++index)
        this.Bvalue.Add(1.0);
      this.GenerateKnots();
      this.CurvePoint.Clear();
      double u = 0.0;
      int index1 = 0;
      while (index1 <= this.n && this.knots_value[index1] <= 0.0)
        ++index1;
      for (; index1 < this.knots_value.Count && this.knots_value[index1] <= 1.00000001; ++index1)
      {
        double num1 = this.knots_value[index1];
        double num2 = (this.knots_value[index1] - this.knots_value[index1 - 1]) / 20.0;
        do
        {
          AddCurvePoint(u);
          u += num2;
        }
        while (u < num1);
        u = num1;
      }
      AddCurvePoint(1.0);

      if (this.curve_type != BsplineType.Uniform)
        return;

      CalculateUniformBfunc1st();
    }

    private void AddCurvePoint(double u)
    {
      int j = k + 1;
      while (j <= n && u >= KnotValue(j))
        ++j;
      int num1 = j - 1;
      if (u == KnotValue(num1))
        ;
      CalculateBvalue(u, num1);
      double x = 0.0;
      double y = 0.0;
      double num2 = 0.0;
      for (int index = 0; index <= k; ++index)
        num2 += Bvalue[index] * wlist[num1 - k + index];
      for (int index = 0; index <= k; ++index)
      {
        x += Bvalue[index] * wlist[num1 - k + index] / num2 * (double) ControlPoint[num1 - k + index].X;
        y += Bvalue[index] * wlist[num1 - k + index] / num2 * (double) ControlPoint[num1 - k + index].Y;
      }
      this.CurvePoint.Add(new PointF((float) x, (float) y));
    }

    private double KnotValue(int j)
    {
      double num1 = 0.0;
      int count = this.knots_value.Count;
      int num2 = 0;
      for (int index = 0; index < count; ++index)
      {
        num2 += this.knots_muti[index];
        if (num2 - 1 >= j)
        {
          num1 = this.knots_value[index];
          break;
        }
      }
      return num1;
    }

    private void CalculateBvalue(double u, int i)
    {
      List<double> doubleList1 = new List<double>();
      List<double> doubleList2 = new List<double>();
      for (int index = 0; index <= this.k; ++index)
      {
        doubleList1.Add(1.0);
        doubleList2.Add(1.0);
      }
      this.Bvalue[0] = 1.0;
      for (int index1 = 1; index1 <= this.k; ++index1)
      {
        doubleList1[index1] = u - this.KnotValue(i + 1 - index1);
        doubleList2[index1] = this.KnotValue(i + index1) - u;
        double num1 = 0.0;
        for (int index2 = 0; index2 < index1; ++index2)
        {
          double num2 = this.Bvalue[index2] / (doubleList2[index2 + 1] + doubleList1[index1 - index2]);
          this.Bvalue[index2] = num1 + doubleList2[index2 + 1] * num2;
          num1 = doubleList1[index1 - index2] * num2;
        }
        this.Bvalue[index1] = num1;
      }
    }

    private void CalculateUniformBfunc1st()
    {
    }
  }
}
