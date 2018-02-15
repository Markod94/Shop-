using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace Apka.Controllers
{
    public class ProductsController : ApiController
    {
        public IEnumerable<Product> Get()
        {
            using (ShopEntities entities = new ShopEntities())
            {
                return entities.Products.ToList();
            }
        }
        public Product Get(int id)
        {
            using (ShopEntities entities = new ShopEntities())
            {
                return entities.Products.FirstOrDefault(e => e.ProductID == id);
            }
        }
    }
}
