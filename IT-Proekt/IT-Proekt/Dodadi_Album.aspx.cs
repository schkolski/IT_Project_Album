using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class Dodadi_Album : System.Web.UI.Page
    {
        Database db;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btAddAlbum_Click(object sender, EventArgs e)
        {
            db = new Database();
            int year = 0;
            Int32.TryParse(tbYear.Text,out year);
            db.addAlbum(tbTitle.Text, year);
        }

        protected void ValidationSummary1_DataBinding(object sender, EventArgs e)
        {

        }
    }
}