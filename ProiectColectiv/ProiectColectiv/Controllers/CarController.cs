using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProiectColectiv.Models;

namespace ProiectColectiv.Controllers
{
    public class CarController : Controller
    {
        private ProiectColectivEntities db = new ProiectColectivEntities();
        // GET: Car
        public ActionResult Index()
        {
            try
            {
                List<Masina> masini = new List<Masina>();
                masini = db.Masina.ToList();
                return View(masini);
            }
            catch(Exception e)
            {
                return null; // change to redirect to soon to be error page
            }
           
        }

        // GET: Car/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if(id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Masina car = new Masina();
                car = await db.Masina.FindAsync(id);
                return View(car);
            }
            catch(Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //change to redirect to soon to be error page
            }
        }

        // GET: Car/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdUser,NumarMatricol")] Masina car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Masina.Add(car);
                    await db.SaveChangesAsync();
                    return View(car);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception e)
            {
               //to add redirect to error page
            }
            return RedirectToAction("Index");
        }

        // GET: Car/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Masina car = await db.Masina.FindAsync(id);
                if (car == null)
                {
                    return HttpNotFound();
                }
                return View(car);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // to do: redirect to error page
            }
        }

        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdUser,NumarMatricol")] Masina car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(car).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(car);
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Masina car = await db.Masina.FindAsync(id);
                if (car == null)
                {
                    return HttpNotFound();
                }
                return View(car);
            }
            catch(Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // to do: redirect to error page
            }
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Masina car =  await db.Masina.FindAsync(id);
                db.Masina.Remove(car);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // to do: redirect to error page
            }
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
