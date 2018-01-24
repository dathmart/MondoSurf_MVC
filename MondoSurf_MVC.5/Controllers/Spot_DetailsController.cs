using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MondoSurf_MVC._5.Models;

namespace MondoSurf_MVC._5.Controllers
{
    public class Spot_DetailsController : Controller
    {
        private MondoSurfDBEntities2 db = new MondoSurfDBEntities2();

        // GET: Spot_Details
        public ActionResult Index()
        {
            return View(db.Spot_Details.ToList());
        }

        // GET: Spot_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spot_Details spot_Details = db.Spot_Details.Find(id);
            if (spot_Details == null)
            {
                return HttpNotFound();
            }
            return View(spot_Details);
        }

        // GET: Spot_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spot_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Spot_Id,Spot_Name,County_id,Coordinates,Street_Address")] Spot_Details spot_Details)
        {
            if (ModelState.IsValid)
            {
                db.Spot_Details.Add(spot_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(spot_Details);
        }

        // GET: Spot_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spot_Details spot_Details = db.Spot_Details.Find(id);
            if (spot_Details == null)
            {
                return HttpNotFound();
            }
            return View(spot_Details);
        }

        // POST: Spot_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Spot_Id,Spot_Name,County_id,Coordinates,Street_Address")] Spot_Details spot_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spot_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spot_Details);
        }

        // GET: Spot_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spot_Details spot_Details = db.Spot_Details.Find(id);
            if (spot_Details == null)
            {
                return HttpNotFound();
            }
            return View(spot_Details);
        }

        // POST: Spot_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spot_Details spot_Details = db.Spot_Details.Find(id);
            db.Spot_Details.Remove(spot_Details);
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
