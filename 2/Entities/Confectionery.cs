using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Tutorial13.Entities
{
    public class Confectionery
    {
        public int IdConectionery { get; set; }
        public string Name { get; set; }
        public double PricePerItem { get; set; }
        public string Type { get; set; }
        public ICollection<Confectionery_ClientOrder> Conf_orders { get; set; }
    }
}
