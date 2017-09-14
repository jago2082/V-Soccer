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
    public class PlayersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Players
        public async Task<ActionResult> Index()
        {
            var players = db.Players.Include(p => p.City).Include(p => p.Country);
            return View(await players.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View();
        }

        // POST: Players/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PlayerId,Name,LastName,BirthDate,SexId,Phone,CityId,CountryId,CoordX,CoordY,Email,Weight,Height,Position,Skill1,Skill2,Skill3,Skill4,Skill5,Stars,Qualification,Friendly,Goals,RedCards,YellowCards,Nickname,Anickname,Image")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", player.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", player.CountryId);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", player.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", player.CountryId);
            return View(player);
        }

        // POST: Players/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PlayerId,Name,LastName,BirthDate,SexId,Phone,CityId,CountryId,CoordX,CoordY,Email,Weight,Height,Position,Skill1,Skill2,Skill3,Skill4,Skill5,Stars,Qualification,Friendly,Goals,RedCards,YellowCards,Nickname,Anickname,Image")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", player.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", player.CountryId);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Player player = await db.Players.FindAsync(id);
            db.Players.Remove(player);
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
