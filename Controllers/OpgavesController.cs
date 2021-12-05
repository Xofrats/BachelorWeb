using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static BachelorWeb.Viewmodels;

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
            ViewBag.ID_Klasse = new SelectList(db.Klasse, "ID", "Navn");
            return View();
        }

        [HttpPost]
        public ActionResult GetNiveauer(int idDropDown)
        {
            var niveauer = (from sn in db.SpilNiveauer
                      join n in db.Niveau on sn.ID_Niveau equals n.ID
                      where sn.ID_Spil == idDropDown
                      select new { 
                          ID=n.ID,
                          Navn = n.Navn
                      }).ToArray();

            return Json(new { List = niveauer }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetSpil(int? idDropDown)
        {
            if (idDropDown != null)
            {
                var niveauer = (from s in db.Spil
                                join f in db.Fag on s.ID_Fag equals f.ID
                                where f.ID == idDropDown
                                select new
                                {
                                    ID = s.ID,
                                    Navn = s.Title
                                }).ToArray();

                return Json(new { List = niveauer }, JsonRequestBehavior.AllowGet);
            } else
            {
                var niveauer = (from s in db.Spil
                                join f in db.Fag on s.ID_Fag equals f.ID
                                select new
                                {
                                    ID = f.ID,
                                    Navn = f.Title
                                }).ToArray();

                return Json(new { List = niveauer }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Opgaves/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Beskrivelse,ID_Fag,ID_Spil,ID_Niveau,ID_Klasse,Status")] VMOpgaveSpil form)
        {
            int ID = (int)Session["Userid"];
            Opgave opgave = new Opgave();

            opgave.Title = form.Title;
            opgave.Beskrivelse = form.Beskrivelse;
            opgave.ID_Fag = form.ID_Fag;
            opgave.ID_Lærer = ID;
            opgave.ID_Status = 2;
            opgave.ID_Klasse = form.ID_Klasse;

            db.Opgave.Add(opgave);
            db.SaveChanges();

            for(int i = 0; i < form.ID_Spil.Count(); i++)
            {
                OpgaveSpil os = new OpgaveSpil();
                os.ID_Opgave = opgave.ID;
                os.ID_Spil = form.ID_Spil[i];
                os.ID_Niveau = form.ID_Spil[i];
                os.Order = i + 1;

                db.OpgaveSpil.Add(os);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Opgaves/Edit/5
        public ActionResult Edit(int? id)
        {
            VMOpgaveSpil opgaveVM = new VMOpgaveSpil();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opgave opgave = db.Opgave.Find(id);
            if (opgave == null)
            {
                return HttpNotFound();
            }

            List<OpgaveSpil> OS = db.OpgaveSpil.Where(o => o.ID_Opgave == id).ToList();

            opgaveVM.Title = opgave.Title;
            opgaveVM.Beskrivelse = opgave.Beskrivelse;
            opgaveVM.ID_Fag = opgave.ID_Fag;
            opgaveVM.ID_Klasse = opgave.ID_Klasse;

            OS.ForEach(element => opgaveVM.ID_Spil.Add(element.ID_Spil));
            OS.ForEach(element => opgaveVM.ID_Spil.Add(element.ID_Niveau));

            ViewBag.ID_Fag = new SelectList(db.Fag, "ID", "Title", opgave.ID_Fag);
            ViewBag.Klasse = new SelectList(db.Klasse, "ID", "Navn", opgave.ID_Klasse);
            return View(opgaveVM);
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

        public ActionResult Afslut(int id)
        {
            Opgave opgave = db.Opgave.Find(id);
            if (opgave == null)
            {
                return HttpNotFound();
            } else
            {
                opgave.ID_Status = 3;
                db.SaveChanges();

            }


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
