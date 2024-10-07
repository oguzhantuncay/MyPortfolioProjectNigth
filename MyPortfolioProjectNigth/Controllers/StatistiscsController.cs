using MyPortfolioProjectNigth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioProjectNigth.Controllers
{
    public class StatistiscsController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();  
        public ActionResult Index()
        {
            ViewBag.totalmessagecount = context.Contact.Count();
            ViewBag.True = context.Contact.Where(x=>x.IsRead==true).Count();
            ViewBag.False = context.Contact.Where(x => x.IsRead ==false).Count();
            ViewBag.Skilssum = context.Skill.Sum(x => x.Rate);
            ViewBag.Skilsavg = context.Skill.Average(x => x.Rate);

            var maxRate = context.Skill.Max(x => x.Rate);
            ViewBag.MaxRateSkilsName = context.Skill.Where(x=>x.Rate== maxRate).Select(y=>y.SkillName).FirstOrDefault();    

            ViewBag.getMessageCountBySubjectReferances =context.Contact.Where(x=>x.Subject=="Referans").Count();

            ViewBag.getMessageCountByEmailContainHAndIsReadTrue = context.Contact.Where(x=>x.IsRead==true && x.Email.Contains("h")).Count();

            ViewBag.Rate90 = context.Skill.Where(x => x.Rate == 90).Select(y => y.SkillName).FirstOrDefault();

            return View();
        }
    }
}