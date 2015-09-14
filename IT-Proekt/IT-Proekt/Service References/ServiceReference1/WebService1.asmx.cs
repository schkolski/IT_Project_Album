using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace IT_Proekt.ServiceReference1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        Database db;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public String[] getAllUsers()
        {
            db = new Database();
            List<Korisnik> korisnici = db.getAllUser();
            String[] niza = new String[korisnici.Count];
            int i = 0;
            foreach (Korisnik temp in korisnici)
            {
                niza[i++] = temp.Username.ToString();
            }
            return niza;
        }
        [WebMethod]
        public String [] getAlbumNames()
        {
            db = new Database();
            List<Album> niza = db.getAllAlbumsNames();
            String [] album = new String [niza.Count+1];
            int i = 1;
            album[0] = "Izberete album";
            foreach (Album temp in niza)
            {
                album[i++] = temp.Name;
            }

            return album;
        }
        [WebMethod]
        public String [] getAlbumYearByName(String name)
        {
            db = new Database();
            List<Album> albums = db.getAlbumByName(name);
            String[] godini = new String[albums.Count];
            int i = 0;
            foreach (Album temp in albums)
            {
                godini[i++]=temp.Year.ToString();
                
            }
            return godini;
        }
    }
}
