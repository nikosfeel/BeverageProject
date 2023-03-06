using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Messages
{
    public class Message
    {
        public Message()
        {
            Replies = new List<Reply>();
            DateCreated = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is is not valid.")]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Theme { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<Reply> Replies { get; set; }
    }
}
