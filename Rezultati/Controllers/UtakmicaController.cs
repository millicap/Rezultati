using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Rezultati.Controllers
{
    public class UtakmicaController : Controller
    {
        // GET: Utakmica
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
                    var utakmice = context.Utakmicas.Select(u => new
                    {
                       u.UtakmicaId,
                       u.DatumIgranja,
                       u.KoloId,
                       u.DomaciTimId,
                       u.GostujuciTimId,
                       u.BrojGolovaDomacina,
                       u.BrojGolovaGostujuceg,
                       u.Odigrana

                    }).ToList();

                    var count = utakmice.Count();
                    var records = utakmice.OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize).ToList();

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
        public JsonResult Create(Utakmica utakmica)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new RezultatiContext())
                {
                    context.Utakmicas.Add(utakmica);
                    context.SaveChanges();
                    return Json(new { Result = "OK", Record = utakmica });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Update(Utakmica utakmica)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new RezultatiContext())
                {
                    Utakmica utakmicaUpdate = context.Utakmicas.Find(utakmica.UtakmicaId);

                    utakmicaUpdate.UtakmicaId = utakmica.UtakmicaId;
                    utakmicaUpdate.DatumIgranja = utakmica.DatumIgranja;
                    utakmicaUpdate.KoloId = utakmica.KoloId;
                    utakmicaUpdate.DomaciTimId = utakmica.DomaciTimId;
                    utakmicaUpdate.GostujuciTimId = utakmica.GostujuciTimId;
                    utakmicaUpdate.BrojGolovaDomacina = utakmica.BrojGolovaDomacina;
                    utakmicaUpdate.BrojGolovaGostujuceg = utakmica.BrojGolovaGostujuceg;
                    utakmicaUpdate.Odigrana = utakmica.Odigrana;
               
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
        public JsonResult Delete(int utakmicaId)
        {
            try
            {
                using (var context = new RezultatiContext())
                {

                    context.Utakmicas.Remove(context.Utakmicas.Find(utakmicaId));
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
        public JsonResult VratiKolo()
        {
            try
            {
                using (var context = new RezultatiContext())
                {
                    var kola = context.Koloes.Select(k => new
                    {
                        Value = k.KoloId,
                        DisplayText = k.Naziv

                    }).ToList();


                    //Return result to jTable
                    return Json(new { Result = "OK", Options = kola });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult VratiDomaci()
        {
            try
            {
                using (var context = new RezultatiContext())
                {
                    var domaci = context.Tims.Select(t => new
                    {
                        Value = t.TimId,
                        DisplayText = t.Naziv

                    }).ToList();


                    //Return result to jTable
                    return Json(new { Result = "OK", Options = domaci });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult VratiGosti()
        {
            try
            {
                using (var context = new RezultatiContext())
                {
                    var gosti = context.Tims.Select(t => new
                    {
                        Value = t.TimId,
                        DisplayText = t.Naziv

                    }).ToList();


                    //Return result to jTable
                    return Json(new { Result = "OK", Options = gosti });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


       
    }
}
    
