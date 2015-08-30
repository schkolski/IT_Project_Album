using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Proekt
{
    public class Album
    {
        public Album(int id, string name, int year)
        {
            ID = id;
            Name = name;
            Year = year;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}