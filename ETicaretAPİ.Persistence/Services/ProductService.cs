using AutoMapper;
using ETicaretAPİ.Apllication.Repositories;
using ETicaretAPİ.Apllication.Services;
using ETicaretAPİ.Apllication.UnitOfWorks;
using ETicaretAPİ.Domain.Entities;
using ETicaretAPİ.Domain.Entities.DTOs;
using ETicaretAPİ.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPİ.Persistence.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsWithCategory();
            var productsDto= _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
