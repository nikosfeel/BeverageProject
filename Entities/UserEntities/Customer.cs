using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UserEntities
{
    public class Customer : IUser
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public Customer(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }

    }
}
