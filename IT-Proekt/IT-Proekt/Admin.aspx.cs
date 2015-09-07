using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               /* if (Session["UserName"] == null || Session["Admin"] != null)
                {
                    Response.Redirect("Default.aspx");
                }*/
            }
        }
        protected void LogOut_Click(Object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}