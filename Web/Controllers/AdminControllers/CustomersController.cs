using ApplicationDatabase;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace Web.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult OrderDetails(int id)
        {
            return View();
        }
        public ActionResult Users()
        {
            return View(_db.Users.ToList());
        }
        public ActionResult Messages()
        {
            return View();
        }
    }
}