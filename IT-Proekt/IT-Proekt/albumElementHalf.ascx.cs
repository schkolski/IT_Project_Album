using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class albumElementHalf : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAlbumElementID.Text = slikaID.ToString();
            lblAlbumElementName.Text = albumName;
            lblAlbumElementGodina.Text = year.ToString();
        }   

        private int slikaID;
        private string albumName;
        private int year;
        private int albumID;

        public int SlikaID
        {
            get { return slikaID; }
            set { slikaID = value; }
        }

        public string AlbumName
        {
            get { return albumName; }
            set { albumName = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public int AlbumID
        {
            get { return albumID; }
            set { albumID = value; }
        }
       
    }
}