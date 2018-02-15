using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace Apka.Controllers
{
    public class EmpolyeesController : ApiController
    {
        public IEnumerable<Empleyee> Get()
        {
            using(ShopEntities entities = new ShopEntities())
            {
                return entities.Empleyees.ToList();
            }
        }
        public Empleyee Get(int id)
        {
            using (ShopEntities entities = new ShopEntities())
            {
                return entities.Empleyees.FirstOrDefault(e => e.EmpleyeeID == id);
            }
        }
    }
}
