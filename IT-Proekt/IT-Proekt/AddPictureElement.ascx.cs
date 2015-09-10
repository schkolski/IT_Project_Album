using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class AddPictureElement : System.Web.UI.UserControl
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

        private string loadAndSavePicture(FileUpload f){
            string path = Server.MapPath("Images/");
            if (f.HasFile)
            {
                string ext = Path.GetExtension(f.FileName);

                if (ext.Equals(".jpg") || ext.Equals(".jpeg") || ext.Equals(".png"))
                {
                    f.SaveAs(path + f.FileName);
                    string img_name = "~/images/" + f.FileName;

                    //TODO: invoke database insertion (insert or update)
                    //Slika1URL = img_name;
                    return img_name;
                }
                else
                {
                    //lblResponse.Text = "Invalid format";
                }
            }
            else
            {
                //lblResponse.Text = "No file selected";
            }

            return null; 
        }

        protected void FileUploadLeft_DataBinding(object sender, EventArgs e)
        {
            string imgUrl = loadAndSavePicture(FileUploadLeft);
            if (imgUrl != null)
                this.imgAlbumElementPreview1.ImageUrl = imgUrl;
            else
            {
                Response.Write("NULL SLIKA!!!<br/>");
            }
        }

        protected void FileUploadRight_DataBinding(object sender, EventArgs e)
        {
            string imgUrl = loadAndSavePicture(FileUploadRight);
            if (imgUrl != null)
                this.imgAlbumElementPreview2.ImageUrl = imgUrl;
            else
            {
                Response.Write("NULL SLIKA!!!<br/>");
            }
        }
    }
}