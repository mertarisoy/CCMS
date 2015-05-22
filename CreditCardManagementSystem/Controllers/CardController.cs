using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CreditCardManagementSystem.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace CreditCardManagementSystem.Controllers
{
    public class CardController : Controller
    {
        private CCMSEntities db = new CCMSEntities();

        // GET: /Card/
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult CardList()
        {
            var cards = db.Cards.Include(c => c.CreditCard);
            return View(cards.ToList());
        }
        // GET: /Card/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cards cards = db.Cards.Find(id);
            if (cards == null)
            {
                return HttpNotFound();
            }
            return View(cards);
        }

        // GET: /Card/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CCMSEntities db = new CCMSEntities();
            String fullname = "";
            using (var ctx = db)
            {
                var t = ctx.Customer.SqlQuery("Select * FROM Customer WHERE CustomerID='" +id+"'").FirstOrDefault<Customer>();
                fullname = t.CustomerName + " " + t.CustomerSurname;
            }

            ViewBag.exprDate = DateTime.Today.Month + "/" + (DateTime.Today.Year + 5);
            ViewBag.date = DateTime.Today.Month + "/" + DateTime.Today.Year;

            ViewBag.fullName = fullname;
            NumberGenerator numgen = NumberGenerator.getInstance();
            String cardNumber = numgen.generate();
            Random rnd = new Random();
            int cvc = rnd.Next(100, 1000);

            ViewBag.CVC = cvc;
            ViewBag.cardNumber = cardNumber;
            //ViewBag.CardNumber = new SelectList(db.CreditCard, "CardNumber", "CardNumber");
            return View();
        }

        // POST: /Card/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardNumber,ExpirationDate,Cvc,CardName,ReleaseDate,isActive,Pin,CardType")] Cards cards)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Cards.Add(cards);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            
            
            }

            ViewBag.CardNumber = new SelectList(db.CreditCard, "CardNumber", "CardNumber", cards.CardNumber);
            return View(cards);
        }

        // GET: /Card/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cards cards = db.Cards.Find(id);
            if (cards == null)
            {
                return HttpNotFound();
            }
            ViewBag.CardNumber = new SelectList(db.CreditCard, "CardNumber", "CardNumber", cards.CardNumber);
            return View(cards);
        }

        // POST: /Card/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardNumber,ExpirationDate,Cvc,CardName,ReleaseDate,isActive,Pin,CardType")] Cards cards)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cards).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CardNumber = new SelectList(db.CreditCard, "CardNumber", "CardNumber", cards.CardNumber);
            return View(cards);
        }

        // GET: /Card/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cards cards = db.Cards.Find(id);
            if (cards == null)
            {
                return HttpNotFound();
            }
            return View(cards);
        }
        public ActionResult CardGenerator()
        {
            NumberGenerator numgen = NumberGenerator.getInstance();
            return Content(numgen.generate());
        }
        // POST: /Card/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cards cards = db.Cards.Find(id);
            db.Cards.Remove(cards);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
