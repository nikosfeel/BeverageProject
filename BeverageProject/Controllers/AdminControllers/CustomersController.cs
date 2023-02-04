using MyDatabase;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace BeverageProject.Controllers.AdminControllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomersController()
        {
            _db = new ApplicationDbContext();
        }
        public ActionResult Orders()
        {
            var orders = _db.Orders.Include(x => x.Products).ToList();

            return View(orders);
        }

        public ActionResult Users()
        {
            return View(_db.Users.ToList());
        }
    }
}