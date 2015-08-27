using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Proekt
{
    public class Slika
    {
        public Slika(int broj, int album_id, int picture_id)
        {
            Broj = broj;
            AlbumID = album_id;
            PictureID = picture_id;
        }
        public int Broj { get; set; }

        public int AlbumID { get; set; }

        public int PictureID { get; set; }
        // TODO: Mozi ovie attr treba da bidat objekti od Album 
    }
}