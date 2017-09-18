using Domain;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using V_Soccer.Clases;
using V_Soccer.Models;

namespace V_Soccer.Controllers
{
    public class PlayersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Players
        public async Task<ActionResult> Index()
        {
            var players = db.Players.Include(p => p.City).Include(p => p.Country).Include(p => p.Department).Include(p => p.Gener );
            return View(await players.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            ViewBag.GenerId = new SelectList(db.Geners, "GenerId", "Name");
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View();
        }

        // POST: Players/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Player player)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Players.Add(player);
                    await db.SaveChangesAsync();

                    if(player.LogoFile != null)
                    {
                        var file = string.Format("{0}.jpg", player.PlayerId);
                        var folder = "~/Content/Logos";
                        var response = FileHelper.UploadPhoto(player.LogoFile, folder, file);

                        if (response)
                        {
                            player.Image = string.Format("{0}/{1}", folder, file);
                            db.Entry(player).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return RedirectToAction("Index");
            }

            ViewBag.GenerId = new SelectList(db.Geners, "GenerId", "Name", player.GenerId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", player.CityId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name",player.DepartmentId);
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
            var player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenerId = new SelectList(db.Geners, "GenerId", "Name", player.GenerId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", player.CityId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", player.DepartmentId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", player.CountryId);
            return View(player);
        }

        // POST: Players/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                var file = string.Format("{0}.jpg", player.PlayerId);
                var folder = "~/Content/Logos";
                var response = FileHelper.UploadPhoto(player.LogoFile, folder, file);

                if (response)
                {
                    player.Image = string.Format("{0}/{1}", folder, file);

                }
                db.Entry(player).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GenerId = new SelectList(db.Geners, "GenerId", "Name", player.GenerId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", player.CityId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", player.DepartmentId);
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
            var player = await db.Players.FindAsync(id);
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
