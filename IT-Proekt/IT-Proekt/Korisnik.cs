using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Proekt
{
    public class Korisnik
    {
        public int Type {get; set;}

        public string Name {get; set;}

        public string Username {get; set;}

        public DateTime Birthday {get; set;}

        public int Sex {get; set;}

        public double ThrustLevel { get; set; }
    }
}