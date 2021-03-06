﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Proekt
{
    public class Ponuda
    {
        public Ponuda(int id, string desc, int price, string name, int album_id,
            int br_slika, string username, int exchange, DateTime datum)
        {
            ID = id;
            Desc = desc;
            Price = price;
            Name = name;
            AlbumID = album_id;
            BrojSlika = br_slika;
            Username = username;
            Exchange = exchange;
            Datum = datum;
        }

        public const string 
            DATE = "datum",
            PRICE = "price",
            NAME = "name";
        
        public int ID { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }

        public string Name { get; set; }

        public int AlbumID { get; set; }

        public int BrojSlika { get; set; }

        public string Username { get; set; }

        public int Exchange { get; set; }
        public DateTime Datum { get; set; }
    }
}