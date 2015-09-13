using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IT_Proekt
{
    public partial class Transakcii : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogOut_Click(Object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        protected void btnTabKupuvam_Click(object sender, EventArgs e)
        {
            liTabKupuvam.Attributes["Class"] = "active";
            liTabProdavam.Attributes["Class"] = "";
            liTabIstorija.Attributes["Class"] = "";
        }

        protected void btnTabProdavam_Click(object sender, EventArgs e)
        {
            liTabKupuvam.Attributes["Class"] = "";
            liTabProdavam.Attributes["Class"] = "active";
            liTabIstorija.Attributes["Class"] = "";
        }

        protected void btnTabIstorija_Click(object sender, EventArgs e)
        {
            liTabKupuvam.Attributes["Class"] = "";
            liTabProdavam.Attributes["Class"] = "";
            liTabIstorija.Attributes["Class"] = "active";
        }
    }
}