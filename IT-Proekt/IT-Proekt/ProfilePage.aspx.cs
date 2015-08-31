using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace IT_Proekt
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        bool flag = false;
        String[] meseci = new String[] { "Mesec", "Januari", "Februari", "Mart", "April", "Maj", "Juni", "Juli", "Avgust", "Septemvri", "Oktomvri", "Noemvri", "Dekemvri" };
        ArrayList godini = new ArrayList();
        ArrayList denovi = new ArrayList();
        Database baza;
        ArrayList korisnici = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddMonth.DataSource = meseci;
                ddMonth.DataBind();
                ddDay.DataSource = fillDays(denovi);
                ddDay.DataBind();
                ddYear.DataSource = fillYear(godini);
                ddYear.DataBind();
            }
        }

        protected void changePass_Click(object sender, EventArgs e)
        {
            /*if (tbPassword.Visible == false)
            {
                tbPassword.Visible = true;
                tbRePass.Visible = true;
            }
            else
            {
                tbRePass.Visible = false;
                tbPassword.Visible = false;
            }*/
        }
        public ArrayList fillYear(ArrayList year)
        {
            year.Add("Godina");
            for (int i = 0; i < 52; i++)
            {
                int k = 1960;
                year.Add(k + i + "");
            }
            return year;
        }
        public ArrayList fillDays(ArrayList days)
        {
            days.Add("Den");
            for (int i = 1; i < 32; i++)
            {
                days.Add(i + "");
            }
            return days;
        }
    }
}