using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public interface ITriangl
    {
        double A { set; get; }
        double B { set; get; }
        double C { set; get; }
        int LoadLength(IPointTriangl tr);
        int CalculateS(IPointTriangl tr);
    }
}
