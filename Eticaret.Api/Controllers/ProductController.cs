using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteReposirtory _productService;
        private readonly IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteReposirtory productService,IProductReadRepository productReadRepository)
        {
            _productService = productService;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            await _productService.AddAsync(new() { Name = "yasin",Id = Guid.NewGuid(),CDateTime = DateTime.Now});
         
            await _productService.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _productReadRepository.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("geltaşş")]
        public  IActionResult GetAll()
        {
            var result =  _productReadRepository.GetAll();
            return Ok(result);
        }
        

      
    }
}
