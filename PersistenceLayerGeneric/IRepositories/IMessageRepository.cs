using Entities.Messages;
using PersistenceLayerGeneric.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersistenceLayerGeneric.IRepositories
{
    public interface IMessageRepository
    {
        Task<IList<MessageDto>> GetAll();
        Task<MessageDto> PostMessage(MessageDto messageDto);
    }
}
