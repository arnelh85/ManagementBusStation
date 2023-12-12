using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using ManagementBusStation.Models;

namespace ManagementBusStation.Controllers
{
    public class EmployeesController : BaseController
    {       
        // GET: Employees/Index
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.EmployeeType);
            return View(await employees.ToListAsync());
        }
        
        // GET: Employees/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "Id", "EmployeeTypeName");
            return View();
        }

        // POST: Employees/CreateConfirm        
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConfirm([Bind(Include = "Id,EmployeeName,EmployeeAge,EmployeePersonalIdNo,EmployeeCountry,EmployeeCity,EmployeePhoneNumber,EmployeeEmailAddress,EmployeePassword,EmployeeTypeId")] Employee emp)
        {           
            if (ModelState.IsValid)
            {
                emp.EmployeePassword = emp.EmployeePassword.ConvertToBase64String();
                db.Employees.Add(emp);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "Id", "EmployeeTypeName", emp.EmployeeTypeId);
            return View(emp);
        }

        // GET: Employees/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee emp = await db.Employees.FindAsync(id);

            if (emp == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "Id", "EmployeeTypeName", emp.EmployeeTypeId);
            return View(emp);
        }

        // POST: Employees/EditConfirm/5        
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditConfirm([Bind(Include = "Id,EmployeeName,EmployeeAge,EmployeePersonalIdNo,EmployeeCountry,EmployeeCity,EmployeePhoneNumber,EmployeeEmailAddress,EmployeePassword,EmployeeTypeId")] Employee emp)
        {
            if (ModelState.IsValid)
            {
                emp.EmployeePassword = emp.EmployeePassword.ConvertToBase64String();
                db.Entry(emp).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "Id", "EmployeeTypeName", emp.EmployeeTypeId);
            return View(emp);
        }

        // GET: Employees/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee emp = await db.Employees.FindAsync(id);

            if (emp == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "Id", "EmployeeTypeName", emp.EmployeeTypeId);
            return View(emp);
        }

        // POST: Employees/DeleteConfirmed/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            { 
                Employee emp = await db.Employees.FindAsync(id);
                db.Employees.Remove(emp);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "Id", "EmployeeTypeName");
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