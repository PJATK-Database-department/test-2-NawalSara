using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Tutorial13.Entities
{
    public class Employee
    {
        public int IdEmpl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ClientOrder> Orders { get; set; }
    }
}
