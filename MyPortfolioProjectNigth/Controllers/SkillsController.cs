using MyPortfolioProjectNigth.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioProjectNigth.Controllers
{
    public class SkillsController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        // GET: Skills
        public ActionResult Skillist()
        {
            var deger = context.Skill.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("Skillist"); 
        }
      
        public ActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);    
            context.SaveChanges();
            return RedirectToAction("Skillist");
        }
        [HttpGet]
        public ActionResult UpdateGetSkill(int id)
        {
            var val = context.Skill.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("Skillist");
        }

    }
}