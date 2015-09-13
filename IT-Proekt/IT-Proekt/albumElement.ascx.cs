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
            imgAlbumElementPreview1.ImageUrl = imgUrl_1;

            lblAlbumElementID2.Text = slikaID2.ToString();
            lblAlbumElementName2.Text = albumName;
            lblAlbumElementYear2.Text = year.ToString();
            imgAlbumElementPreview2.ImageUrl = imgUrl_2;

            txbAlbumElementNumber1.Text = initElementNumber(slikaID1);
            txbAlbumElementNumber2.Text = initElementNumber(slikaID2);
        }

        private string initElementNumber(int pictureID)
        {
            Database db = new Database();
            int res = db.getQuantity(Session["UserName"].ToString(),
                albumID, pictureID);
            System.Diagnostics.Debug.WriteLine("-->>AlbumID:" + albumID.ToString() 
                + " pictureID:" + pictureID.ToString() + " Q:"+res.ToString());
            if (res >= 0)
            {
                return res.ToString();
            }
            return "0";
        }

        private int slikaID1;
        private string albumName;
        private int year;
        private int albumID;
        private int slikaID2;
        public string imgUrl_1 { get; set; }
        public string imgUrl_2 { get; set; }
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

        protected void btnAlbumElementAdd1_Click(object sender, EventArgs e)
        {
            // TODO: msg's for error or succsess

            int q = -1;
            string username = Session["UserName"].ToString();
            Int32.TryParse(txbAlbumElementNumber1.Text, out q);
            System.Diagnostics.Debug.WriteLine("--btnAlbumElementAdd1_Click: " + q.ToString());
            if (q >= 0)
            {
                bool res = addToPoseduva(username, albumID, slikaID1, q);
                System.Diagnostics.Debug.WriteLine("--btnAlbumElementAdd1_Click: " + res.ToString());

                if (!res)
                {
                    updatePonuda(username, albumID, slikaID1, q);
                }
            }
        }

        protected void btnAlbumElementAdd2_Click(object sender, EventArgs e)
        {
            int q = -1;
            string username = Session["UserName"].ToString();
            Int32.TryParse(txbAlbumElementNumber2.Text, out q);
            System.Diagnostics.Debug.WriteLine("--btnAlbumElementAdd2_Click: " + q.ToString());
            if (q >= 0)
            {
                bool res = addToPoseduva(username, albumID, slikaID2, q);
                System.Diagnostics.Debug.WriteLine("--btnAlbumElementAdd2_Click: " + res.ToString());

                if (!res)
                {
                    updatePonuda(username, albumID, slikaID2, q);
                }
            }
        }

        private bool addToPoseduva(string username, int albumID, int slikaID, int q)
        {
            Database db = new Database();

            return db.addPoseduvaRelation(username, albumID, slikaID, q);
        }
        private bool updatePonuda(string username, int albumID, int slikaID, int q)
        {
            Database db = new Database();

            return db.updatePoseduvaRelation(username, albumID, slikaID, q);
        }
    }
}