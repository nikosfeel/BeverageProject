using PersistenceLayer.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersistenceLayer.IRepositories
{
    public interface IReplyRepository
    {
        Task<IList<ReplyDto>> GetAllByMessage(int messageId);
    }
}
