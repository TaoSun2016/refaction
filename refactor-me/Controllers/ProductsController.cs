using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using refactor_me.Models;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private ProductRepository db = new ProductRepository();

        // 1. GET: Products
        [Route]
        [HttpGet]
        public IQueryable<Product> GetProducts()
        {
            return db.GetAll();
        }

        // 2. GET: Products/name
        [Route]
        [HttpGet]
        public IQueryable<Product> GetByName(string name)
        {
            return db.GetByName(name);
        }

        // 3. GET: Products/5
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(Guid id)
        {           
            Product product = db.GetOne(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // 4. POST: Products
        [Route]
        [HttpPost]
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Add(product);
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return GetProduct(product.Id);
        }

        // 5. PUT: Products/5
        [Route("{id}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(Guid id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                db.Update(id, product);               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // 6. DELETE: api/Products/5
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(Guid id)
        {
            Product product = db.GetOne(id);

            if (product == null)
            {
                return NotFound();
            }

            db.Delete(product);

            return Ok(product);
        }

        private bool ProductExists(Guid id)
        {
            return db.Table.Count(e => e.Id == id) > 0;
        }
    }
}