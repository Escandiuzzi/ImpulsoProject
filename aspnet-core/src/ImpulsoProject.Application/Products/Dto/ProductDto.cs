using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ImpulsoProject.Authorization.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImpulsoProject.Products.Dto
{
    [AutoMapFrom(typeof(Product))]
    [AutoMapTo(typeof(Product))]
    public class ProductDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
