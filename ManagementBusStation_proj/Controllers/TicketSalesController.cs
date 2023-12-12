using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ManagementBusStation.Models;

namespace ManagementBusStation.Controllers
{
    public class TicketSalesController : BaseController
    {        
        // GET: TicketSales/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeName");
            return View();
        }

        // POST: TicketSales/CreateConfirm
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConfirm([Bind(Include = "Id,CustomerName,CustomerAge,Currency,TicketPrice,Discount,EmployeeId")] TicketSale ticksal)
        {           
            var executedBusTicketNo = await db.TicketSales.OrderByDescending(ts => ts.Id).Select(ts => ts.TicketNo).FirstOrDefaultAsync();
            ticksal.TicketNo = executedBusTicketNo == null ? "1000000001" : (Convert.ToInt32(executedBusTicketNo)+1).ToString();
            var includedDiscount = ticksal.Discount;
            ticksal.TotalAmount = includedDiscount == 25 ? (ticksal.TicketPrice * 100 - ticksal.TicketPrice * includedDiscount) / 100 :
                                  includedDiscount == 50 ? (ticksal.TicketPrice * 100 - ticksal.TicketPrice * includedDiscount) / 100 :
                                  (ticksal.TicketPrice * 100 - ticksal.TicketPrice * 0) / 100;
            DateTime dt = DateTime.Now;
            ticksal.CreatedDate = dt;
            
            if (ModelState.IsValid)
            {               
                db.TicketSales.Add(ticksal);
                await db.SaveChangesAsync();               
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeName", ticksal.EmployeeId);
            return View(ticksal);
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