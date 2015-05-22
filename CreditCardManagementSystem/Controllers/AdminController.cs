using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreditCardManagementSystem.Models;
using WebMatrix.WebData;
using System.Web.Security;

namespace CreditCardManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Customer");
        }
	}
}