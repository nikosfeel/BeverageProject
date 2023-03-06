using PersistenceLayerGeneric.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersistenceLayerGeneric.IRepositories
{
    public interface IReplyRepository
    {
        Task<IList<ReplyDto>> GetAllByMessage(int messageId);
    }
}
