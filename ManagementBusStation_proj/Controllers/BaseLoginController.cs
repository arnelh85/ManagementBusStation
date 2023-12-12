using ManagementBusStation.Models;
using System.Web.Mvc;

namespace ManagementBusStation.Controllers
{
    public class BaseLoginController : Controller
    {
        protected ManagementBusStationDBEntities db = new ManagementBusStationDBEntities();
    }
}