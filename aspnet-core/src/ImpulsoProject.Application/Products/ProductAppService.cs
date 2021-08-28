using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ImpulsoProject.Authorization;
using ImpulsoProject.Authorization.Products;
using ImpulsoProject.Products.Dto;

namespace ImpulsoProject.Products
{
    [AbpAuthorize(PermissionNames.Pages_Products)]
    public class ProductAppService : CrudAppService<Product, ProductDto>
    {
        public ProductAppService(IRepository<Product, int> repository) : base(repository)
        {
        }
    }
}
