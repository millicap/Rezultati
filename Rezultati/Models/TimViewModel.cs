using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rezultati.Models
{
    public class TimViewModel
    {
        public int TimId { get; set; }
        public string TimNaziv { get; set; }
        [Display(Name ="Ime trenera" )]
        public string ImeTrenera { get; set; }
        [Display(Name = "Prezime trenera")]
        public string PrezimeTrenera { get; set; }
        public int GradId { get; set; }
        [Display(Name = "Grad")]
        public string GradNaziv { get; set; }
        public string Stadion { get; set; }
    }
}