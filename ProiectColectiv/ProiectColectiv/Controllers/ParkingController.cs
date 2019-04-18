using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProiectColectiv.Models;

namespace ProiectColectiv.Controllers
{
    public class ParkingController : Controller
    {
        private ProiectColectivEntities db = new ProiectColectivEntities();
        //Index -TODO

        public async  Task<ActionResult>  Index(){
            return View();
}

        //Edit
        // GET: Parcare/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Parcare parcare = await db.Parcare.FindAsync(id);
                if (parcare == null)
                {
                    return HttpNotFound();
                }
                return View(parcare);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // to do: redirect to error page
            }
        }
        // POST: Parcare/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Nume, Locatie")] Parcare parcare)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(parcare).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(parcare);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(Parcare parcare)
        {
            db.Parcare.Add(parcare);
            db.SaveChanges();
            return View();
        }
    }
}