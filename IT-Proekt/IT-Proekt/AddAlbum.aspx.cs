using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{

    public partial class AddAlbum : System.Web.UI.Page
    {
        Database db;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void setFormInfo()
        {
            lblPictureRatio.Text = String.Format("{0}/{1}",
                ViewState["mom_br_sliki"].ToString(),
                ViewState["br_sliki"].ToString());

            lblAlbumName.Text = String.Format("{0}: {1}", "Album", ViewState["title"]);
            lblAlbumYear.Text = String.Format("{0}: {1}", "Year", ViewState["year"]);
            lblPictureID.Text = String.Format("{0}: {1}", "Picture ID", ViewState["mom_br_sliki"]);
            tbImgName.Text = "";
        }
        protected void btAddAlbum_Click(object sender, EventArgs e)
        {
            bool res = insertAlbumIntoDatabase();
            if (res)
            {
                // TODO: Show successful message
                changeForm();
                setFormInfo();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string imgName = tbImgName.Text.Trim();
            string imgUrl = getPictureUrl();
            if (imgUrl == null)
            {
                imgUrl = ViewState["img"] as String;
            }
            int albumID = (Int32)ViewState["album_id"];
            int pictureID = (Int32)ViewState["mom_br_sliki"];
            bool res = false;
            if (imgUrl != null)
                res = insertPictureIntoDatabase(pictureID, albumID, imgName, imgUrl);
            if (res)
            {
                // If and only if insert picture was succsessful

                ViewState["mom_br_sliki"] = (Int32)ViewState["mom_br_sliki"] + 1;
                if (ViewState["mom_br_sliki"].Equals(ViewState["br_sliki"]))
                {
                    btnNext.Text = "Finish";
                    btnNext.CssClass = "btn btn-success";
                }
                setFormInfo();
            }
            if ((Int32)ViewState["mom_br_sliki"] > (Int32)ViewState["br_sliki"])
            {
                clearViewStates();
                Response.Redirect("~/AddAlbum.aspx");
            }
            imgPrev.ImageUrl = "";
            ViewState["img"] = null;
        }

        private bool insertAlbumIntoDatabase()
        {
            db = new Database();
            int year = 0;
            Int32.TryParse(tbYear.Text, out year);
            int br_sliki = Int32.Parse(user_lic.Text);

            ViewState["year"] = year;
            ViewState["title"] = tbTitle.Text;
            ViewState["br_sliki"] = Int32.Parse(user_lic.Text);
            ViewState["mom_br_sliki"] = 1;

            int albumID = db.addAlbum(tbTitle.Text, year, br_sliki);

            if (albumID >= 0)
            {
                ViewState["album_id"] = albumID;
                return true;
            }
            return false;
        }

        private bool insertPictureIntoDatabase(int pictureID, int albumID, string name, string url)
        {
            db = new Database();
            return db.addSlika(pictureID, albumID, name, url);
        }

        private void clearForm()
        {
            tbYear.Text = "";
            user_lic.Text = "";
            tbTitle.Text = "";
        }
        private void changeForm()
        {
            fAddPicture.Visible = !fAddPicture.Visible;
            fInsertAlbum.Visible = !fInsertAlbum.Visible;
        }
        private void clearViewStates()
        {
            ViewState["year"] = null;
            ViewState["title"] = null;
            ViewState["br_sliki"] = null;
            ViewState["mom_br_sliki"] = null;
            ViewState["img"] = null;
            ViewState["album_id"] = null;
            changeForm();
            clearForm();
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            string url = getPictureUrl();
            if (url == null)
            {
                url = ViewState["img"] as String;
            }

            if (url != null)
            {
                imgPrev.ImageUrl = url;
                ViewState["img"] = url;
                lblTest.Text = url;
            }
            else
            {
                lblTest.Text = "NEMA NISHTO";
            }

        }

        private string getPictureUrl()
        {
            string path = Server.MapPath("Images/");

            if (ImageUpload.HasFile)
            {
                string ext = Path.GetExtension(ImageUpload.FileName);

                if (ext.Equals(".jpg") || ext.Equals(".jpeg") || ext.Equals(".png"))
                {
                    ImageUpload.SaveAs(path + ImageUpload.FileName);
                    string img_name = "~/images/" + ImageUpload.FileName;

                    return img_name;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Invalid format");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No file selected");
            }
            return null;
        }
    }
}