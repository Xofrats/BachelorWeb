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
    
    public partial class Lærer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lærer()
        {
            this.Fag = new HashSet<Fag>();
            this.Klasse = new HashSet<Klasse>();
            this.Opgave = new HashSet<Opgave>();
        }
    
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public Nullable<System.DateTime> DoB { get; set; }
        public string Køn { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fag> Fag { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Klasse> Klasse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Opgave> Opgave { get; set; }
    }
}
