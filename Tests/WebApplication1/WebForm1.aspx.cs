using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            double S,P;
            float x, y;
            PointF A, B, C;
            try
            {
                x = float.Parse(TextBox1.Text);
                y = float.Parse(TextBox4.Text);
                A = new PointF(x, y);

                x = float.Parse(TextBox2.Text);
                y = float.Parse(TextBox5.Text);
                B = new PointF(x, y);

                x = float.Parse(TextBox3.Text);
                y = float.Parse(TextBox6.Text);
                C = new PointF(x, y);
            }
            catch
            {
                Response.Write("<script>alert('Error Point!');</script>");
                return;
            }
            PointTriangl pointTriangl = new PointTriangl(A, B, C);
            Triangl triangl = new Triangl();
            int error = triangl.CalculateS(pointTriangl);
            if (error == MyError.ErrorTriangl)
            {
                Response.Write("<script>alert('Error Point! Triangl not found');</script>");
                return;
            }
            S = triangl.S;
            P = triangl.P;
            Label1.Text = S.ToString();
            Label2.Text = P.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }
    }
}