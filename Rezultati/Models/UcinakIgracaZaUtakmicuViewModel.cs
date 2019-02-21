using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rezultati.Models
{
    public class UcinakIgracaZaUtakmicuViewModel
    {
        public int IgracId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int TimId { get; set; }
        public string NazivTima { get; set; }
        public int GradId { get; set; }
        public string NazivGrada { get; set; }
        public int NazivDrzave { get; set; }
        public byte BrojDresa { get; set; }
        public int PozicijaId { get; set; }
        public string Pozicija { get; set; }
        public int UtakmicaId { get; set; }
        public int BrojOdigranihMinuta { get; set; }
        public int BrojPostignutihGolova { get; set; }
        public int BrojZutihKartona { get; set; }
        public bool CrvenihKarton { get; set; }
    }
}