using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentCars.Models;

namespace RentCars.Controllers
{
    public class CarRentalModelsController : Controller
    {
        private CarRentalsModel db = new CarRentalsModel();

        // GET: CarRentalModels
        public ActionResult Index()
        {
            var carRentals = db.CarRentals.Include(c => c.Cars).Include(c => c.Customers);
            return View(carRentals.ToList());
        }

        // GET: CarRentalModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRentalModel carRentalModel = db.CarRentals.Find(id);
            if (carRentalModel == null)
            {
                return HttpNotFound();
            }
            return View(carRentalModel);
        }


        public ActionResult Create(int id)
        {
            // ViewBag.CarId = new SelectList(db.Cars, "CarId", "Brand" + "Model");

            ViewBag.CarId = new SelectList((from s in db.Cars.ToList()
                            select new
                            {
                                CarId = s.CarId,
                                CarData = s.Brand + " " + s.Model+ " "+s.ProductionYear+" "+s.Colour
                            }),
                        "CarId",
                        "CarData",
                        null);


            CustomerModel customer = db.Customers.Single(a => a.CustomerId == id);

            CarRentalModel comm = new CarRentalModel();

            comm.CustomerId = id;
            return View(comm);

        }


        // POST: CarRentalModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarRentalId,CustomerId,CarId,CarRentalDateFrom,CarRentalDateTo,CarRentalRate")] CarRentalModel carRentalModel)
        {
            if (ModelState.IsValid)
            {
                db.CarRentals.Add(carRentalModel);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Index", "CustomerModels", "Index");
            }

            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Brand", carRentalModel.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", carRentalModel.CustomerId);
            return View(carRentalModel);
        }

        // GET: CarRentalModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRentalModel carRentalModel = db.CarRentals.Find(id);
            if (carRentalModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Brand", carRentalModel.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", carRentalModel.CustomerId);
            return View(carRentalModel);
        }

        // POST: CarRentalModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarRentalId,CustomerId,CarId,CarRentalDateFrom,CarRentalDateTo,CarRentalRate")] CarRentalModel carRentalModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carRentalModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Brand", carRentalModel.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", carRentalModel.CustomerId);
            return View(carRentalModel);
        }

        // GET: CarRentalModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRentalModel carRentalModel = db.CarRentals.Find(id);
            if (carRentalModel == null)
            {
                return HttpNotFound();
            }
            return View(carRentalModel);
        }

        // POST: CarRentalModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarRentalModel carRentalModel = db.CarRentals.Find(id);
            db.CarRentals.Remove(carRentalModel);
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
