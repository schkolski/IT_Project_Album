using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class transakciiElement : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOfferName1.Text = name1;
            lblOfferDescription1.Text = description1;
            lblOfferPrice1.Text = price1.ToString();
            lblOffer1ID.Text = offer1ID.ToString();
            lblUserName1.Text = user1;
            lblUserEmail1.Text = email1;

            lblOfferName2.Text = name2;
            lblOfferDescription2.Text = description2;
            lblOfferPrice2.Text = price2.ToString();
            lblOffer2ID.Text = offer2ID.ToString();
            lblUserName2.Text = user2;
            lblUserEmail2.Text = email2;
        }

        private string name1;
        private string description1;
        private int price1;
        private int offer1ID;
        private string user1;
        private string email1;

        private string name2;
        private string description2;
        private int price2;
        private int offer2ID;
        private string user2;
        private string email2;

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

        public string Name2
        {
            get { return name2; }
            set { name2 = value; }
        }
        public string Description2
        {
            get { return description2; }
            set { description2 = value; }
        }
        public int Price2
        {
            get { return price2; }
            set { price2 = value; }
        }
        public int Offer2ID
        {
            get { return offer2ID; }
            set { offer2ID = value; }
        }
        public string User2
        {
            get { return user2; }
            set { user2 = value; }
        }

        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }
    }
}