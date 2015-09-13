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
            repeaterHomepage.DataSource = null;
            repeaterHomepage.DataBind();
            fillOffers();
        }

        protected void fillOffers()
        {
            Database db = new Database();
            for (int i = 1; i < 10; i++) //example usage
            {
                offer offer = (offer)LoadControl("offer.ascx");
                offer.Name = i+" AlbumExample 2015";
                offer.Owner = "ExampleUser";
                offer.Trust = 5;
                offer.Description = "Example Description";
                offer.Price = 10;
                repeaterHomepage.Controls.Add(offer);
            }
            
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