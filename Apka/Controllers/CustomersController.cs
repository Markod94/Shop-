using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace Apka.Controllers
{
    public class CustomersController : ApiController
    {
        public IEnumerable<Customer> Get()
        {
            using (ShopEntities entities = new ShopEntities())
            {
                return entities.Customers.ToList();
            }
        }
        public Customer Get(int id)
        {
            using (ShopEntities entities = new ShopEntities())
            {
                return entities.Customers.FirstOrDefault(e => e.CustomerID == id);
            }
        }
    }
}
