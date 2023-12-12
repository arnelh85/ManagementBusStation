using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ManagementBusStation.Models;

namespace ManagementBusStation.Controllers
{
    public class AuthorizationController : BaseLoginController
    {        
        // GET: Authorization/Login
        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return await Task.Run(() => View());                                                                           
        }

        // POST: Authorization/LoginConfirm 
        [HttpPost]
        [ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginConfirm([Bind(Include = "EmployeeEmailAddress,EmployeePassword")] Employee emp)
        {
            string login_email = null;
            string decr_password = null;            
            var email_cred = await db.Employees.Where(e => e.EmployeeEmailAddress == emp.EmployeeEmailAddress).FirstOrDefaultAsync();            
            var employeeType = await (from e in db.Employees join et in db.EmployeeTypes on e.EmployeeTypeId equals et.Id 
                                      where e.EmployeeEmailAddress == emp.EmployeeEmailAddress select et.EmployeeTypeNo).FirstOrDefaultAsync();
            var retrievedFullName = await db.Employees.Where(e => e.EmployeeEmailAddress == emp.EmployeeEmailAddress).Select(e => e.EmployeeName).FirstOrDefaultAsync();

            if (email_cred != null)
            {
                login_email = emp.EmployeeEmailAddress;
                decr_password = email_cred.EmployeePassword.ConvertFromBase64String();
                Session["login_email"] = login_email;
                Session["login_password"] = decr_password;
                Session["employeeFullName"] = retrievedFullName;

                if (emp.EmployeePassword == decr_password && employeeType == 1)
                {
                    Session["IsAdmin"] = employeeType;
                    return RedirectToAction("Create", "TicketSales");
                }
                else if (emp.EmployeePassword == decr_password && employeeType == 2)
                {
                    Session["IsUser"] = employeeType;
                    return RedirectToAction("Create", "BusLines");
                }
                else
                {
                    ModelState.AddModelError("EmployeePassword", "Unešena šifra nije ispravna!");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("EmployeeEmailAddress", "Unešena email adresa nije ispravna!");
                return View();
            }                      
        }

        // GET: Authorization/Logout
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            Session["login_email"] = null;
            Session["login_password"] = null;
            Session["employeeFullName"] = null;
            Session["IsAdmin"] = null;
            Session["IsUser"] = null;
            return await Task.Run<ActionResult>(() => { return RedirectToAction("Login"); });
        }       
    }
}