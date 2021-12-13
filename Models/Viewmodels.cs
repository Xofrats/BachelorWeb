using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BachelorWeb
{
    public class Viewmodels
    {
        public class VMOpgaveSpil
        {
            //Skal i opgave tabellen
            public string Title { get; set; }
            public string Beskrivelse { get; set; }
            public Nullable<int> ID_Fag { get; set; }
            public int ID_Lærer { get; set; }
            public Nullable<int> ID_Klasse { get; set; }          

            public Nullable<DateTime> DueDate { get; set; }

            //Skal i OpgaveSpil tabellen
            public IList<VMSpil> VMSpil { get; set; }


            public VMOpgaveSpil()
            {
                Title = "";
                Beskrivelse = "";
                VMSpil = new List<VMSpil>();
            }

        }

        public class VMResult
        {
            //Skal i opgave tabellen
            public string Title { get; set; }
            public string Beskrivelse { get; set; }
            public int ID_Fag { get; set; }
            public int ID_Klasse { get; set; }
            public DateTime DueDate { get; set; }

            public int ID_opgave { get; set; }
        }

        public class VMSpil
        {


            public int ID_Spil { get; set; }
            public int ID_Niveau { get; set; }


        }

    }
}