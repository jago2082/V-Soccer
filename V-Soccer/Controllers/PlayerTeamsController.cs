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
    public class PlayerTeamsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: PlayerTeams
        public async Task<ActionResult> Index()
        {
            return View(await db.PlayerTeams.ToListAsync());
        }

        // GET: PlayerTeams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerTeam playerTeam = await db.PlayerTeams.FindAsync(id);
            if (playerTeam == null)
            {
                return HttpNotFound();
            }
            return View(playerTeam);
        }

        // GET: PlayerTeams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerTeams/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PlayerTeamId,PlayerId,TeamId")] PlayerTeam playerTeam)
        {
            if (ModelState.IsValid)
            {
                db.PlayerTeams.Add(playerTeam);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(playerTeam);
        }

        // GET: PlayerTeams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerTeam playerTeam = await db.PlayerTeams.FindAsync(id);
            if (playerTeam == null)
            {
                return HttpNotFound();
            }
            return View(playerTeam);
        }

        // POST: PlayerTeams/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PlayerTeamId,PlayerId,TeamId")] PlayerTeam playerTeam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerTeam).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(playerTeam);
        }

        // GET: PlayerTeams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerTeam playerTeam = await db.PlayerTeams.FindAsync(id);
            if (playerTeam == null)
            {
                return HttpNotFound();
            }
            return View(playerTeam);
        }

        // POST: PlayerTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PlayerTeam playerTeam = await db.PlayerTeams.FindAsync(id);
            db.PlayerTeams.Remove(playerTeam);
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
