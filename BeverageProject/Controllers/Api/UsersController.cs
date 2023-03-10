using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using PersistenceLayerGeneric.IRepositories;

namespace BeverageProject.Controllers.Api
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUsersRepository _usersRepo;
        public UsersController(IUsersRepository usersRepo) {
            _usersRepo = usersRepo;
        }
        // GET
        [HttpGet]
        public async Task<IHttpActionResult> GetUserInfo() {
            var userEmail = User.Identity.GetUserName();
            var user = await _usersRepo.GetUserByUserName(userEmail);
            return Ok(user);
        }
    }
}