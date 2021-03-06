using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductReviews.Interfaces;
using ProductReviews.DAL.EntityFramework.Entities;

namespace ProductReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupRepository _repository;

        public ProductGroupController(IProductGroupRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ICollection<ProductGroup>> Get([FromQuery]int page = 1, int count = 10)
        {
            return await _repository.GetAsync(page, count);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroup>> Get([FromRoute]int id)
        {
            var pg = await _repository.GetByIdAsync(id);
            if (pg == null) return NotFound();
            return pg;
        }
        [HttpPost]
        public async Task<ProductGroup> Post([FromBody]ProductGroup productGroup)
        {
            return await _repository.AddAsync(productGroup);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductGroup>> Put(int id, [FromBody]ProductGroup productGroup)
        {
            productGroup.Id = id;
            return await _repository.UpdateAsync(productGroup);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}