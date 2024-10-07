using MyPortfolioProjectNigth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioProjectNigth.Controllers
{
    public class SocialController : Controller
    {
        // GET: Social
        DbMyPortfolioNightEntities context =new DbMyPortfolioNightEntities();
        public ActionResult Social()
        {
            var values=context.Social.ToList();
            return View(values);
        }
        // Kayıt ekleme formunu gösterir
        public ActionResult SocialCreate()
        {
            return View();
        }

        // Kayıt ekleme işlemini yapar
        [HttpPost]
        public ActionResult SocialCreate(Social social)
        {
            if (ModelState.IsValid)
            {
                context.Social.Add(social);
                social.Status = true;
                context.SaveChanges();
                return RedirectToAction("Social");
            }
            return View(social);
        }
        public ActionResult ChangeStatusToTrue(int id)
        {
            var value = context.Social.Find(id);
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("Social");
        }
        public ActionResult ChangeStatusToFalse(int id)
        {
            var value = context.Social.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Social");
        }
    }
}