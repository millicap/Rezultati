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
    
    public partial class Tim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tim()
        {
            this.Igracs = new HashSet<Igrac>();
            this.Utakmicas = new HashSet<Utakmica>();
            this.UtakmicasGost = new HashSet<Utakmica>();
        }
    
        public int TimId { get; set; }
        public string Naziv { get; set; }
        public string ImeTrenera { get; set; }
        public string PrezimeTrenera { get; set; }
        public int GradId { get; set; }
        public string Stadion { get; set; }
    
        public virtual Grad Grad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Igrac> Igracs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utakmica> Utakmicas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utakmica> UtakmicasGost { get; set; }
    }
}
