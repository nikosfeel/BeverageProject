using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Messages
{
    public class Reply
    {
        public Reply()
        {
            ReplyDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string Description { get; set; }
        public DateTime ReplyDate { get; set; }

        public virtual Message Message { get; set; }
    }
}
