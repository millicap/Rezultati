using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Rezultati.Controllers
{
    public class IgracController : Controller
    {
        // GET: Igrac
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
                    var igraci = context.Igracs.Select(i => new
                    {
                    i.IgracId,
                     i.Ime,
                     i.Prezime,
                     i.DatumRodjenja,
                     i.DrzavaRodjenjaId,
                     i.MjestoRodjenjaId,
                     i.BrojDresa,
                     i.TimId,
                     i.PozicijaId
                   
                    }).ToList();

                    var count = igraci.Count();
                    var records = igraci.OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize).ToList();

                    //Return result to jTable
                    return Json(new { Result = "OK", Records = records, TotalRecordCount = count });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }



        [HttpPost]
        public JsonResult Create(Igrac igrac)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new RezultatiContext())
                {
                    context.Igracs.Add(igrac);
                    context.SaveChanges();
                    return Json(new { Result = "OK", Record = igrac });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Update(Igrac igrac)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new RezultatiContext())
                {
                    Igrac igracUpdate = context.Igracs.Find(igrac.IgracId);

                    igracUpdate.IgracId = igrac.IgracId;
                    igracUpdate.Ime = igrac.Ime;
                    igracUpdate.Prezime = igrac.Prezime;
                    igracUpdate.DatumRodjenja = igrac.DatumRodjenja;
                    igracUpdate.DrzavaRodjenjaId = igrac.DrzavaRodjenjaId;
                    igracUpdate.MjestoRodjenjaId = igrac.MjestoRodjenjaId;
                    igracUpdate.BrojDresa = igrac.BrojDresa;
                    igracUpdate.TimId = igrac.TimId;
                    igracUpdate.PozicijaId = igrac.PozicijaId;
                  
                    context.SaveChanges();
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Delete(int igracId)
        {
            try
            {
                using (var context = new RezultatiContext())
                {

                    context.Igracs.Remove(context.Igracs.Find(igracId));
                    context.SaveChanges();
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        [HttpPost]
        public JsonResult VratiDrzavu()
        {
            try
            {
                using (var context = new RezultatiContext())
                {
                    var drzave = context.Drzavas.Select(d => new
                    {
                        Value = d.DrzavaId,
                        DisplayText = d.Naziv

                    }).ToList();


                    //Return result to jTable
                    return Json(new { Result = "OK", Options = drzave });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        [HttpPost]
        public JsonResult VratiGrad()
        {
            try
            {
                using (var context = new RezultatiContext())
                {
                    var gradovi = context.Grads.Select(g => new
                    {
                        Value = g.GradId,
                        DisplayText = g.Naziv

                    }).ToList();


                    //Return result to jTable
                    return Json(new { Result = "OK", Options = gradovi });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult VratiTim()
        {
            try
            {
                using (var context = new RezultatiContext())
                {
                    var timovi = context.Tims.Select(t => new
                    {
                        Value = t.TimId,
                        DisplayText = t.Naziv

                    }).ToList();


                    //Return result to jTable
                    return Json(new { Result = "OK", Options = timovi });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        [HttpPost]
        public JsonResult VratiPoziciju()
        {
            try
            {
                using (var context = new RezultatiContext())
                {
                    var pozicije = context.Pozicijes.Select(p => new
                    {
                        Value = p.PozicijaId,
                        DisplayText = p.Naziv

                    }).ToList();


                    //Return result to jTable
                    return Json(new { Result = "OK", Options = pozicije });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

    }
}