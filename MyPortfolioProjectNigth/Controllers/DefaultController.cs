using MyPortfolioProjectNigth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyPortfolioProjectNigth.Controllers
{
    
    public class DefaultController : Controller
    {DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        // GET: Default
        public ActionResult Index()
        {
            List<SelectListItem> list = (from x in context.Category.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CatogoryName,
                                             Value = x.CategoryId.ToString()

                                         }).ToList();
            ViewBag.List = list;

            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            context.Contact.Add(contact);
            contact.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.IsRead = false;

            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter() 
        {
            var values = context.Social.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialHeader()
        {
            ViewBag.Title=context.Profile.Select(x => x.Title).FirstOrDefault();    
            ViewBag.Description=context.Profile.Select(x => x.Description).FirstOrDefault();    
            ViewBag.Adress=context.Profile.Select(x => x.Adress).FirstOrDefault();    
            ViewBag.Telefon=context.Profile.Select(x => x.Phone).FirstOrDefault();    
            ViewBag.email=context.Profile.Select(x => x.Email).FirstOrDefault();    
            ViewBag.github=context.Profile.Select(x => x.Github).FirstOrDefault();    
            ViewBag.imageurl=context.Profile.Select(x => x.ImageUrl).FirstOrDefault();    
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
           
            var values = context.About.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialExperience()
        {
            var values = context.Experience.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialEducation()
        {
            var values = context.Education.ToList();
            return PartialView(values);   
        }
        public PartialViewResult PartialSkills()
        {
            var values = context.Skill.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialServices()
        {
            var values = context.Service.ToList();
            return PartialView(values);
        }
        public PartialViewResult Partialintern()
        {
            var values = context.Intern.ToList();
            return PartialView(values);
        }
       
        public PartialViewResult PartialReferanslarım()
        {

            return PartialView();
        }

        public PartialViewResult PartialPortfolio()
        {
            return PartialView();

        }
        public PartialViewResult PartialBlog()
        {
            return PartialView();

        }
    }
}