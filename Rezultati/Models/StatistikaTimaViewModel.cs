using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rezultati.Models
{
    public class StatistikaTimaViewModel
    {
        public int TimId { get; set; }
        [Display(Name ="Tim")]
        public string TimNaziv { get; set; }
        [Display(Name = "Broj pobjeda")]
        public int BrojPobjeda { get; set; }
        [Display(Name = "Broj poraza")]
        public int BrojPoraza { get; set; }
        [Display(Name = "Broj nerijesenih")]
        public int BrojNerijesenih { get; set; }
        [Display(Name = "Broj datih golova")]
        public int BrojDatihGolova { get; set; }
        [Display(Name = "Broj primljenih golova")]
        public int BrojPrimljenihGolova { get; set; }
        public int GolRazlika
        {
            get
            {
                return BrojDatihGolova - BrojPrimljenihGolova;
            }
        }
        [Display(Name = "Ukupan broj bodova")]
        public int UkupanBrojBodova
        {
            get
            {
                return BrojPobjeda* 3 + BrojNerijesenih;
            }
        }

        public string GolRazlikaIspis
        {
            get { return BrojDatihGolova + " : " + BrojPrimljenihGolova + "(" + GolRazlika + ")"; }
        }

    }
}