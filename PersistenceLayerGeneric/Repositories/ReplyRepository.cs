using MyDatabase;
using PersistenceLayerGeneric.Dtos;
using PersistenceLayerGeneric.IRepositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PersistenceLayerGeneric.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly ApplicationDbContext _context;
        public ReplyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ReplyDto>> GetAllByMessage(int messageId)
        {
            return await _context.Replies
                .Where(x=>x.MessageId == messageId)
                .Select(x=> new ReplyDto()
                { 
                    Description = x.Description,
                    Id = x.Id,
                    MessageId = x.MessageId
                }).ToListAsync();
        }
    }
}
