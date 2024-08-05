using System.Net;
using Eticaret.Application.Repositories;
using Eticaret.Application.RequestParameters;
using Eticaret.Application.ViewModels.Products;
using Eticaret.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteReposirtory _productWriteService;
        private readonly IProductReadRepository _productReadRepository;
      

        public ProductController(IProductWriteReposirtory productService,IProductReadRepository productReadRepository )
        {
            _productWriteService = productService;
            _productReadRepository = productReadRepository;
            
        }

        [HttpGet]
        public  IActionResult Get([FromQuery]Pagination pagination)
        {
              var totalCount = _productReadRepository.GetAll(false).Count();
              var products=  _productReadRepository
                  .GetAll(false)
                  .Skip(pagination.Page*pagination.Size)
                  .Take(pagination.Size)
                  .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.Stock,
                    p.CDateTime,
                    p.UpdDateTime

                }).ToList();
               return Ok(new{totalCount,products});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            if (ModelState.IsValid)
            {
                
            }
            await _productWriteService.AddAsync(new()
            {
                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price
                
            });
            await _productWriteService.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
           Product product= await _productReadRepository.GetByIdAsync(model.Id);
           product.Name = model.Name;
           product.Stock = model.Stock;
           product.Price = product.Price;
           await _productWriteService.SaveAsync();
            return Ok();
        }

        [HttpDelete( "{id}")]

        public async Task<IActionResult> Delete(string id)
        {
           await _productWriteService.RemoveAsync(id);
            await _productWriteService.SaveAsync();
            return Ok();

        }





    }
}
