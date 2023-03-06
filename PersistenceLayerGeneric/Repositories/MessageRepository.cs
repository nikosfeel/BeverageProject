using MyDatabase;
using PersistenceLayerGeneric.Dtos;
using PersistenceLayerGeneric.IRepositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PersistenceLayerGeneric.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<MessageDto>> GetAll()
        {
            return await _context.Messages.Select(x => 
            new MessageDto()
            {
                Id = x.Id,
                Description = x.Description,
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone,
                Theme = x.Theme
            }).ToListAsync();
        }
    }
}
