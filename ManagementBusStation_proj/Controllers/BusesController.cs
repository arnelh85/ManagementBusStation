using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ManagementBusStation.Models;

namespace ManagementBusStation.Controllers
{
    public class BusesController : BaseController
    {       
        // GET: Buses/Index
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await db.Buses.ToListAsync());
        }
                
        // GET: Buses/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buses/CreateConfirm        
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConfirm([Bind(Include = "Id,BusCompany,SeatCapacity")] Bus b)
        {
            if (ModelState.IsValid)
            {
                db.Buses.Add(b);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(b);
        }

        // GET: Buses/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bus b = await db.Buses.FindAsync(id);

            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        // POST: Buses/EditConfirm/5        
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditConfirm([Bind(Include = "Id,BusCompany,SeatCapacity")] Bus b)
        {
            if (ModelState.IsValid)
            {
                db.Entry(b).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(b);
        }

        // GET: Buses/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bus b = await db.Buses.FindAsync(id);

            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        // POST: Buses/DeleteConfirmed/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bus b = await db.Buses.FindAsync(id);
            db.Buses.Remove(b);
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