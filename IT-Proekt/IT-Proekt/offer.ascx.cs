﻿using System;
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
            lblOfferName.Text = name;
            lblOfferOwner.Text = owner;
            lblOfferTrustLevel.Text = trust.ToString();
            lblOfferDescription.Text = description;
            lblOfferPrice.Text = price.ToString();
        }

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

    }
}