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
    }
}