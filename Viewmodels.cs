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
            public string Title { get; set; }
            public string Beskrivelse { get; set; }
            public Nullable<int> ID_Fag { get; set; }
            public int ID_Lærer { get; set; }
            public Nullable<int> ID_Klasse { get; set; }
            public List<int> ID_Spil { get; set; }
            public List<int> ID_Niveau { get; set; }

            public VMOpgaveSpil()
            {
                Title = "";
                Beskrivelse = "";
                ID_Spil = new List<int>();
                ID_Niveau = new List<int>();
            }
        }

    }
}