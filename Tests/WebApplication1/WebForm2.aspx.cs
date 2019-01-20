using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["idoriginal"] = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = LoginEmail.Text;
            string password = LoginPassword.Text;

            myDAL objmyDAl = new myDAL();

            int status = 0;
            int id = 0;

            status = objmyDAl.validateLogin(email, password, ref id);

            if (status == 0)
            {
                Session["idoriginal"] = id;

                    Response.BufferOutput = true;
                    Response.Redirect("~/WebForm1.aspx");
                    return;
            }


            else if (status == 1)
            {
                Response.Write("<script>alert('Email not found. Try Again !');</script>");
            }

            else if (status == 2)
            {
                Response.Write("<script>alert('Incorrect Password. Try Again !');</script>");
            }

            else if (status == -1)
            {
                Response.Write("<script>alert('There was some error. Try Again !');</script>");
            }
        }
    }
}