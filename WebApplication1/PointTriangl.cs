using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace WebApplication1
{
    public class PointTriangl : IPointTriangl
    {
        public double AB { get; }
        public double BC { get; }
        public double AC { get; }

        public PointTriangl(PointF A, PointF B, PointF C)
        {
            AB = Length(A, B);
            BC = Length(B, C);
            AC = Length(A, C);
        }

        public static double Length(PointF A, PointF B)
        {
            return Math.Sqrt(Math.Pow(B.X-A.X,2)+Math.Pow(B.Y-A.Y,2));
        }
    }
}