using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class albumElement : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAlbumElementID1.Text = slikaID1.ToString();
            lblAlbumElementName1.Text = albumName;
            lblAlbumElementGodina1.Text = year.ToString();

            lblAlbumElementID2.Text = slikaID2.ToString();
            lblAlbumElementName2.Text = albumName;
            lblAlbumElementYear2.Text = year.ToString();
        }

        private int slikaID1;
        private string albumName;
        private int year;
        private int albumID;
        private int slikaID2;
        
        public int SlikaID1
        {
            get { return slikaID1; }
            set { slikaID1 = value; }
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

        public int SlikaID2
        {
            get { return slikaID2; }
            set { slikaID2 = value; }
        }
        
    }
}