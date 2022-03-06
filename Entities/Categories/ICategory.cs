using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Categories
{
    public interface ICategory
    {
        int Id { get; set; }
        string Title { get; set; }
        string Kind { get; set; }

       
    }
}
