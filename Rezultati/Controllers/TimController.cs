using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Rezultati.Controllers
{
    public class TimController : Controller
    {
        // GET: Tim
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
                    var timovi = context.Tims.Select(t => new
                    {
                        t.TimId,
                        t.Naziv,
                        t.ImeTrenera,
                        t.PrezimeTrenera,
                        t.GradId,
                        t.Stadion
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

        [HttpPost]
        public JsonResult Create(Tim tim)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new RezultatiContext())
                {
                    context.Tims.Add(tim);
                    context.SaveChanges();
                    return Json(new { Result = "OK", Record = tim });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Update(Tim tim)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new RezultatiContext())
                {
                    Tim timUpdate = context.Tims.Find(tim.TimId);

                    timUpdate.TimId = tim.TimId;
                    timUpdate.Naziv = tim.Naziv;

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
        public JsonResult Delete(int timId)
        {
            try
            {
                using (var context = new RezultatiContext())
                {

                    context.Tims.Remove(context.Tims.Find(timId));
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
        public JsonResult GetCityOptions()
        {
            try
            {
                using (var context = new RezultatiContext())
                {
                    var gradovi = context.Grads.Select(g => new
                    {
                       Value =  g.GradId,
                       DisplayText = g.Naziv
                       
                    }).ToList();
              
                    //Return result to jTable
                    return Json(new { Result = "OK", Options = gradovi});
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }



       

    }
}