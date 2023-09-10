using AutoMapper;
using ETicaretAPİ.APİ.Filters;
using ETicaretAPİ.Apllication.Services;
using ETicaretAPİ.Domain.Entities;
using ETicaretAPİ.Domain.Entities.DTOs;
using ETicaretAPİ.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPİ.APİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        private readonly IProductService productService;

        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = service;
            this.productService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {   
            var product = await productService.GetAllAsync();
            var GetProductsWithCategory = _mapper.Map<Product>(product);
            return Ok(GetProductsWithCategory);   
        }

        [HttpGet]

        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();

            var productsDtos = _mapper.Map<List<ProductDTO>>(products.ToList());
            // return Ok(CustomResponseDto<List<ProductDTO>>.Success(200,productsDtos));

            return Ok(productsDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            var productsDto = _mapper.Map<ProductDTO>(product);
            return Ok(productsDto);

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));

            var productsDtos = _mapper.Map<ProductDTO>(product);

            return Ok(Save(productDto));
           // return StatusCode(StatusCodes.Status201Created,productsDtos);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductDTO productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
          var product = await _service.GetByIdAsync(id);
          await _service.RemoveAsync(product);

          return NoContent();
        }






    }
}
