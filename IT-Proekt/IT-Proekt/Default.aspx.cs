using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections;
using System.Web.SessionState;

namespace IT_Proekt
{
    public partial class _Default : Page
    {
        String[] meseci = new String [] { "Mesec","Januari", "Februari","Mart","April","Maj","Juni","Juli","Avgust","Septemvri","Oktomvri","Noemvri","Dekemvri" };
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
        public ArrayList fillYear(ArrayList year)
        {
            year.Add("Godina");
            for(int i = 0; i < 52; i++)
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
                days.Add(i+"");
            }
            return days;
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Yes");
            baza = new Database();
            bool flag = baza.checkKorisnik(tbUsernamelog.Text, tbPasslog.Text);
            if (flag == true)
            {
                Session["UserName"] = tbUserReg.Text;
                Session["Email"] = tbEmail.Text;
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("ne e registriran");
            }

        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            baza = new Database();
            int year = Int32.Parse(ddYear.SelectedValue.ToString());
            int month = ddMonth.SelectedIndex+1;
            int day = ddDay.SelectedIndex + 1;
            DateTime db = new DateTime(year,month,day);
            bool flag = baza.checkKorisnik(tbUserReg.Text, tbPassReg.Text);
            if (flag == false)
            {
                System.Diagnostics.Debug.WriteLine("da proveruvam");
                baza.addKorisnik(tbUserReg.Text, tbPassReg.Text, tbName.Text, tbEmail.Text, 1, db, 1);
            }
            else
                System.Diagnostics.Debug.WriteLine("veke e registrian");    
        }
        public void AllUsers(ArrayList korisnici)
        {
            Application.Lock();
            foreach(Korisnik temp in korisnici)
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