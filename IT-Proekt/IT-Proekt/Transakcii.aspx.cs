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
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/");
            }
            if (!Page.IsPostBack)
            {
                if (Session["state"] != null)
                {
                    if (Session["state"].ToString().Equals("prodavam"))
                    {
                        btnTabProdavam_Click(sender, e);
                    }
                    else if (Session["state"].ToString().Equals("kupuvam"))
                    {
                        btnTabKupuvam_Click(sender, e);
                    }
                }
                else
                {
                    btnTabKupuvam_Click(sender, e);
                }
            }
            fillTransakcii();
        }
        protected void fillTransakcii()
        {
            clearScreen();
            Database db = new Database();
            List<Transakcija> transakcii;
            int tab = -1;
            if (ViewState["tab"] != null)
                Int32.TryParse(ViewState["tab"].ToString(), out tab);

            if (tab != -1)
            {
                if (tab == 0)
                    transakcii = db.getAllTransakciiKupuvamForUsername(Session["UserName"].ToString(),
                Ponuda.DATE);
                else if (tab == 1)
                    transakcii = db.getAllTransakciiProdavamForUsername(Session["UserName"].ToString(),
                Ponuda.DATE);
                // TODO: ovde za istorija
                else
                {
                    transakcii = db.getAllTransakciiHistoryForUsername(Session["UserName"].ToString(),
                Ponuda.DATE);
                    
                }
            }
            else return;

            if (transakcii == null) return;
            foreach (Transakcija t in transakcii)
            {
                if (tab == 1) // Prodavam opcii
                {
                    if (t.AlbumID == -1)//E obicna buy transakcija
                    {
                        transakciiElementHalfProdavam tranElem = (transakciiElementHalfProdavam)LoadControl("transakciiElementHalfProdavam.ascx");
                        Ponuda p = db.getOffer(t.ID);
                        Korisnik user = db.getUserInfoByUsername(t.Username);
                        Slika s = db.getPicture(p.AlbumID, p.BrojSlika);
                        tranElem.Name1 = p.Name;
                        tranElem.Description1 = p.Desc;
                        tranElem.Email1 = user.Email;
                        tranElem.Price1 = p.Price;
                        tranElem.Offer1ID = p.AlbumID;
                        tranElem.User1 = t.Username;
                        tranElem.imgUrl_1 = s.Url;
                        tranElem.Date = t.Datum;
                        tranElem.tranID = t.ID;
                        repeaterTransakcii.Controls.Add(tranElem);
                    }
                    else
                    {
                        transakciiExchangeElementHalfProdavam tranElem = (transakciiExchangeElementHalfProdavam)LoadControl("transakciiExchangeProdavam.ascx");
                        Ponuda p = db.getOffer(t.ID);
                        Korisnik user = db.getUserInfoByUsername(t.Username);
                        Slika s_moja = db.getPicture(p.AlbumID, p.BrojSlika);
                        Slika s_zamena = db.getPicture(t.AlbumID, t.PictureID);
                        tranElem.Name1 = p.Name;
                        tranElem.Description1 = p.Desc;
                        tranElem.Email1 = user.Email;
                        tranElem.Price1 = p.Price;
                        tranElem.Offer1ID = p.AlbumID;
                        tranElem.User1 = t.Username;
                        tranElem.Date = t.Datum;
                        tranElem.imgUrl_1 = s_moja.Url;
                        tranElem.imgID_1 = s_moja.Broj;
                        tranElem.tranID = t.ID;

                        tranElem.imgUrl_2 = s_zamena.Url;
                        tranElem.imgID_2 = s_zamena.Broj;
                        repeaterTransakcii.Controls.Add(tranElem);
                    }
                }
                else if(tab == 0)
                {
                    if (t.AlbumID == -1)//E obicna buy transakcija
                    {
                        transakciiExchangeElementHalf tranElem = (transakciiExchangeElementHalf)LoadControl("transakciiExchange.ascx");
                        Ponuda p = db.getOffer(t.ID);
                        Korisnik user = db.getUserInfoByUsername(t.Username);
                        Slika s = db.getPicture(p.AlbumID, p.BrojSlika);
                        tranElem.Name1 = p.Name;
                        tranElem.Description1 = p.Desc;
                        tranElem.Email1 = user.Email;
                        tranElem.Price1 = p.Price;
                        tranElem.Offer1ID = p.AlbumID;
                        tranElem.User1 = t.Username;
                        tranElem.imgUrl_1 = s.Url;
                        tranElem.Date = t.Datum;
                        tranElem.tranID = t.ID;
                        tranElem.Status = t.Status;
                        repeaterTransakcii.Controls.Add(tranElem);
                    }
                    else
                    {
                        transakciiElement tranElem = (transakciiElement)LoadControl("transakciiElement.ascx");
                        Ponuda p = db.getOffer(t.ID);
                        Korisnik user = db.getUserInfoByUsername(t.Username);
                        Slika s_moja = db.getPicture(p.AlbumID, p.BrojSlika);
                        Slika s_zamena = db.getPicture(t.AlbumID, t.PictureID);
                        tranElem.Name1 = p.Name;
                        tranElem.Description1 = p.Desc;
                        tranElem.Email1 = user.Email;
                        tranElem.Price1 = p.Price;
                        tranElem.Offer1ID = p.AlbumID;
                        tranElem.User1 = t.Username;
                        tranElem.Date = t.Datum;
                        tranElem.imgUrl_1 = s_moja.Url;
                        tranElem.imgID_1 = s_moja.Broj;
                        tranElem.tranID = t.ID;
                        tranElem.Status = t.Status;
                        tranElem.imgUrl_2 = s_zamena.Url;
                        tranElem.imgID_2 = s_zamena.Broj;
                        repeaterTransakcii.Controls.Add(tranElem);
                    }
                }
                else
                { // history
                    if (t.AlbumID == -1)//E obicna buy transakcija
                    {
                        transakciiExchangeElementHalf tranElem = (transakciiExchangeElementHalf)LoadControl("transakciiExchange.ascx");
                        Ponuda p = db.getOffer(t.ID);
                        Korisnik user = db.getUserInfoByUsername(t.Username);
                        Slika s = db.getPicture(p.AlbumID, p.BrojSlika);
                        tranElem.Name1 = p.Name;
                        tranElem.Description1 = p.Desc;
                        tranElem.Email1 = user.Email;
                        tranElem.Price1 = p.Price;
                        tranElem.Offer1ID = p.AlbumID;
                        tranElem.User1 = t.Username;
                        tranElem.imgUrl_1 = s.Url;
                        tranElem.Date = t.Datum;
                        tranElem.tranID = t.ID;
                        tranElem.Status = t.Status;
                        repeaterTransakcii.Controls.Add(tranElem);
                    }
                    else
                    {
                        transakciiElement tranElem = (transakciiElement)LoadControl("transakciiElement.ascx");
                        Ponuda p = db.getOffer(t.ID);
                        Korisnik user = db.getUserInfoByUsername(t.Username);
                        Slika s_moja = db.getPicture(p.AlbumID, p.BrojSlika);
                        Slika s_zamena = db.getPicture(t.AlbumID, t.PictureID);
                        tranElem.Name1 = p.Name;
                        tranElem.Description1 = p.Desc;
                        tranElem.Email1 = user.Email;
                        tranElem.Price1 = p.Price;
                        tranElem.Offer1ID = p.AlbumID;
                        tranElem.User1 = t.Username;
                        tranElem.Date = t.Datum;
                        tranElem.imgUrl_1 = s_moja.Url;
                        tranElem.imgID_1 = s_moja.Broj;
                        tranElem.tranID = t.ID;

                        tranElem.imgUrl_2 = s_zamena.Url;
                        tranElem.imgID_2 = s_zamena.Broj;

                        tranElem.Status = t.Status;
                        repeaterTransakcii.Controls.Add(tranElem);
                    }
                }

                //repeaterTransakcii.Controls.Add(tranElem);
            }
        }
        private void clearScreen()
        {
            repeaterTransakcii.DataSource = null;
            repeaterTransakcii.DataBind();
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
            ViewState["tab"] = 0;
            fillTransakcii();
        }

        protected void btnTabProdavam_Click(object sender, EventArgs e)
        {
            liTabKupuvam.Attributes["Class"] = "";
            liTabProdavam.Attributes["Class"] = "active";
            liTabIstorija.Attributes["Class"] = "";
            ViewState["tab"] = 1;
            fillTransakcii();
        }

        protected void btnTabIstorija_Click(object sender, EventArgs e)
        {
            liTabKupuvam.Attributes["Class"] = "";
            liTabProdavam.Attributes["Class"] = "";
            liTabIstorija.Attributes["Class"] = "active";
            ViewState["tab"] = 2;
            fillTransakcii();
        }
    }
}