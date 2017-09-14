using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;
using V_Soccer.Models;

namespace V_Soccer.Controllers
{
    public class GenersController : Controller
    {
        private DataContext db = new DataContext();

        
        // GET: Geners
        public async Task<ActionResult> Index()
        {
            return View(await db.Geners.ToListAsync());
        }

        // GET: Geners/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gener gener = await db.Geners.FindAsync(id);
            if (gener == null)
            {
                return HttpNotFound();
            }
            return View(gener);
        }

        // GET: Geners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Geners/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GenerId,Name")] Gener gener)
        {
            if (ModelState.IsValid)
            {
                db.Geners.Add(gener);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(gener);
        }

        // GET: Geners/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gener gener = await db.Geners.FindAsync(id);
            if (gener == null)
            {
                return HttpNotFound();
            }
            return View(gener);
        }

        // POST: Geners/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GenerId,Name")] Gener gener)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gener).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gener);
        }

        // GET: Geners/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gener gener = await db.Geners.FindAsync(id);
            if (gener == null)
            {
                return HttpNotFound();
            }
            return View(gener);
        }

        // POST: Geners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Gener gener = await db.Geners.FindAsync(id);
            db.Geners.Remove(gener);
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
