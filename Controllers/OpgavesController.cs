using BachelorWeb.Models;
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
        ChartMaker charts = new ChartMaker();

        // GET: Opgaves
        public ActionResult Index(string sortOrder)
        {
            ViewBag.ID_Status = new SelectList(db.Status, "ID", "Title");
            var opgave = db.Opgave.Include(o => o.Fag).Include(o => o.Lærer);

            switch (sortOrder)
            {
                case "Status":
                    opgave = opgave.OrderByDescending(s => s.ID_Status);
                    break;
                case "Date":
                    opgave = opgave.OrderBy(s => s.DueDate);
                    break;
                default:
                    opgave = opgave.OrderBy(s => s.ID);
                    break;
            }

            return View(opgave.ToList());
        }

        [HttpPost]
        public ActionResult FilterIndex(int dd_status)
        {
            var opgave = db.Opgave.Include(o => o.Fag).Include(o => o.Lærer).Where(o => o.ID_Status == dd_status);
            
            return View("Index");
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
                var niveauer = "";

                return Json(new { List = niveauer }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Opgaves/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Beskrivelse,ID_Fag,SpilList,ID_Klasse,DueDate")] VMOpgaveSpil form)
        {
            int ID = (int)Session["Userid"];
            Opgave opgave = new Opgave();

            opgave.Title = form.Title;
            opgave.Beskrivelse = form.Beskrivelse;
            opgave.ID_Fag = form.ID_Fag;
            opgave.ID_Lærer = ID;
            opgave.ID_Status = 2;
            opgave.ID_Klasse = form.ID_Klasse;
            opgave.StartDate = DateTime.Now;
            opgave.DueDate = form.DueDate;

            db.Opgave.Add(opgave);

            for (int i = 0; i < form.VMSpil.Count(); i++)
            {
                OpgaveSpil os = new OpgaveSpil();
                os.ID_Opgave = opgave.ID;
                os.ID_Spil = form.VMSpil[i].ID_Spil;
                os.ID_Niveau = form.VMSpil[i].ID_Niveau;
                os.Order = i + 1;

                db.OpgaveSpil.Add(os);            
            }

            db.SaveChanges();

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

        public ActionResult Result(int id)
        {
            Session.Add("AssignmentID", id);
            Opgave opgave = db.Opgave.Find(id);

            charts.MakeChartData(opgave.ID);

            return View(opgave);
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
