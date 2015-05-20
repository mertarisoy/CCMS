﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreditCardManagementSystem.Models;

namespace CreditCardManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CardInfo cardInfo = new CardInfo();
            return View();
        }
        [Authorize(Roles="admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}