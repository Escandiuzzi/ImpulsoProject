using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsoProject.Authorization.Products
{
    public class Product : Entity<int>
    {
      
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

    }
}
