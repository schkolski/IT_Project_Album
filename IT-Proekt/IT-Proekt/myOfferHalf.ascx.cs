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
            lblOfferPrice1.Text = price.ToString();
            lblOffer1ID.Text = offer1ID.ToString();
        }

        private string name;
        private string description;
        private int price;
        private int offer1ID;

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
    }
}