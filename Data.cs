//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BachelorWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Data
    {
        public int ID { get; set; }
        public string Tid { get; set; }
        public Nullable<int> ID_Spil { get; set; }
        public Nullable<int> ID_Elev { get; set; }
        public Nullable<int> ID_Gæst { get; set; }
        public Nullable<System.DateTime> Dato { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<bool> Afsluttet { get; set; }
        public Nullable<int> Hints { get; set; }
        public Nullable<int> LastCheckpoint { get; set; }
    
        public virtual Elev Elev { get; set; }
        public virtual Spil Spil { get; set; }
    }
}