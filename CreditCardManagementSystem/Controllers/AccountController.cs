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
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login loginData, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                if(WebSecurity.Login(loginData.Username, loginData.Password))
                {
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is invalid.");
                    return View(loginData);
                }
            }
            ModelState.AddModelError("", "Username or Password is invalid.");
            return View(loginData);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register registerData , string role)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(registerData.Username, registerData.Password);
                    Roles.AddUserToRole(registerData.Username, role);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException)
                {
                    ModelState.AddModelError("", "Username is already exists.");
                    return View(registerData);                    
                }
            }
            ModelState.AddModelError("", "Username is already exists.");
            return View(registerData);
        }
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
	}
}