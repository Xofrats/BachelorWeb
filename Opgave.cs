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
    
    public partial class Opgave
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Opgave()
        {
            this.OpgaveSpil = new HashSet<OpgaveSpil>();
            this.Elev = new HashSet<Elev>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public string Beskrivelse { get; set; }
        public Nullable<int> ID_Fag { get; set; }
        public Nullable<int> ID_Lærer { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OpgaveSpil> OpgaveSpil { get; set; }
        public virtual Fag Fag { get; set; }
        public virtual Lærer Lærer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elev> Elev { get; set; }
    }
}