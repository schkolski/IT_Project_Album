using System;
using System.Collections.Generic;
using System.Data;
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

                if (Session["UserName"] != null)
                {
                    Database db = new Database();
                    Korisnik k = db.getUserInfoByUsername(Session["UserName"].ToString());

                    if (k.Type == 1)
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                    else
                    {
                        GridView1.DataSource = db.getAllUsers();
                        GridView1.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("~/");
                }

                fillAllUsers();

            }
        }
        protected void LogOut_Click(Object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        public String fillAllUsers()
        {
            string var = "[";
            db = new Database();
            List<Korisnik> korisnici = db.getAllUser();
            niza = new String[korisnici.Count];
            int i = 0;
            foreach (Korisnik temp in korisnici)
            {
                var += "'" + temp.Username.ToString() + "'";
                var += ",";
            }
            return var.Substring(0, var.Length - 1) + "]";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String text = txtSearch.Text;

            if (text != null)
            {
                if (!text.Trim().Equals(""))
                {
                    clearGridView();
                    DataSet ds = new DataSet();

                    DataTable dt = new DataTable();
                    dt.Columns.Add("username", typeof(string));
                    dt.Columns.Add("type", typeof(string));
                    Database db = new Database();
                    Korisnik k = db.getUserInfoByUsername(text);

                    dt.Rows.Add(text, k.Type);
                    ds.Tables.Add(dt);

                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    fillGridView();
                }
            }
            else
            {
                fillGridView();
            }
        }
        private void fillGridView()
        {
            Database db = new Database();
            GridView1.DataSource = db.getAllUsers();
            GridView1.DataBind();
        }
        private void clearGridView()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string username = GridView1.SelectedRow.Cells[0].Text;
            Database db = new Database();
            db.changeType(username);

            btnSearch_Click(sender, e);
        }
    }
}