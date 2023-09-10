using ETicaretAPİ.Domain.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPİ.Persistence.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDTO>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("(PropertyName) is required").NotEmpty().WithMessage("(PropertyName) is required");

            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("(Price) must be grater 0");

            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("(Stock) must be grater 0");

            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("(CategoryId) must be grater 0");
        }

    }
}
