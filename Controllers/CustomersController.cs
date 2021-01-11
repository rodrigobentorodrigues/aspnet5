using Course.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Course.Controllers
{
    public class CustomersController : Controller
    {

        private readonly ApplicationContext _context;

        public CustomersController()
        {
            this._context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include((customer) => customer.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault((c) => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

    }
}