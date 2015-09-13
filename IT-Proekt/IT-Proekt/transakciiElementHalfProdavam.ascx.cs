using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class transakciiElementHalfProdavam : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOfferName1.Text = name1;
            lblOfferDescription1.Text = description1;
            lblOfferPrice1.Text = price1.ToString();
            lblOffer1ID.Text = offer1ID.ToString();
            lblUserName1.Text = user1;
            lblUserEmail1.Text = email1;
            lblOfferDatum.Text = date.ToShortDateString();

            imgOfferPreview1.ImageUrl = imgUrl_1;
        }

        private string name1;
        private string description1;
        private int price1;
        private int offer1ID;
        private string user1;
        private string email1;
        private DateTime date;

        public string imgUrl_1 { get; set; }
        public int albumID_1 { get; set; }

        public string Name1
        {
            get { return name1; }
            set { name1 = value; }
        }
        public string Description1
        {
            get { return description1; }
            set { description1 = value; }
        }
        public int Price1
        {
            get { return price1; }
            set { price1 = value; }
        }

        public int Offer1ID
        {
            get { return offer1ID; }
            set { offer1ID = value; }
        }

        public string User1
        {
            get { return user1; }
            set { user1 = value; }
        }

        public string Email1
        {
            get { return email1; }
            set { email1 = value; }
        }

        private DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}