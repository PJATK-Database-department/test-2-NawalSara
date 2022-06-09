using APBD_Tutorial13.Entities;
using APBD_Tutorial13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Tutorial13.Services
{
    public class ConfectioneryDbService: IConfectioneryDbService
    {
        public CustomerDbContext _dbContext;

        public ConfectioneryDbService(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OrdersResponce> GetAllOrders(int id)
        {
            List<OrdersResponce> result = new List<OrdersResponce>();
            List<ClientOrder> orders;
            if(id != 0)
            {
                if (!_dbContext.Order.Any(e => e.IdClient == id)) { return null; }
                orders = _dbContext.Order.Where(e => e.IdClient == id).ToList();
            }
            else
            {
                if (!_dbContext.Order.Any()) { return null; }
                orders = _dbContext.Order.ToList();
            }

            foreach (var order in orders)
            {
                result.Add(new OrdersResponce
                {
                    IdOrder = order.IdOrder,
                    DateAccepted = order.DateAccepted,
                    DateFinished = order.DateFinished,
                    Confectionery = _dbContext.Confectionery.Where(e => e.IdConectionery == _dbContext.Confectionery_Order
                                                    .Where(e => e.IdOrder == order.IdOrder)
                                                    .Select(e => e.IdConfection).FirstOrDefault())
                                                    .Select(e => e.Name).FirstOrDefault().ToString(),
                    Quantity = _dbContext.Confectionery_Order.Where(e => e.IdOrder == order.IdOrder).Select(e => e.Quantity).FirstOrDefault().ToString()
                });
            }
            return result;
        }

    }
}
