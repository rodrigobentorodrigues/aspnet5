using System.Web.Mvc;

namespace Course.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult Create()
        {
            return View();
        }
    }
}