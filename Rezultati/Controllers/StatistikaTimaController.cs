using Rezultati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Rezultati.Controllers
{
    public class StatistikaTimaController : Controller
    {
        // GET: StatistikaTima
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                using (var context = new RezultatiContext())
                {
                    var timovi = context.Tims.ToList().Select(t => new StatistikaTimaViewModel
                    {
                        TimId = t.TimId,
                        TimNaziv = t.Naziv,
                        BrojPobjeda = context.Utakmicas.Where(u => u.DomaciTimId == t.TimId && u.BrojGolovaDomacina > u.BrojGolovaGostujuceg).Count() +
                                      context.Utakmicas.Where(u => u.GostujuciTimId == t.TimId && u.BrojGolovaDomacina < u.BrojGolovaGostujuceg).Count(),
                        BrojPoraza = context.Utakmicas.Where(u => u.DomaciTimId == t.TimId && u.BrojGolovaDomacina < u.BrojGolovaGostujuceg).Count() +
                                    context.Utakmicas.Where(u => u.GostujuciTimId == t.TimId && u.BrojGolovaDomacina > u.BrojGolovaGostujuceg).Count(),
                        BrojNerijesenih = context.Utakmicas.Where(u => (u.DomaciTimId == t.TimId || u.GostujuciTimId == t.TimId) && u.BrojGolovaDomacina == u.BrojGolovaGostujuceg && u.Odigrana==true).Count(),
                        BrojDatihGolova = Convert.ToInt16(context.Utakmicas.Where(u => u.DomaciTimId == t.TimId).Sum(u1 => u1.BrojGolovaDomacina)) +
                                               Convert.ToInt16(context.Utakmicas.Where(u => u.GostujuciTimId == t.TimId).Sum(u1 => u1.BrojGolovaGostujuceg)),
                        BrojPrimljenihGolova = Convert.ToInt16(context.Utakmicas.Where(u => u.DomaciTimId == t.TimId).Sum(u1 => u1.BrojGolovaGostujuceg)) +
                                                Convert.ToInt16(context.Utakmicas.Where(u => u.GostujuciTimId == t.TimId).Sum(u1 => u1.BrojGolovaDomacina)),
                        
                    }).ToList();

                    var count = timovi.Count();
                    var records = timovi.OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize).ToList();

                  //Return result to jTable
                    return Json(new { Result = "OK", Records = records, TotalRecordCount = count });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult Top5Strijelaca(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                using (var context = new RezultatiContext())
                {

                    //var igraci = context.Igracs.ToList().Select(i => new IgracViewModel
                    //{

                    //    IgracId = i.IgracId,
                    //    Ime = i.Ime,
                    //    Prezime = i.Prezime,
                    //    TimId = i.TimId,
                    //    NazivTima=i.Tim.Naziv,   
                    //    BrojPostignutihGolova = context.UcinakIgracas.Where(u => u.IgracId == i.IgracId ).Sum(u1 => u1.BrojPostignutihGolova)
                    //});

                    var igraciSaUcinkom = context.UcinakIgracas.Where(u => context.Igracs.FirstOrDefault(i => i.IgracId == u.IgracId) != null).Select(uc=>uc.Igrac);
                    var ucinciIgraca = igraciSaUcinkom.Select(i => new IgracViewModel
                    {
                        IgracId = i.IgracId,
                        Ime = i.Ime,
                        Prezime = i.Prezime,
                        TimId = i.TimId,
                        NazivTima = i.Tim.Naziv,
                        BrojPostignutihGolova = context.UcinakIgracas.Where(u => u.IgracId == i.IgracId).Sum(u1 => u1.BrojPostignutihGolova)
                    }).Distinct() .ToList();

                    ucinciIgraca = ucinciIgraca.OrderByDescending(i => i.BrojPostignutihGolova).Take(5).ToList();
                    var records = ucinciIgraca.OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize).ToList();

                    return Json(new { Result = "OK", Records = records, TotalRecordCount = 5 });
                }

            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }

        }

    }
}