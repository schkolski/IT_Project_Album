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
        public String []niza;
        public String []godini;
        public ServiceReference1.WebService1 ab;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillNames();
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
                if (!ViewState["albumName"].ToString().Equals(ddName.SelectedItem.Text.ToString()))
                {
                    ViewState["albumName"] = ddName.SelectedItem.Text.ToString();
                }
                if (!ViewState["albumYear"].ToString().Equals(ddYear.SelectedItem.Text.ToString()))
                {
                    ViewState["albumYear"] = ddYear.SelectedItem.Text.ToString();
                }
                ddName.SelectedItem.Text = ViewState["albumName"].ToString();
                ddYear.SelectedItem.Text = ViewState["albumYear"].ToString();
                showAlbumStickers();
            }

           
        }
        public void fillNames()
        {
            
            ab = new ServiceReference1.WebService1();
            niza = ab.getAlbumNames();
            
            ddName.DataSource = niza;
            ddName.DataBind();
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
            ViewState["albumName"] = ddName.SelectedItem.Text.ToString();
            ViewState["albumYear"] = ddYear.SelectedItem.Text.ToString();
            System.Diagnostics.Debug.WriteLine(ViewState["albumName"].ToString() + "; " + ddName.SelectedItem.Text.ToString());
            System.Diagnostics.Debug.WriteLine(ViewState["albumYear"].ToString() + "; " + ddYear.SelectedItem.Text.ToString());
            
            showAlbumStickers();
        }

        private  void clearRepeater(){
            repeaterAlbum.DataSource = null;
            repeaterAlbum.DataBind();
        }
        private void showAlbumStickers()
        {
            clearRepeater();

            string albumName = ddName.SelectedItem.Text.ToString();
            int albumYear = -1;
            Int32.TryParse(ddYear.SelectedItem.Text.ToString(), out albumYear);

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

        protected void txbChooseAlbumName_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected void ddName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ab = new ServiceReference1.WebService1();
            System.Diagnostics.Debug.Write("Ovdeka vleguva");
            if(ddName.SelectedIndex != -1)
            {
                godini = ab.getAlbumYearByName(ddName.SelectedItem.Text.ToString());
                ddYear.DataSource = godini;
                ddYear.DataBind();
            }
        }
    }
}