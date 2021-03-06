﻿using Lab4.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactModel obj)
        {
            if(ModelState.IsValid)
            {
                return View("Success");
            }
            return View(obj);
        }
    }
}