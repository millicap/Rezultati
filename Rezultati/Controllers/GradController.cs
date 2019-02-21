using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Rezultati.Controllers
{
    public class GradController : Controller
    {
        // GET: Grad
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
                    var gradovi = context.Grads.Select(g => new
                    {
                        g.GradId,
                        g.DrzavaId,
                        g.Naziv
                    }).ToList();

                    var count = gradovi.Count();
                    var records = gradovi.OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize).ToList();

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
        public JsonResult Create(Grad grad)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new RezultatiContext())
                {
                    context.Grads.Add(grad);
                    context.SaveChanges();
                    return Json(new { Result = "OK", Record = grad });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Update(Grad grad)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                using (var context = new RezultatiContext())
                {
                    Grad gradUpdate = context.Grads.Find(grad.GradId);

                    gradUpdate.GradId = grad.GradId;
                    gradUpdate.DrzavaId = grad.DrzavaId;
                    gradUpdate.Naziv = grad.Naziv;

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
        public JsonResult Delete(int gradId)
        {
            try
            {
                using (var context = new RezultatiContext())
                {

                    context.Grads.Remove(context.Grads.Find(gradId));
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
        public JsonResult Drzava()
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


    }
}