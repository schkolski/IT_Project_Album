using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Proekt
{
    public class Transakcija
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public DateTime Datum { get; set; }
        public int Status { get; set; }
        public int AlbumID { get; set; }
        public int PictureID { get; set; }

        public Transakcija(int id, string username, DateTime datum, int status)
        {
            ID = id;
            Username = username;
            Datum = datum;
            Status = status;
            AlbumID = -1;
            PictureID = -1;
        }
        public Transakcija(int id, string username, DateTime datum, int status, int album_id, int picture_id)
        {
            ID = id;
            Username = username;
            Datum = datum;
            Status = status;
            AlbumID = album_id;
            PictureID = picture_id;
        }
    }
}