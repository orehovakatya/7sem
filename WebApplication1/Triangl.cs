using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Triangl : ITriangl
    {
        public double A { set; get; }
        public double B { set; get; }
        public double C { set; get; }
        public double S, P;

        public int LoadLength(IPointTriangl tr)
        {
            A = tr.AB;
            B = tr.AC;
            C = tr.BC;
            if (A <= 0 || B <= 0 || C <= 0)
                return MyError.ErrorLength;
            if (A + B <= C || B + C <= A || A + C <= B)
                    return MyError.ErrorTriangl;
            return MyError.OK;   
        }

        public int CalculateS(IPointTriangl tr)
        {
            int error = LoadLength(tr);
            if (error == MyError.OK)
            {
                P = A + B + C;
                double p = P / 2.0;
                S = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
                return MyError.OK;
            }
            return error;
        }

    }
}