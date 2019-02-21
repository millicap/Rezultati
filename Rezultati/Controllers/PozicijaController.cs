using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Rezultati.Controllers
{
    public class PozicijaController : Controller
    {
        // GET: Pozicija
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
                    var pozicije = context.Pozicijes.Select(p => new
                    {
                        p.PozicijaId,
                        p.Naziv
                    }).ToList();

                    var count = pozicije.Count();
                    var records = pozicije.OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize).ToList();

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
        public JsonResult Create(Pozicije pozicija)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new RezultatiContext())
                {
                    context.Pozicijes.Add(pozicija);
                    context.SaveChanges();
                    return Json(new { Result = "OK", Record = pozicija });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Update(Pozicije pozicija)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new RezultatiContext())
                {
                    Pozicije pozicijaUpdate = context.Pozicijes.Find(pozicija.PozicijaId);

                    pozicijaUpdate.PozicijaId = pozicija.PozicijaId;
                    pozicijaUpdate.Naziv = pozicija.Naziv;

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
        public JsonResult Delete(int pozicijaId)
        {
            try
            {
                using (var context = new RezultatiContext())
                {

                    context.Pozicijes.Remove(context.Pozicijes.Find(pozicijaId));
                    context.SaveChanges();
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}