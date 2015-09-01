using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Proekt
{
    public class Korisnik
    {
        public Korisnik(string name, string username, DateTime bday, int sex, int type, double thrustLevel)
        {
            Name = name;
            Username = username;
            Birthday = bday;
            Sex = sex;
            Type = type;
            ThrustLevel = thrustLevel;
        }
        public int Type {get; set;}

        public string Name {get; set;}

        public string Username {get; set;}

        public DateTime Birthday {get; set;}

        public int Sex {get; set;}

        public double ThrustLevel { get; set; }
    }
}