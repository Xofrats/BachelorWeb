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
            public IList<VMSpil> VMSpil { get; set; }

            public Nullable<DateTime> DueDate { get; set; }

            public VMOpgaveSpil()
            {
                Title = "";
                Beskrivelse = "";
                VMSpil = new List<VMSpil>();
            }

        }

        public class VMSpil
        {


            public int ID_Spil { get; set; }
            public int ID_Niveau { get; set; }


        }

    }
}