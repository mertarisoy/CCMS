﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreditCardManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        [Authorize(Roles = "Customer")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CustomerList()
        {
            return View();
        }
	}
}