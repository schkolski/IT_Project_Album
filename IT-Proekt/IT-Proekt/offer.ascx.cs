using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class offer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserName.Text = "Owner: " + owner;
            lblOfferName.Text = name;
          //  lblOfferTrustLevel.Text = trust.ToString();
            lblOfferDescription.Text = description;
            lblOfferPrice.Text = price.ToString();

            Database db = new Database();
            List<int> Brojki = db.getAvailableExchangePictures(Session["UserName"].ToString(), thisPonuda.Name, thisPonuda.AlbumID);
            if (Brojki.Count > 0)
            {
                ddZamena.DataSource = Brojki;
                ddZamena.DataBind();
            }
            else
            {
                ddZamena.Visible = false;
                exchange.Enabled = false;
            }
            imgOfferPreview.ImageUrl = imgUrl;
            // This label must be empty  
            lblOfferOwner.Text = ""; 
            lblOfferDatum.Text = Datum.ToShortDateString();
            exchange.Visible = thisPonuda.Exchange == 1;
        }
        public Ponuda thisPonuda { get; set; }
        public DateTime Datum { get; set; }
        public string imgUrl { get; set; }
        private string name;
        private string owner;
        private int trust;
        private string description;
        private int price;
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
        public string Owner 
        {
            get { return owner; }
            set { owner = value; }
        }
        public int Trust
        {   
            get { return trust; }
            set { trust = value; }
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

        protected void exchange_Click(object sender, EventArgs e)
        {
            ddZamena.Visible = true;
            exchange.Enabled = false;
        }

        protected void ddZamena_SelectedIndexChanged(object sender, EventArgs e)
        {

            Database db = new Database();
            int imgID_selected = Int32.Parse(ddZamena.SelectedItem.Text);
            
            bool res = db.addTransakcijaExchange(Session["UserName"].ToString(), thisPonuda.ID, thisPonuda.AlbumID, imgID_selected);

            Response.Redirect("~/HomePage.aspx");
        }

        protected void btnOfferBuy_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            bool res = db.addTransakcijaBuy(Session["UserName"].ToString(), thisPonuda.ID);
            Response.Redirect("~/HomePage.aspx");
        }
    }
}