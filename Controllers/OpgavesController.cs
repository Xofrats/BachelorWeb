using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BachelorWeb
{
    public class OpgavesController : Controller
    {
        private Learn_BasicEntities db = new Learn_BasicEntities();

        // GET: Opgaves
        public ActionResult Index()
        {
            var opgave = db.Opgave.Include(o => o.Fag).Include(o => o.Lærer);
            return View(opgave.ToList());
        }

        // GET: Opgaves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opgave opgave = db.Opgave.Find(id);
            if (opgave == null)
            {
                return HttpNotFound();
            }
            return View(opgave);
        }

        // GET: Opgaves/Create
        public ActionResult Create()
        {
            ViewBag.ID_Fag = new SelectList(db.Fag, "ID", "Title");
            ViewBag.ID_Lærer = new SelectList(db.Lærer, "ID", "Fornavn");
            ViewBag.Spil = new SelectList(db.Spil, "ID", "Title");
            return View();
        }

        // POST: Opgaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Beskrivelse,ID_Fag,ID_Lærer,Status")] Opgave opgave)
        {
            if (ModelState.IsValid)
            {
                db.Opgave.Add(opgave);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Fag = new SelectList(db.Fag, "ID", "Title", opgave.ID_Fag);
            ViewBag.ID_Lærer = new SelectList(db.Lærer, "ID", "Fornavn", opgave.ID_Lærer);
            return View(opgave);
        }

        // GET: Opgaves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opgave opgave = db.Opgave.Find(id);
            if (opgave == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Fag = new SelectList(db.Fag, "ID", "Title", opgave.ID_Fag);
            ViewBag.ID_Lærer = new SelectList(db.Lærer, "ID", "Fornavn", opgave.ID_Lærer);
            return View(opgave);
        }

        // POST: Opgaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Beskrivelse,ID_Fag,ID_Lærer,Status")] Opgave opgave)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opgave).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Fag = new SelectList(db.Fag, "ID", "Title", opgave.ID_Fag);
            ViewBag.ID_Lærer = new SelectList(db.Lærer, "ID", "Fornavn", opgave.ID_Lærer);
            return View(opgave);
        }

        // GET: Opgaves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opgave opgave = db.Opgave.Find(id);
            if (opgave == null)
            {
                return HttpNotFound();
            }
            return View(opgave);
        }

        // POST: Opgaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opgave opgave = db.Opgave.Find(id);
            db.Opgave.Remove(opgave);
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
