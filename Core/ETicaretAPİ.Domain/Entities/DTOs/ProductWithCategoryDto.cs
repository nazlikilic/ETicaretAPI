using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPİ.Domain.Entities.DTOs
{
    public class ProductWithCategoryDto : ProductDTO
    {
        public CategoryDTO Category { get; set; }
    }
}
