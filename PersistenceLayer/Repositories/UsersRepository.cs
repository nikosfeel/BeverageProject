using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Entities.IdentityUsers;
using ApplicationDatabase;
using PersistenceLayer.IRepositories;

namespace PersistenceLayer.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        public UsersRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<ApplicationUser> GetUserByUserName(string username) {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            return user;
        }

        public async Task PostUserPhone(string userName, string phone) {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (string.IsNullOrEmpty(user.PhoneNumber)) {
                user.PhoneNumber = phone;
                await _context.SaveChangesAsync();
            }
        }
    }
}