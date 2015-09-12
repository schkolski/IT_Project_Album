using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Proekt
{
    public class Slika
    {
        public Slika(int broj, int album_id, string url, string name)
        {
            Broj = broj;
            AlbumID = album_id;
            Url = url;
            Name = name;
        }
        public string Name { get; set; }
        public int Broj { get; set; }

        public int AlbumID { get; set; }

        public string Url { get; set; }
        // TODO: Mozi ovie attr treba da bidat objekti od Album 
    }
}