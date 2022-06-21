using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Tutorial13.Models
{
    public class OrdersResponce
    {
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Confectionery { get; set; }
        public string Quantity { get; set; }
    }
}
