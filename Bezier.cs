// Decompiled with JetBrains decompiler
// Type: diao.Bezier
// Assembly: diao, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9B9CD16-F024-45F9-8D13-D1172328D6F7
// Assembly location: F:\engraver\LaserEngraver\Laser Framework4.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace diao
{
  public static class Bezier
  {
    public static PointF[] draw_bezier_curves(PointF[] points, int count, float step)
    {
      List<PointF> pointFList = new List<PointF>();
      float t = 0.0f;
      do
      {
        PointF pointF = Bezier.bezier_interpolation_func(t, points, count);
        t += step;
        pointFList.Add(pointF);
      }
      while ((double) t <= 1.0 && count > 1);
      return pointFList.ToArray();
    }

    private static PointF bezier_interpolation_func2(float t, PointF[] points, int count)
    {
      PointF pointF = new PointF();
      float num1 = 0.0f;
      float num2 = 0.0f;
      for (int index = 0; index < count; ++index)
      {
        int n = count - 1;
        ulong num3 = Bezier.calc_combination_number(n, index);
        num1 += (float) ((double) num3 * (double) points[index].X * Math.Pow(1.0 - (double) t, (double) (n - index)) * Math.Pow((double) t, (double) index));
        num2 += (float) ((double) num3 * (double) points[index].Y * Math.Pow(1.0 - (double) t, (double) (n - index)) * Math.Pow((double) t, (double) index));
      }
      pointF.X = num1;
      pointF.Y = num2;
      return pointF;
    }

    private static ulong calc_combination_number(int n, int k)
    {
      ulong[] numArray = new ulong[n + 1];
      for (int index1 = 1; index1 <= n; ++index1)
      {
        numArray[index1] = 1UL;
        for (int index2 = index1 - 1; index2 >= 1; --index2)
          numArray[index2] += numArray[index2 - 1];
        numArray[0] = 1UL;
      }
      return numArray[k];
    }

    public static PointF bezier_interpolation_func(float t, PointF[] points, int count)
    {
      if (points.Length < 1)
        throw new ArgumentOutOfRangeException();
      PointF[] pointFArray = new PointF[count];
      for (int index1 = 1; index1 < count; ++index1)
      {
        for (int index2 = 0; index2 < count - index1; ++index2)
        {
          if (index1 == 1)
          {
            pointFArray[index2].X = (float) ((double) points[index2].X * (1.0 - (double) t) + (double) points[index2 + 1].X * (double) t);
            pointFArray[index2].Y = (float) ((double) points[index2].Y * (1.0 - (double) t) + (double) points[index2 + 1].Y * (double) t);
          }
          else
          {
            pointFArray[index2].X = (float) ((double) pointFArray[index2].X * (1.0 - (double) t) + (double) pointFArray[index2 + 1].X * (double) t);
            pointFArray[index2].Y = (float) ((double) pointFArray[index2].Y * (1.0 - (double) t) + (double) pointFArray[index2 + 1].Y * (double) t);
          }
        }
      }
      return pointFArray[0];
    }
  }
}
