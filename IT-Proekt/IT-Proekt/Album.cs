using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Proekt
{
    public class Album
    {
        public Album(string name, int year)
        {
            Name = name;
            Year = year;
        }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}