using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                 //dinamichno dodaj offers
            }
            
            fillOffers();
        }

        protected void fillOffers()
        {
            clearScreen();
            Database db = new Database();
            List<Ponuda> offers = db.getAllOffersForUsername(Session["UserName"].ToString(),
                Ponuda.DATE);

            foreach (Ponuda o in offers)
            {
                offer offerElem = (offer)LoadControl("offer.ascx");
                Album a = db.getAlbumByID(o.AlbumID);
                Slika s = db.getPicture(o.AlbumID, o.BrojSlika);
                offerElem.imgUrl = s.Url;
                offerElem.Name = o.BrojSlika + " - " + o.Name + " " + a.Year;
                offerElem.Owner = o.Username;
                offerElem.Description = o.Desc;
                offerElem.Price = o.Price;
                offerElem.Trust = 5;
                offerElem.Datum = o.Datum;
                offerElem.thisPonuda = o;
                repeaterHomepage.Controls.Add(offerElem);
            }
        }
        private void clearScreen()
        {
            repeaterHomepage.DataSource = null;
            repeaterHomepage.DataBind();
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