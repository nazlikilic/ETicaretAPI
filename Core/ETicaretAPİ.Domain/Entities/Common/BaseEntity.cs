﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPİ.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
       public int Id { get; set; }
       public DateTime CreatedDate { get; set; }
       public DateTime UpdatedDate { get; set;}

    }
}
