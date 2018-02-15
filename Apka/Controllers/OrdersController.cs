using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace Apka.Controllers
{
    public class OrdersController : ApiController
    {
        public IEnumerable<Order> Get()
        {
            using (ShopEntities entities = new ShopEntities())
            {
                return entities.Orders.ToList();
            }
        }
        public Order Get(int id)
        {
            using (ShopEntities entities = new ShopEntities())
            {
                return entities.Orders.FirstOrDefault(e => e.OrderID == id);
            }
        }
    }
}
