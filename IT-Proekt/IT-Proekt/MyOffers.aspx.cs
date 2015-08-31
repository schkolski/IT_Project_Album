using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace IT_Proekt
{
    public partial class MyOffers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOfferClear_Click(object sender, EventArgs e)
        {
            txbNewOfferAlbum.Text = "";
            txbNewOfferID.Text = "";
            txbNewOfferAlbumYear.Text = "";
            chkNewOfferExchange.Checked = false;
            txbNewOfferNumber.Text = "1";
            txbNewOfferDescription.Text = "";
            txbNewOfferPrice.Text = "";
            
        }

        protected void btnOfferRefresh_Click(object sender, EventArgs e)
        {

        }

        protected void btnNewOfferSubmit_Click(object sender, EventArgs e)
        {

        }

                
            
            
        
    }
}