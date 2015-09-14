using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class Album1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["init"] = true;
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                if (ViewState["albumName"] == null || ViewState["albumYear"] == null)
                {
                    System.Diagnostics.Debug.WriteLine("TUKA!");
                    return;
                }
                if (!ViewState["albumName"].ToString().Equals(txbChooseAlbumName.Text))
                {
                    ViewState["albumName"] = txbChooseAlbumName.Text;
                }
                if (!ViewState["albumYear"].ToString().Equals(txbChooseAlbumYear.Text))
                {
                    ViewState["albumYear"] = txbChooseAlbumYear.Text;
                }
                txbChooseAlbumName.Text = ViewState["albumName"].ToString();
                txbChooseAlbumYear.Text = ViewState["albumYear"].ToString();
                showAlbumStickers();
            }
            

        }
        protected void LogOut_Click(Object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        
        protected void btnChooseAlbum_Click(object sender, EventArgs e)
        {
            ViewState["albumName"] = txbChooseAlbumName.Text;
            ViewState["albumYear"] = txbChooseAlbumYear.Text;
            System.Diagnostics.Debug.WriteLine(ViewState["albumName"].ToString() + "; " + txbChooseAlbumName.Text);
            System.Diagnostics.Debug.WriteLine(ViewState["albumYear"].ToString() + "; " + txbChooseAlbumYear.Text);
            
            showAlbumStickers();
        }

        private  void clearRepeater(){
            repeaterAlbum.DataSource = null;
            repeaterAlbum.DataBind();
        }
        private void showAlbumStickers()
        {
            clearRepeater();

            string albumName = txbChooseAlbumName.Text;
            int albumYear = -1;
            Int32.TryParse(txbChooseAlbumYear.Text, out albumYear);

            Database db = new Database();
            Album album = db.getAlbumByNameAndYear(albumName, albumYear);

            if (album != null)
            {
                List<Slika> sliki = db.getAllPicturesByAlbumID(album.ID);

                if (sliki != null)
                {
                    int n = sliki.Count;
                    for (int i = 0; i < n; i += 2)
                    {
                        if (n % 2 == 1 && i + 1 == n)
                        {
                            albumElementHalf el = (albumElementHalf)LoadControl("albumElementHalf.ascx");
                            el.AlbumID = album.ID;
                            el.AlbumName = albumName;
                            el.SlikaID = sliki[i].Broj;
                            el.imgUrl = sliki[i].Url;
                            el.Year = albumYear;
                            repeaterAlbum.Controls.Add(el);
                        }
                        else
                        {
                            albumElement el = (albumElement)LoadControl("albumElement.ascx");

                            el.AlbumID = album.ID;
                            el.AlbumName = albumName;
                            el.Year = albumYear;
                            el.SlikaID1 = sliki[i].Broj;
                            el.imgUrl_1 = sliki[i].Url;

                            el.SlikaID2 = sliki[i + 1].Broj;
                            el.imgUrl_2 = sliki[i + 1].Url;

                            repeaterAlbum.Controls.Add(el);
                        }

                    }
                }
            }
        }

        protected void repeaterAlbum_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}