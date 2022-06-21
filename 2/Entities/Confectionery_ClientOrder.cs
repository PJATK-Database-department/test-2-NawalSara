using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Tutorial13.Entities
{
    public class Confectionery_ClientOrder
    {
        public int IdConfection { get; set; }
        public int IdOrder { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public ClientOrder Order { get; set; }
        public Confectionery Conf { get; set; }
    }
}
