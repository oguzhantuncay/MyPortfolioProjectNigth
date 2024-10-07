using MyPortfolioProjectNigth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioProjectNigth.Controllers
{ 
    public class AdminController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();  
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSideBar()
        {
            ViewBag.Image = context.Profile.Select(x => x.ImageUrl).FirstOrDefault();
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
        public ActionResult Dashborad()
        {
            ViewBag.skill = context.Skill.Count();
            ViewBag.message = context.Contact.Count();
            ViewBag.tesekkur = context.Contact.Where(x=>x.CategoryId==1).Count() ;
            var highestRatedSkill = context.Skill
                  .OrderByDescending(s => s.Rate)
                  .FirstOrDefault();

            if (highestRatedSkill != null)
            {
                ViewBag.SkillName = highestRatedSkill.SkillName;
                ViewBag.Rate = highestRatedSkill.Rate;
            }
            else
            {
                ViewBag.SkillName = "Yetenek bulunamadı";
                ViewBag.Rate = 0;
            }
            return View();
        }


        public ActionResult Egitimlerim()
        {
            var values = context.Education.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(Education education)
        {
            if (ModelState.IsValid)
            {
                context.Education.Add(education);
                context.SaveChanges();
                return RedirectToAction("Egitimlerim");
            }
            return View(education);
        }
        [HttpGet]
        public ActionResult UpdateGetEgitim(int id)
        {
            var val = context.Education.Find(id);
            return View(val);
        }
        [HttpPost]
        public ActionResult UpdateGetEgitim(Education education)
        {
            var value = context.Education.Find(education.EducationId);
            value.Title = education.Title;
            value.Descraption = education.Descraption;
            value.SubTitle = education.SubTitle;
            context.SaveChanges();
            return RedirectToAction("Egitimlerim");
        }
        [HttpPost]
        public ActionResult DeleteEgitim(int id)
        {
            var education = context.Education.Find(id);
            if (education != null)
            {
                context.Education.Remove(education);
                context.SaveChanges();
            }
            return RedirectToAction("Egitimlerim");
        }





        public ActionResult Staj ()
        {
            var values = context.Intern.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult StajEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StajEkle(Intern ıntern)
        {
            if (ModelState.IsValid)
            {
                context.Intern.Add(ıntern);
                context.SaveChanges();
                return RedirectToAction("Staj");
            }
            return View(ıntern);
        }
        [HttpGet]
        public ActionResult UpdateGetStaj(int id)
        {
            var val = context.Intern.Find(id);
            return View(val);
        }
        [HttpPost]
        public ActionResult UpdateGetStaj(Intern ıntern)
        {
            var value = context.Intern.Find(ıntern.internID);
            value.CompanyName = ıntern.CompanyName;
            value.InternDescription = ıntern.InternDescription;
            value.StartDate = ıntern.StartDate;
            value.EndDate = ıntern.EndDate;
            value.Supervisor = ıntern.Supervisor;
            value.SupervisorMail = ıntern.SupervisorMail;
            
            context.SaveChanges();
            return RedirectToAction("Staj");
        }

        [HttpPost]
        public ActionResult DeleteStaj(int id)
        {
            var staj = context.Intern.Find(id);
            if (staj != null)
            {
                context.Intern.Remove(staj);
                context.SaveChanges();
            }
            return RedirectToAction("Staj");
        }


    }
}