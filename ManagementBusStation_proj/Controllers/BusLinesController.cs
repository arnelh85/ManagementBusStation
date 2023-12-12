using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ManagementBusStation.Models;

namespace ManagementBusStation.Controllers
{
    public class BusLinesController : BaseController
    {       
        // GET: BusLines/Index
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var busLines = db.BusLines.Include(b => b.Bus); 
            return View(await busLines.ToListAsync());
        }

        // GET: BusLines/GetDeparturesNotifications
        [HttpGet]
        [ActionName("GetDeparturesNotifications")]
        public async Task<ActionResult> ListOfNotificationsBusDeparturesBefore10Minutes()
        {
            DateTime v_compare = DateTime.Now.AddMinutes(10);
            DateTime v_compare_addMinute = DateTime.Now.AddMinutes(5);
            IQueryable<BusLine> busLines = db.BusLines.Where(bl => DbFunctions.DiffMinutes(bl.TimeOfDeparture,v_compare) == 0 || DbFunctions.DiffMinutes(bl.TimeOfDeparture,v_compare_addMinute) == 0).Select(bl => bl).AsQueryable<BusLine>();
            return View(await busLines.ToListAsync());
        }

        // GET: BusLines/GetArrivalsNotifications
        [HttpGet] 
        [ActionName("GetArrivalsNotifications")]
        public async Task<ActionResult> ListOfNotificationsBusArrivalsBefore10Minutes()
        {
            DateTime v_compare = DateTime.Now.AddMinutes(10);
            DateTime v_compare_addMinute = DateTime.Now.AddMinutes(5);
            IQueryable<BusLine> busLines = db.BusLines.Where(bl => DbFunctions.DiffMinutes(bl.TimeOfArrival,v_compare) == 0 || DbFunctions.DiffMinutes(bl.TimeOfArrival,v_compare_addMinute) == 0).Select(bl => bl).AsQueryable<BusLine>();
            return View(await busLines.ToListAsync());
        }
       
        // GET: BusLines/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.BusId = new SelectList(db.Buses, "Id", "BusCompany");
            return View();
        }

        // POST: BusLines/CreateConfirm       
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConfirm([Bind(Include = "Id,CityOfDeparture,CityOfArrival,TimeOfDeparture,TimeOfArrival,BusId")] BusLine bl)
        {
            if (ModelState.IsValid)
            {                
                db.BusLines.Add(bl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BusId = new SelectList(db.Buses, "Id", "BusCompany", bl.BusId);
            return View(bl);
        }

        // GET: BusLines/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BusLine bl = await db.BusLines.FindAsync(id);

            if (bl == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusId = new SelectList(db.Buses, "Id", "BusCompany", bl.BusId);
            return View(bl);
        }

        // POST: BusLines/EditConfirm/5        
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditConfirm([Bind(Include = "Id,CityOfDeparture,CityOfArrival,TimeOfDeparture,TimeOfArrival,BusId")] BusLine bl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BusId = new SelectList(db.Buses, "Id", "BusCompany", bl.BusId);
            return View(bl);
        }

        // GET: BusLines/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BusLine bl = await db.BusLines.FindAsync(id);

            if (bl == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusId = new SelectList(db.Buses, "Id", "BusCompany", bl.BusId);
            return View(bl);
        }

        // POST: BusLines/DeleteConfirmed/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                BusLine bl = await db.BusLines.FindAsync(id);
                db.BusLines.Remove(bl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BusId = new SelectList(db.Buses, "Id", "BusCompany");
            return View();
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