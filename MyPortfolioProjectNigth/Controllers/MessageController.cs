﻿using MyPortfolioProjectNigth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioProjectNigth.Controllers
{
    public class MessageController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();  
        // GET: Mesaj
        public ActionResult Inbox()
        {
            var values =context.Contact.ToList();
            return View(values);
        }
        public ActionResult ChangeMessageStatusToTrue(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");  
        }
        public ActionResult ChangeMessageStatusToFalse(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

    }
}