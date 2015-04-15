using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneHomeSample.Models;

namespace PhoneHomeSample.Controllers
{
    public class ListController : Controller
    {
        private PhoneHomeDBContext db = new PhoneHomeDBContext();

        //
        // GET: /List/

        public ActionResult Index()
        {
            return View(db.Records.ToList().OrderByDescending(r => r.Difference));
        }

        //
        // GET: /List/Details/5

        public ActionResult Details(int id = 0)
        {
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        //
        // GET: /List/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /List/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Record record)
        {
            if (ModelState.IsValid)
            {
                db.Records.Add(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(record);
        }

        //
        // GET: /List/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        //
        // POST: /List/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(record);
        }

        //
        // GET: /List/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        //
        // POST: /List/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.Records.Find(id);
            db.Records.Remove(record);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}