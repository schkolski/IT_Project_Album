using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using System.Data.SqlClient;

namespace IT_Proekt
{
    public partial class Statistiki : System.Web.UI.Page
    {
        public ServiceReference1.WebService1 ab;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                if (Session["UserName"] == null) {
                    Response.Redirect("~/");
                }
            }
            ab = new ServiceReference1.WebService1();
            Database db = new Database();

            //primer podatoci za primer pitite
            double[] yValues = { 71.15, 23.19, 5.66 };
            string[] xValues = { "AAA", "BBB", "CCC" };

            //pita 1 pochnuva tuka

            //primer polnenje podatoci od baza
            DataTable dt = ab.getNajmnoguBrojPonudiVoDen();
            foreach (DataRow row in dt.Rows)
            {
                Chart1.Series["Default"].Points.AddXY(row[0], row[1]);
            }


            Chart1.Series["Default"].Points[0].Color = Color.MediumSeaGreen;
            Chart1.Series["Default"].Points[1].Color = Color.PaleGreen;
            

            Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

            Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";

            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            Chart1.Legends[0].Enabled = true;
            lblPie1.Text = "На датумот " + dt.Rows[0][0].ToString().Split(' ')[0] + " корисниците поставиле " + dt.Rows[0][1].ToString() +
                " понуди и тоа претставува најпродуктивен ден во историјата на ИТ Албуми.";

            //pita1 kraj

            //pita 2 pochnuva tuka

            int[] slikiVoPonuda = ab.getPercentOfPicturesOnOffer();
            string[] naslov = { "Сликички на понуда", "Сликички" };

            Chart2.Series["Default"].Points.DataBindXY(naslov, slikiVoPonuda);

            Chart2.Series["Default"].Points[0].Color = Color.MediumSeaGreen;
            Chart2.Series["Default"].Points[1].Color = Color.PaleGreen;

            Chart2.Series["Default"].ChartType = SeriesChartType.Pie;

            Chart2.Series["Default"]["PieLabelStyle"] = "Disabled";

            Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            Chart2.Legends[0].Enabled = true;

            lblPie2.Text = "Од вкупно " + slikiVoPonuda[1].ToString() + " сликички корисниците можат да купат или заменат " + slikiVoPonuda[0].ToString() + " сликички.";

            //pita2 kraj



            //pita 3 pochnuva tuka
            int[] statusi = ab.getAllTransakciiByStatus();
            string[] statusiNaslov = { "Во тек", "Откажани ", "Потврдени" };
            Chart3.Series["Default"].Points.DataBindXY(statusiNaslov, statusi);

            Chart3.Series["Default"].Points[0].Color = Color.Orange;
            Chart3.Series["Default"].Points[1].Color = Color.DarkRed;
            Chart3.Series["Default"].Points[2].Color = Color.MediumSeaGreen;

            Chart3.Series["Default"].ChartType = SeriesChartType.Pie;

            Chart3.Series["Default"]["PieLabelStyle"] = "Disabled";

            Chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            Chart3.Legends[0].Enabled = true;
            lblPie3.Text = "Има " + statusi[0] + " почнати трансакции, " + statusi[1] + " откажани и " + statusi[2] + " потврдени трансакции";
            //pita3 kraj



            //najprodavana slika pochnuva tuka
            Slika najprodavanaSlika = ab.getNajprodavanaSlika();
            if (najprodavanaSlika != null)
            {
                lblNajprodavana.Text = najprodavanaSlika.Name;
                Album album = db.getAlbumByID(najprodavanaSlika.AlbumID);
                lblNajprodavanaDescription.Text = "Оваа сликичка е најпополарна во овој момент. Се работи за сликичка од албумот " + album.Name + " издаден во " + album.Year + " година.";
                imgNajprodavana.ImageUrl = najprodavanaSlika.Url;
            }

            //najprodavana kraj


            //najskapa slika pochnuva tuka
            Slika najskapaSlika = ab.getNajskapoProdadenaSlika();
            if (najskapaSlika != null)
            {
                lblNajskapa.Text = najskapaSlika.Name;
                lblNajskapaDescription.Text = "Најскапо продадената сликичка e " + najskapaSlika.Name + ".";
                imgNajskapa.ImageUrl = najskapaSlika.Url;
            }
            //najskapa slika kraj


            //korisnik shto najmnogu potroshil
            Korisnik korisnikPotroshil = ab.getUserNajmnoguPotroshil();
            if (korisnikPotroshil != null)
            {
                lblNajmnoguPotroshil.Text = korisnikPotroshil.Name;
                lblNajmnoguPotroshilDescription.Text = "Kорисникot што потрошил најмногу пари e " + korisnikPotroshil.Username + ".";
            }
            //korisnik shto najmnogu potroshil kraj

        }

        protected void LogOut_Click(Object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        public String primer()
        {
            ab = new ServiceReference1.WebService1();
            if (ab.isAdmin(Session["UserName"].ToString()))
            {
                return "true";
            }
            return "false";
        }
    }
}