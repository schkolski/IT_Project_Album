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
            Database db = new Database();
            List<Slika> sliki = db.getAllPicturesByAlbumID(1);

            //so iskomentiraniot kod se polni stranata so n broj na skili

            //if (sliki != null)
            //{
            //    int n = sliki.Count;
            //    for (int i = 0; i < n / 2; i++)
            //   {
            //        albumElement el = (albumElement)LoadControl("albumElement.ascx");
            //        el.AlbumID = sliki[i].AlbumID;
            //        repeaterAlbum.Controls.Add(el);
            //    }
            //}

            albumElement example1 = (albumElement)LoadControl("albumElement.ascx");
            example1.SlikaID1 = 1;
            example1.AlbumName = "ExampleAlbum";
            example1.AlbumID = 1;
            example1.Year = 2015;
            example1.SlikaID2 = 2;
            repeaterAlbum.Controls.Add(example1); //example 1 - One row. Has 2 album elements.

            albumElementHalf example2 = (albumElementHalf)LoadControl("albumElementHalf.ascx");
            example2.SlikaID = 3;
            example2.AlbumName = "ExampleAlbum";
            example2.AlbumID = 1;
            example2.Year = 2015;
            repeaterAlbum.Controls.Add(example2); //example 2 - one half row. Has 1 album element.
        }
        
    }
}