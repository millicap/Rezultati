using Rezultati.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Rezultati.Controllers
{
    public class RasporedUtakmicaController : Controller
    {
        // GET: RasporedUtakmica
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

                return PartialView("_PrikazUtakmica", ListaUtakmica);
            }
        }

        public ActionResult Details(string id)
        {
            int utakmicaId = Convert.ToInt32(id);
            using (var context = new RezultatiContext())
            {
                Utakmica utakmica = context.Utakmicas.Where(u => u.UtakmicaId == utakmicaId).FirstOrDefault();
                DetaljiUtakmiceViewModel utakmicaVM = new DetaljiUtakmiceViewModel()
                {
                    UtakmicaId = utakmica.UtakmicaId,
                    DatumIgranja = utakmica.DatumIgranja,
                    GradId = utakmica.Tim.GradId,
                    GradNaziv = utakmica.Tim.Grad.Naziv,
                    Stadion = utakmica.Tim.Stadion,
                    DomaciTimId = utakmica.DomaciTimId,
                    DomaciNaziv = utakmica.Tim.Naziv,
                    GostujuciTimId = utakmica.TimGost.TimId,
                    GostujuciNaziv = utakmica.TimGost.Naziv,
                    GoloviDomacina = utakmica.BrojGolovaDomacina,
                    GoloviGosta = utakmica.BrojGolovaGostujuceg,
                    TrenerDomacih = utakmica.Tim.ImeTrenera + " " + utakmica.Tim.PrezimeTrenera,
                    TrenerGostujucih = utakmica.TimGost.ImeTrenera + " " + utakmica.TimGost.PrezimeTrenera,

                    DomaciIgraci = utakmica.Tim.Igracs.Select(i => new UcinakIgracaZaUtakmicuViewModel
                    {
                        IgracId = i.IgracId,
                        UtakmicaId = utakmica.UtakmicaId,
                        Ime = i.Ime,
                        Prezime = i.Prezime,
                        Pozicija = i.Pozicije.Naziv,
                        BrojDresa = i.BrojDresa,
                        BrojOdigranihMinuta = i.UcinakIgracas.FirstOrDefault(j => j.UtakmicaId == utakmica.UtakmicaId).BrojOdigranihMinuta,
                        //BrojOdigranihMinuta = i.UcinakIgracas.Where(j => j.IgracId == i.IgracId && j.UtakmicaId == utakmica.UtakmicaId).Select(u => u.BrojOdigranihMinuta).FirstOrDefault(),
                        //BrojOdigranihMinuta = i.UcinakIgracas.Where(j => j.IgracId == i.IgracId && j.UtakmicaId == utakmica.UtakmicaId).Select(u => u.BrojOdigranihMinuta).FirstOrDefault(),
                        BrojPostignutihGolova = i.UcinakIgracas.Where(j => j.IgracId == i.IgracId && j.UtakmicaId == utakmica.UtakmicaId).Select(u => u.BrojPostignutihGolova).FirstOrDefault(),
                        BrojZutihKartona = i.UcinakIgracas.Where(j => j.IgracId == i.IgracId && j.UtakmicaId == utakmica.UtakmicaId).Select(u => u.BrojZutihKartona).FirstOrDefault(),
                        CrvenihKarton = i.UcinakIgracas.Where(j => j.IgracId == i.IgracId && j.UtakmicaId == utakmica.UtakmicaId).Select(u => u.BrojCrvenihKartona).FirstOrDefault()

                    }).ToList(),

                    GostijuciIgraci = utakmica.TimGost.Igracs.Select(i => new UcinakIgracaZaUtakmicuViewModel
                    {
                        IgracId = i.IgracId,
                        UtakmicaId = utakmica.UtakmicaId,
                        Ime = i.Ime,
                        Prezime = i.Prezime,
                        Pozicija = i.Pozicije.Naziv,
                        BrojDresa = i.BrojDresa,
                        BrojOdigranihMinuta = i.UcinakIgracas.Where(j => j.IgracId == i.IgracId && j.UtakmicaId == utakmica.UtakmicaId).Select(u => u.BrojOdigranihMinuta).FirstOrDefault(),
                        BrojPostignutihGolova = i.UcinakIgracas.Where(j => j.IgracId == i.IgracId && j.UtakmicaId == utakmica.UtakmicaId).Select(u => u.BrojPostignutihGolova).FirstOrDefault(),
                        BrojZutihKartona = i.UcinakIgracas.Where(j => j.IgracId == i.IgracId && j.UtakmicaId == utakmica.UtakmicaId).Select(u => u.BrojZutihKartona).FirstOrDefault(),
                        CrvenihKarton = i.UcinakIgracas.Where(j => j.IgracId == i.IgracId && j.UtakmicaId == utakmica.UtakmicaId).Select(u => u.BrojCrvenihKartona).FirstOrDefault()
                    }).ToList()
                };
                return View(utakmicaVM);
            }
        }

       /* [HttpPost]
        public JsonResult UnosUcinka(UcinakIgracaZaUtakmicuViewModel data)
        {
            bool success = true;
            try
            {
                using (var context = new RezultatiContext())
                {
                    var ucinak = new UcinakIgraca()
                    {
                        UtakmicaId = data.UtakmicaId,
                        IgracId = data.IgracId,
                        BrojOdigranihMinuta = (byte)data.BrojOdigranihMinuta,
                        BrojPostignutihGolova = (byte)data.BrojPostignutihGolova,
                        BrojZutihKartona = (byte)data.BrojZutihKartona,
                        BrojCrvenihKartona = data.CrvenihKarton
                    };

                    context.UcinakIgracas.Add(ucinak);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                success = false;
            }
            return Json(success);
        }*/


        [HttpPost]
        public JsonResult UnosUcinka(UcinakIgracaZaUtakmicuViewModel data)
        {
            bool succses = true;
            string Message = "";
            try
            {
                using (var context = new RezultatiContext())
                {
                    int postoji = context.UcinakIgracas.Count(ui => ui.IgracId == data.IgracId && ui.UtakmicaId == data.UtakmicaId);
                    if (postoji == 0)
                    {
                        var ucinak = new UcinakIgraca()
                        {
                            UtakmicaId = data.UtakmicaId,
                            IgracId = data.IgracId,
                            BrojOdigranihMinuta = (byte)data.BrojOdigranihMinuta,
                            BrojPostignutihGolova = (byte)data.BrojPostignutihGolova,
                            BrojZutihKartona = (byte)data.BrojZutihKartona,
                            BrojCrvenihKartona = data.CrvenihKarton
                        };

                        context.UcinakIgracas.Add(ucinak);
                        context.SaveChanges();
                    }
                    else
                    {
                        var ucinak = context.UcinakIgracas.FirstOrDefault(ui => ui.IgracId == data.IgracId && ui.UtakmicaId == data.UtakmicaId);
                        ucinak.BrojOdigranihMinuta = (byte)data.BrojOdigranihMinuta;
                        ucinak.BrojPostignutihGolova = (byte)data.BrojPostignutihGolova;
                        ucinak.BrojZutihKartona = (byte)data.BrojZutihKartona;
                        ucinak.BrojCrvenihKartona = data.CrvenihKarton;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                succses = false;
                Message = e.Message;

            }
            return Json(new { succses, Message });
        }

        public ActionResult VratiPodatkeOIgracu(string id)
        {

            int igracId = Convert.ToInt32(id);
            using (var context = new RezultatiContext())
            {
                Igrac igrac = context.Igracs.Where(i => i.IgracId == igracId).FirstOrDefault();
                IgracViewModel igracVM = new IgracViewModel()
                {
                    IgracId = igrac.IgracId,
                    Ime = igrac.Ime,
                    Prezime = igrac.Prezime,
                    DatumRodjenja = igrac.DatumRodjenja,
                    NazivDrzave = igrac.Drzava.Naziv,
                    NazivGrada = igrac.Grad.Naziv,
                    NazivTima = igrac.Tim.Naziv,
                    BrojDresa = igrac.BrojDresa,
                    Pozicija = igrac.Pozicije.Naziv,
                    BrojPostignutihGolova = igrac.UcinakIgracas.Where(i => i.IgracId == igrac.IgracId).Sum(u => u.BrojPostignutihGolova),
                    BrojZutihKartona = igrac.UcinakIgracas.Where(i => i.IgracId == igrac.IgracId).Sum(u => u.BrojZutihKartona),
                    BrojCrvenihKartona = igrac.UcinakIgracas.Where(i => i.IgracId == igrac.IgracId && i.BrojCrvenihKartona == true).Count(),
                    ProsjekOdigranihMinuta = igrac.UcinakIgracas.Where(i => i.IgracId == igrac.IgracId).Sum(u => u.BrojOdigranihMinuta)

                };
                return View(igracVM);

            }
        }
    }
}