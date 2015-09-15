using System;
using System.Collections.Generic;
using System.Data;
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
        [WebMethod]
        public bool isAdmin(String username) {
            db = new Database();
            Korisnik k = db.getUserInfoByUsername(username);
            return k.Type == 0;
        }
        [WebMethod]
        public int[] getPercentOfPicturesOnOffer() //rezultat vo format 
        {                                          //broj Sliki na ponuda, broj Sliki preostanati 
            db = new Database();
            List<Slika> slikiVoPonuda = db.getSiteSlikaVoPonuda();
            List<Slika> sliki = db.getAllPictures();

            int brSlikiVoPonuda = slikiVoPonuda.Count;
            int brSliki = sliki.Count - brSlikiVoPonuda;

            int[] rezultat = { brSlikiVoPonuda, brSliki };

            return rezultat;
        }

        [WebMethod]
        public DataTable getNajmnoguBrojPonudiVoDen()
        {
            db = new Database();

            return db.getNajmnoguBrojPonudiVoDen();
        }

        public Slika getNajprodavanaSlika()
        {
            db = new Database();

            return db.getNajprodavanaSlika();
        }

        public Slika getNajskapoProdadenaSlika()
        {
            db = new Database();

            return db.getNajskapoProdadenaSlika();
        }

        public int[] getAllTransakciiByStatus() //rezultat vo format 
        {                                       //sliki so status=1, status=2, status=3
            db = new Database();

            List<Slika> status1 = db.getAllTransakciiByStatus(1);
            List<Slika> status2 = db.getAllTransakciiByStatus(2);
            List<Slika> status3 = db.getAllTransakciiByStatus(3);

            if (status1 != null && status2 != null && status3 != null)
            {
                int[] rezultat = { status1.Count, status2.Count, status3.Count };
                return rezultat;
            }

            int[] rez = { 1, 0, 0 }; //kolku da ne bide prazna pitata
            return rez;
        }

        public Korisnik getUserNajmnoguPotroshil()
        {
            db = new Database();

            return db.getUserNajmnoguPotroshil();
        }
    }
}
