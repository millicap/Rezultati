using Rezultati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rezultati.Controllers
{
    public class UnosRezultataController : Controller
    {
        // GET: UnosRezultata
        public ActionResult Index()
        {

            using (var context = new RezultatiContext())
            {
                ViewBag.Kola = context.Koloes.Select(i => new SelectListItem
                {
                    Text = i.Naziv,
                    Value = i.KoloId.ToString()
                }).ToList();
                return View();
            }          
        }

        public ActionResult VratiUtakmiceZaKolo(int id)
        {
            using (var context = new RezultatiContext())
            {
                List<UtakmicaViewModel> ListaUtakmica = new List<UtakmicaViewModel>();
                ListaUtakmica = context.Utakmicas.Where(u => u.KoloId == id).Select(ut => new UtakmicaViewModel
                {
                    UtakmicaId = ut.UtakmicaId,
                    DatumIgranja = ut.DatumIgranja,
                    DomaciTimId = ut.DomaciTimId,
                    DomaciNaziv = ut.Tim.Naziv,
                    GostujuciTimId = ut.GostujuciTimId,
                    GostujuciNaziv = ut.TimGost.Naziv,
                    BrojGolovaDomacina = ut.BrojGolovaDomacina,
                    BrojGolovaGostujuceg = ut.BrojGolovaGostujuceg,
                    Odigrana = ut.Odigrana
                }).ToList();

                return PartialView("_VratiUtakmiceZaKolo", ListaUtakmica);
            }
        }

        public ActionResult Edit(string id)
        {
            int utakmicaId = Convert.ToInt32(id);

            using (var context = new RezultatiContext())
            {
                Utakmica utakmica = context.Utakmicas.Where(u => u.UtakmicaId == utakmicaId).FirstOrDefault();
                UtakmicaViewModel utakmicaVM = new UtakmicaViewModel()
                {
                   UtakmicaId = utakmica.UtakmicaId,
                   DomaciTimId = utakmica.DomaciTimId,
                   DatumIgranja = utakmica.DatumIgranja,
                   KoloId = utakmica.KoloId,                
                   DomaciNaziv = utakmica.Tim.Naziv,
                   GostujuciTimId = utakmica.GostujuciTimId,
                   GostujuciNaziv = utakmica.TimGost.Naziv,
                   BrojGolovaDomacina = utakmica.BrojGolovaDomacina,
                   BrojGolovaGostujuceg = utakmica.BrojGolovaGostujuceg,
                   Odigrana = utakmica.Odigrana
                  
                };

                return View(utakmicaVM);
            }
        }

        [HttpPost]
        public ActionResult Edit(UtakmicaViewModel utakmica)
        {
            using (var context = new RezultatiContext())
            {
                Utakmica utak = context.Utakmicas.Find(utakmica.UtakmicaId);

                utak.UtakmicaId = utakmica.UtakmicaId;
                utak.DomaciTimId = utakmica.DomaciTimId;
                utak.DatumIgranja = utakmica.DatumIgranja;
                utak.KoloId = utakmica.KoloId;
                utak.DomaciTimId = utakmica.DomaciTimId;
                utak.Tim.Naziv = utakmica.DomaciNaziv;
                utak.GostujuciTimId = utakmica.GostujuciTimId;
                utak.TimGost.Naziv = utakmica.GostujuciNaziv;

                utak.BrojGolovaDomacina = utakmica.BrojGolovaDomacina;
                utak.BrojGolovaGostujuceg = utakmica.BrojGolovaGostujuceg;
                utak.Odigrana = utakmica.Odigrana;
               
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}