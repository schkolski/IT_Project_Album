using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace IT_Proekt
{
    public partial class _Default : Page
    {
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
                if(Session["UserName"] != null)
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
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

        protected void LogIn_Click(object sender, EventArgs e)
        {
           // lblError.Visible = false;
            System.Diagnostics.Debug.WriteLine("Yes");
            baza = new Database();
            bool flag = baza.checkKorisnik(tbUsernamelog.Text, tbPasslog.Text);
            if (flag == true)
            {
                Korisnik ab = baza.getUserInfoByUsername(tbUsernamelog.Text);
                if (ab.Type == 0)
                {
                    // ova e adminot redirect na adminPage
                    Session["UserName"] = tbUsernamelog.Text.ToString();
                    Session["Admin"] = "Admin";
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                System.Diagnostics.Debug.WriteLine("REDIREKT");
                Session["UserName"] = tbUsernamelog.Text.ToString();
                Response.Redirect("HomePage.aspx");
                /// ako  e admin redirect na adminPage ; treba vo baza funkcija za proverka dali e admin
                /// 
                }
            }
            else
            {
                lblError.Visible = true;
            }

        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            baza = new Database();
            int day = 0;
            int year = 0;
            Int32.TryParse(ddYear.SelectedValue.ToString(), out year);
            int month = ddMonth.SelectedIndex;
            Int32.TryParse(ddDay.SelectedValue.ToString(), out day);

            if (day != 0 && year != 0 && ddMonth.SelectedIndex >= 1)
            {
                DateTime db = new DateTime(year, month, day);
                bool flag = baza.checkKorisnik(tbUserReg.Text, tbPassReg.Text);
                if (flag == false)
                {
                    int sex = rbMale.Checked ? 1 : 0;
                    baza.addKorisnik(tbUserReg.Text, tbPassReg.Text, tbName.Text, tbEmail.Text, 1, db, sex);
                    Session["UserName"] = tbUserReg.Text.ToString();
                    Response.Redirect("Album.aspx");
                }
                else 
                {
                   // lblError.Text = "Постоечко корисничко име";
                    
                }
            }
        }
        public void AllUsers(ArrayList korisnici)
        {
            Application.Lock();
            foreach (Korisnik temp in korisnici)
            {
                if (temp.Username.Equals(tbUsernamelog.Text))
                {
                    System.Diagnostics.Debug.WriteLine("Ne moze da se logirate 2 pati ve vrakjam na pocetok");
                    Response.Redirect("Default.aspx");
                    break;
                }
                else
                {
                    korisnici.Add(new Korisnik(tbUsernamelog.Text));
                    break;
                }
            }
            Application.Set("0", korisnici);
            Application.UnLock();
        }
    }
}