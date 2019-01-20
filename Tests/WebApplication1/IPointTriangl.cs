using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WebApplication1
{
    public interface IPointTriangl
    {
        double AB { get; }
        double BC { get; }
        double AC { get; }
    }
}
