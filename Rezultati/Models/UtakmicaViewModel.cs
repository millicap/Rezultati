using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rezultati.Models
{
    public class UtakmicaViewModel
    {
        public int UtakmicaId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum igranja")]
        public DateTime DatumIgranja { get; set; }
        public int KoloId { get; set; }
        [Display(Name = "Kolo")]
        public string KoloNaziv { get; set; }
        public int DomaciTimId { get; set; }
        [Display(Name ="Domaci tim")]
        public string DomaciNaziv { get; set; }
        public int GostujuciTimId { get; set; }
        [Display(Name = "Gostujuci tim")]
        public string GostujuciNaziv { get; set; }
        public int? BrojGolovaDomacina { get; set; }
        public int? BrojGolovaGostujuceg { get; set; }
        public bool Odigrana { get; set; }
                                           /* [Display(Name ="Konacan rezultat")]
                                            public string KonacanRezultat { get; set; }*/


    }
}