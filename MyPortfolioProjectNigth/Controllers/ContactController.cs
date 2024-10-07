using MyPortfolioProjectNigth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioProjectNigth.Controllers
{
    public class ContactController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();  
        // GET: Contact
        public PartialViewResult PartialContactSıdeBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialContactProfil()
        {
            ViewBag.Adress=context.Profile.Select(x=>x.Adress).FirstOrDefault();
            ViewBag.Email=context.Profile.Select(x=>x.Email).FirstOrDefault();
            ViewBag.Phone=context.Profile.Select(x=>x.Phone).FirstOrDefault();
            ViewBag.Location = context.Profile.Select(x => x.Location).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialContactLocation()
        {
            ViewBag.Location = context.Profile.Select(x => x.Location).FirstOrDefault();
            return PartialView();
        }


    }
}