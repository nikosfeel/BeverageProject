using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeverageProject.Models.Dtos
{
    public class OrderDto
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}