using ManagementBusStation.Models;
using System.Web.Mvc;

namespace ManagementBusStation.Controllers
{
    public class BaseController : Controller
    {
        protected ManagementBusStationDBEntities db = new ManagementBusStationDBEntities();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Session["login_email"] == null)
            {
                filterContext.Result = new RedirectResult(Url.Action("Login", "Authorization")); 
            }
        }
    }
}