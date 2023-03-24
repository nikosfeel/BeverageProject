using ApplicationDatabase;
using PersistenceLayer.Dtos;
using PersistenceLayer.IRepositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Entities.Messages;

namespace PersistenceLayer.Repositories
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

        public async Task<MessageDto> PostMessage(MessageDto messageDto) {
            var message = new Message() {
                Name = messageDto.Name,
                Phone = messageDto.Phone,
                Theme = messageDto.Theme,
                Description = messageDto.Description,
                Email = messageDto.Email,
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            messageDto.Id = message.Id;

            return messageDto;
        }
    }
}
