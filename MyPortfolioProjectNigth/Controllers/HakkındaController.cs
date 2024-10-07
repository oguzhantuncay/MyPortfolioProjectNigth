using MyPortfolioProjectNigth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioProjectNigth.Controllers
{
    public class HakkındaController : Controller
    {
        // GET: Hakkında
        DbMyPortfolioNightEntities  context = new DbMyPortfolioNightEntities(); 
        public ActionResult Hakkında()
        {
            var values = context.About.ToList();    
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateGetHakkında(int id)
        {
            var val = context.About.Find(id);
            return View(val);
        }
        [HttpPost]
        public ActionResult UpdateGetHakkında(About about)
        {
            var value = context.About.Find(about.AboutId);
            value.Title = about.Title;
            value.Descraption = about.Descraption;
            context.SaveChanges();
            return RedirectToAction("Hakkında");
        }



    }
}