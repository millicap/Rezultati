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
    
    public partial class UcinakIgraca
    {
        public int UcinakId { get; set; }
        public int UtakmicaId { get; set; }
        public int IgracId { get; set; }
        public byte BrojOdigranihMinuta { get; set; }
        public byte BrojPostignutihGolova { get; set; }
        public byte BrojZutihKartona { get; set; }
        public bool BrojCrvenihKartona { get; set; }
    
        public virtual Igrac Igrac { get; set; }
        public virtual Utakmica Utakmica { get; set; }
    }
}
