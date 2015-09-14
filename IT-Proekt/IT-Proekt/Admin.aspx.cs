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
        Database db;
        public String[] niza;
        public int br = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillAllUsers();
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
        public String fillAllUsers() {
            string var = "[";
            db = new Database();
            List<Korisnik> korisnici = db.getAllUser();
            niza = new String[korisnici.Count];
            int i = 0;
            foreach (Korisnik temp in korisnici)
            {
                var += "'"+temp.Username.ToString()+"'";
                var += ",";
            }
            return var.Substring(0, var.Length -1) + "]";
        }
    }
}