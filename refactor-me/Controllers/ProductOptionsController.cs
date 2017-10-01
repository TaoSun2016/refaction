using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using refactor_me.Models;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductOptionsController : ApiController
    {
        private ProductOptionRepository db = new ProductOptionRepository();

        // 1. GET: products/productId/options
        [Route("{productId}/options")]
        [HttpGet]
        public IQueryable<ProductOption> GetProductOptions(Guid productId)
        {
            return db.GetAll().Where(m => m.ProductId == productId);
        }

        // 2. GET: products/productId/options/id
        [Route("{productId}/options/{id}")]
        [HttpGet]
        [ResponseType(typeof(ProductOption))]
        public IHttpActionResult GetProductOption(Guid productId, Guid id)
        {
            ProductOption productOption = db.GetOne(id);

            if (productOption == null)
            {
                return NotFound();
            }

            return Ok(productOption);
        }

        // 3. POST: products/productId/options
        [Route("{productId}/options")]
        [HttpPost]
        [ResponseType(typeof(ProductOption))]
        public IHttpActionResult PostProductOption(Guid productId, ProductOption productOption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                productOption.ProductId = productId;
                db.Add(productOption);
            }
            catch (DbUpdateException)
            {
                if (ProductOptionExists(productOption.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return GetProductOption( productId, productOption.Id);
        }



        // 4. PUT: products/productId/options/id
        [Route("{productId}/options/{id}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductOption(Guid id, ProductOption productOption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productOption.Id)
            {
                return BadRequest();
            }

            try
            {
                db.Update(id,productOption);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOptionExists(id))
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

        // 5. DELETE: products/productId/options/id
        [Route("{productId}/options/{id}")]
        [HttpDelete]
        [ResponseType(typeof(ProductOption))]
        public IHttpActionResult DeleteProductOption(Guid id)
        {
            ProductOption productOption = db.GetOne(id);

            if (productOption == null)
            {
                return NotFound();
            }

            db.Delete(productOption);

            return Ok(productOption);
        }

        private bool ProductOptionExists(Guid id)
        {
            return db.Table.Count(e => e.Id == id) > 0;
        }
    }
}