using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class myOfferHalf : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOfferName1.Text = name;
            lblOfferDescription1.Text = description;
            if (price <= 0)
            {
                lblOfferPrice1.Text = "Замена";
            }
            else 
            { 
                lblOfferPrice1.Text = price.ToString();
            }
            lblOffer1ID.Text = offer1ID.ToString();
            imgOfferPreview1.ImageUrl = imgUrl;
        }

        private string name;
        private string description;
        private int price;
        private int offer1ID;
        public int pictureID { get; set; }
        public int albumID { get; set; }
        public string imgUrl { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Offer1ID
        {
            get { return offer1ID; }
            set { offer1ID = value; }
        }

        protected void btnOfferRemove1_Click(object sender, EventArgs e)
        {
            string username = Session["UserName"].ToString();


            Database db = new Database();
            bool res = db.removeOffer(username, albumID, pictureID);

            if (res)
            {
                // TODO: poraki za uspeshno izbrishana ponuda
                // TODO: Review this new feature...
                refreshPage();
            }
        }
        private void refreshPage()
        {
            Response.Redirect("~/MyOffers.aspx");
        }
    }
}