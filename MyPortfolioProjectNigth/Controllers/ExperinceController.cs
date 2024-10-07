using MyPortfolioProjectNigth.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioProjectNigth.Controllers
{
    public class ExperinceController : Controller
    {
        // GET: Experince
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            var values =context.Experience.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Create()
        {
       
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Experience experience)
        {
            context.Experience.Add(experience);
            context.SaveChanges();  
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperince(int id)
        {
            var values = context.Experience.Find(id);
            context.Experience.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExperince(int id) 
        {
            var values = context.Experience.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateExperince(Experience experience) 
        {
            var values = context.Experience.Find(experience.ExperinceId);
           values.SubTitle = experience.SubTitle;   
            values.Title = experience.Title;    
            values.Description = experience.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}