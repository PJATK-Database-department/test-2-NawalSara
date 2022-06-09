using APBD_Tutorial13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Tutorial13.Services
{
    public interface IConfectioneryDbService
    {
        public List<OrdersResponce> GetAllOrders(int id);
    }
}
