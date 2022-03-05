using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.UserEntities;

namespace Entities
{
    public class Supplier : IUser
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public Supplier(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }
    }
}
