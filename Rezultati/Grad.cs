//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rezultati
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grad()
        {
            this.Igracs = new HashSet<Igrac>();
            this.Tims = new HashSet<Tim>();
        }
    
        public int GradId { get; set; }
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
    
        public virtual Drzava Drzava { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Igrac> Igracs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tim> Tims { get; set; }
    }
}
