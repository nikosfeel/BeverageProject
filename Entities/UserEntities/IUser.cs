using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UserEntities
{
    public interface IUser
    {
        int ID { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }




    }
}
