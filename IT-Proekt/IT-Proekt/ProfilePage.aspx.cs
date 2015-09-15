using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        private Database db;
        
        public ServiceReference1.WebService1 ab;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    string username = Session["UserName"].ToString();

                    db = new Database();
                   Korisnik k = db.getUserInfoByUsername(username);
                    if (k != null)
                    {
                        tbName.Text = k.Name;
                        tbEmail.Text = k.Email;
                        bDay.Text = k.Birthday.ToShortDateString();
                        rbFemale.Checked = k.Sex == 0;
                        rbMale.Checked = k.Sex == 1;
                    }
                    if (k.Type == 1) 
                    {
                       
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
        public String primer() 
        {
            ab = new ServiceReference1.WebService1();
            if (ab.isAdmin(Session["UserName"].ToString())) {
                return "true";
            }
            return "false";
        }
        protected void changePass_Click(object sender, EventArgs e)
        {
            db = new Database();
            bool change = db.changePassword(Session["UserName"].ToString(),
                oldPassword.Value.ToString(),
                newPassword.Value.ToString());
        }

        protected void Promeni_Click(object sender, EventArgs e)
        {
            // TODO: Make validation of all input fields 
            db = new Database();
            int sex = 1;
            if (rbFemale.Checked)
                sex = 0;



            db.updateKorisnik(Session["UserName"].ToString(),
                tbName.Text, tbEmail.Text, DateTime.Parse(bDay.Text), sex);
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