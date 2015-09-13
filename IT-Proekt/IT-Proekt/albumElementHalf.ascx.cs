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
            imgAlbumElementPreview.ImageUrl = imgUrl;

            txbAlbumElementNumber.Text = initElementNumber(slikaID);
        }
        private string initElementNumber(int pictureID)
        {
            Database db = new Database();
            int res = db.getQuantity(Session["UserName"].ToString(),
                albumID, pictureID);

            if (res > 0)
            {
                return res.ToString();
            }
            return "0";
        }
        private int slikaID;
        private string albumName;
        private int year;
        private int albumID;
        public string imgUrl { get; set; }
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

        protected void btnAlbumElementAdd_Click(object sender, EventArgs e)
        {
            int q = -1;
            Int32.TryParse(txbAlbumElementNumber.Text, out q);
            System.Diagnostics.Debug.WriteLine("TUKA SUM BE :)");
            bool res = addToPoseduva(Session["UserName"].ToString(), albumID, slikaID, q);

            if (!res) updatePonuda(Session["UserName"].ToString(), albumID, slikaID, q);
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