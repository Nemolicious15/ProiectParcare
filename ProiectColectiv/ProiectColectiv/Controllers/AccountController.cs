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
using System.Security.Cryptography;
using System.Text;

namespace ProiectColectiv.Controllers
{
    public class AccountController : BaseController
    {
        private ProiectColectivEntities db = new ProiectColectivEntities();

        // GET: Account
        public async Task<ActionResult> Index()
        {
            return View(await db.User.ToListAsync());
        }

        // GET: Account/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.User.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nume,Password,Rol")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.User.Where(u => u.Nume == user.Nume).Count() == 0)
                    {
                        user.Rol = "User";
                        SHA256 sha256 = SHA256Managed.Create();
                        byte[] bytes = Encoding.UTF8.GetBytes(user.Password);
                        byte[] hash = sha256.ComputeHash(bytes);
                        user.Password = Encoding.UTF8.GetString(hash);
                        db.User.Add(user);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    } else
                    {
                        ModelState.AddModelError("Nume", "Numele deja exista in baza de date!");
                    }
                }
            }
            catch (Exception e)
            {

            }
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind(Include = "Nume,Password")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SHA256 sha256 = SHA256Managed.Create();
                    byte[] bytes = Encoding.UTF8.GetBytes(user.Password);
                    byte[] hash = sha256.ComputeHash(bytes);
                    user.Password = Encoding.UTF8.GetString(hash);
                    var dbUser = await db.User.Where(u => u.Nume == user.Nume && u.Password == user.Password).FirstOrDefaultAsync();
                    if (dbUser!=null)
                    {
                        Session["UserId"] = dbUser.Id;
                    }
                    return RedirectToAction("Index","Home");
                }
            }
            catch (Exception e)
            {

            }
            return View(user);
        }

        // GET: Account/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = await db.User.FindAsync(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Account/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Nume,Password,Rol")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}

        // GET: Account/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.User.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.User.FindAsync(id);
            db.User.Remove(user);
            await db.SaveChangesAsync();
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
