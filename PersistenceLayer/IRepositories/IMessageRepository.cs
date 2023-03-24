using Entities.Messages;
using PersistenceLayer.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersistenceLayer.IRepositories
{
    public interface IMessageRepository
    {
        Task<IList<MessageDto>> GetAll();
        Task<MessageDto> PostMessage(MessageDto messageDto);
    }
}
