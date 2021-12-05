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
            public Nullable<int> ID_Lærer { get; set; }
            public Nullable<int> ID_Status { get; set; }
            public Nullable<int> ID_Klasse { get; set; }
            public int ID_Spil { get; set; }
            public int ID_Niveau { get; set; }
            public Nullable<int> Order { get; set; }
        }

	}
}