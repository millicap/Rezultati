using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rezultati.Models
{
    public class IgracViewModel
    {
        public int IgracId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display (Name ="Datum rodjenja")]
        public DateTime DatumRodjenja { get; set; }
        public int TimId { get; set; }
        [Display(Name ="Tim")]
        public string NazivTima { get; set; }
        public int GradId { get; set; }
        [Display(Name ="Grad rodjenja")]
        public string NazivGrada { get; set; }
        
        public int DrzavaId { get; set; }
        [Display(Name = "Drzava rodjenja")]
        public string NazivDrzave { get; set; }
        [Display(Name ="Broj dresa")]
        public byte BrojDresa { get; set; }
        public int PozicijaId { get; set; }
        public string Pozicija { get; set; }
        [Display(Name ="Prosjek odigranih minuta")]
        public int ProsjekOdigranihMinuta { get; set; }
        [Display(Name = "Broj postignutih golova")]
        public int BrojPostignutihGolova { get; set; }
        [Display(Name = "Broj zutih kartona")]
        public int BrojZutihKartona { get; set; }
        [Display(Name = "Broj crvenih kartona")]
        public int BrojCrvenihKartona { get; set; }

        //public List<string> Top5NajboljihStrijelaca { get; set; }

    }
}