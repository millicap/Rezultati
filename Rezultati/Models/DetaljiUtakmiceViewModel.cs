using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rezultati.Models
{
    public class DetaljiUtakmiceViewModel
    {
        public int UtakmicaId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum igranja")]
        public DateTime DatumIgranja { get; set; }
        public int GradId { get; set; }
        [Display(Name = "Grad")]
        public string GradNaziv { get; set; }
        public string Stadion { get; set; }
        public int KoloId { get; set; }
        [Display(Name = "Kolo")]
        public string NazivKola { get; set; }
        public int DomaciTimId { get; set; }
        [Display(Name ="Domaci")]
        public string DomaciNaziv { get; set; }
        public int GostujuciTimId { get; set; }
        [Display(Name = "Gosti")]
        public string GostujuciNaziv { get; set; }
        [Display(Name = "Golovi domacina")]
        public int? GoloviDomacina { get; set; }
        [Display(Name = "Golovi gosta")]
        public int? GoloviGosta { get; set; }
        [Display(Name = "Konacan rezultat")]
        public string KonacanRezultat { get { return GoloviDomacina + "-" + GoloviGosta; } }
        public List<UcinakIgracaZaUtakmicuViewModel> DomaciIgraci { get; set; }
        public string TrenerDomacih { get; set; }
        public List<UcinakIgracaZaUtakmicuViewModel> GostijuciIgraci { get; set; }
        public string TrenerGostujucih { get; set; }
        public bool Odrzana { get; set; }

    }
}