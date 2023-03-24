using System;
using System.Threading.Tasks;
using Entities.IdentityUsers;

namespace PersistenceLayer.IRepositories
{
    public interface IUsersRepository
    {
        Task<ApplicationUser> GetUserByUserName(string username);
        Task PostUserPhone(string userName, string phone);
    }
}