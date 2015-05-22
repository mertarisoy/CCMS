using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreditCardManagementSystem.Models;
using WebMatrix.WebData;
using System.Web.Security;
using Microsoft.AspNet.Identity;


namespace CreditCardManagementSystem.Controllers
{
    public class AccountController : Controller
    {

        CCMSEntities db = new CCMSEntities();
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

                    if (Roles.GetRolesForUser(loginData.Username)[0] == "Admin")
                    {
                        return RedirectToAction("Index", "Admin"); 
                    }
                    else
                    {
                        string ss = "";


                        using (var ctx = db)
                        {
                            var id = ctx.UserProfile.SqlQuery("Select * FROM UserProfile WHERE Username='"+loginData.Username+"'").FirstOrDefault<UserProfile>();
                            ss = id.UserID.ToString();
                        }

                        Session["userID"] = ss;
                        return RedirectToAction("Details", "Customer", new { id = ss });
                    }
                    
                              
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
                    CCMSEntities db = new CCMSEntities();
                    db.Customer.Add(registerData.toCustomerObject());
                    db.SaveChanges();
                    return RedirectToAction("Index", "Admin");
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