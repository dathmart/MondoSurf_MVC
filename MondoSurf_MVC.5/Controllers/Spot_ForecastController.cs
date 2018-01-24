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
    public class Spot_ForecastController : Controller
    {
        private MondoSurfDBEntities2 db = new MondoSurfDBEntities2();

        // GET: Spot_Forecast
        public ActionResult Index()
        {
            var spot_Forecast = db.Spot_Forecast.Include(s => s.Spot_Details);
            return View(spot_Forecast.ToList());
        }

        // GET: Spot_Forecast/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spot_Forecast spot_Forecast = db.Spot_Forecast.Find(id);
            if (spot_Forecast == null)
            {
                return HttpNotFound();
            }
            return View(spot_Forecast);
        }

        // GET: Spot_Forecast/Create
        public ActionResult Create()
        {
            ViewBag.Spot_Id = new SelectList(db.Spot_Details, "Spot_Id", "Spot_Name");
            return View();
        }

        // POST: Spot_Forecast/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Spot_Id,TimeStampGMT,Size_ft,Shape_Full,Shape_Detail_Swell,Shape_Detail_Tide,Shape_Detail_Wind,Warning")] Spot_Forecast spot_Forecast)
        {
            if (ModelState.IsValid)
            {
                db.Spot_Forecast.Add(spot_Forecast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Spot_Id = new SelectList(db.Spot_Details, "Spot_Id", "Spot_Name", spot_Forecast.Spot_Id);
            return View(spot_Forecast);
        }

        // GET: Spot_Forecast/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spot_Forecast spot_Forecast = db.Spot_Forecast.Find(id);
            if (spot_Forecast == null)
            {
                return HttpNotFound();
            }
            ViewBag.Spot_Id = new SelectList(db.Spot_Details, "Spot_Id", "Spot_Name", spot_Forecast.Spot_Id);
            return View(spot_Forecast);
        }

        // POST: Spot_Forecast/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Spot_Id,TimeStampGMT,Size_ft,Shape_Full,Shape_Detail_Swell,Shape_Detail_Tide,Shape_Detail_Wind,Warning")] Spot_Forecast spot_Forecast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spot_Forecast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Spot_Id = new SelectList(db.Spot_Details, "Spot_Id", "Spot_Name", spot_Forecast.Spot_Id);
            return View(spot_Forecast);
        }

        // GET: Spot_Forecast/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spot_Forecast spot_Forecast = db.Spot_Forecast.Find(id);
            if (spot_Forecast == null)
            {
                return HttpNotFound();
            }
            return View(spot_Forecast);
        }

        // POST: Spot_Forecast/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spot_Forecast spot_Forecast = db.Spot_Forecast.Find(id);
            db.Spot_Forecast.Remove(spot_Forecast);
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
