using System;
using System.Threading.Tasks;
using Entities.IdentityUsers;

namespace PersistenceLayerGeneric.IRepositories
{
    public interface IUsersRepository
    {
        Task<ApplicationUser> GetUserByUserName(string username);
        Task PostUserPhone(string userName, string phone);
    }
}