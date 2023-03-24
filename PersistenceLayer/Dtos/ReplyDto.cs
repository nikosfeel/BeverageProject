using Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Dtos
{
    public class ReplyDto
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string Description { get; set; }

        public Message Message { get; set; }
    }
}
