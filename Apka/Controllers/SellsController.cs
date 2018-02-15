using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace Apka.Controllers
{
    public class SellsController : ApiController
    {
        public IEnumerable<Sell> Get()
        {
            using (ShopEntities entities = new ShopEntities())
            {
                return entities.Sells.ToList();
            }
        }
        public Sell Get(int id)
        {
            using (ShopEntities entities = new ShopEntities())
            {
                return entities.Sells.FirstOrDefault(e => e.SellID == id);
            }
        }
    }
}
