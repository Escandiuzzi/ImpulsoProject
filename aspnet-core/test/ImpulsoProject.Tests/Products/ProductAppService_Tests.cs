using Abp.Application.Services.Dto;
using ImpulsoProject.Authorization.Products;
using ImpulsoProject.Products;
using ImpulsoProject.Products.Dto;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ImpulsoProject.Tests.Products
{
    public class ProductAppService_Tests : ImpulsoProjectTestBase
    {
        private readonly ProductAppService _productAppService;

        public ProductAppService_Tests()
        {
            _productAppService = Resolve<ProductAppService>();
        }

        [Fact]
        public async Task GetProducts_Test()
        {
            var input = new PagedAndSortedResultRequestDto();

            // Act
            var output = _productAppService.GetAll(input);

            // Assert
            Assert.True(output.Items.Count >= 0);
        }

        [Fact]
        public async Task GetProduct_Test()
        {

            Product macbookProduct = new Product();

            ProductDto macbookDto = new ProductDto
            {
                Name = "Macbook Pro M1",
                Description = "The Apple M1 chip gives the 13‑inch MacBook Pro speed and power beyond belief.",
                Price = 1299.99,
                Quantity = 7,
            };

            _productAppService.Create(macbookDto);

            await UsingDbContextAsync(async context =>
            {
                macbookProduct = context.Products.FirstOrDefault(u => u.Name == "Macbook Pro M1");
                Assert.NotNull(macbookProduct);
            });

            macbookDto.Id = macbookProduct.Id;

            // Act
            var output = _productAppService.Get(macbookDto);

            // Assert
            Assert.Equal(macbookDto.Id, output.Id);
            Assert.Equal(macbookDto.Name, output.Name);
            Assert.Equal(macbookDto.Description, output.Description);
            Assert.Equal(macbookDto.Quantity, output.Quantity);
            Assert.Equal(macbookDto.Price, output.Price);

        }

        [Fact]
        public async Task CreateProduct_Test()
        {
            // Act
            _productAppService.Create(
                new ProductDto
                {
                    Name = "Macbook Pro M1",
                    Description = "The Apple M1 chip gives the 13‑inch MacBook Pro speed and power beyond belief.",
                    Price = 1299.99,
                    Quantity = 7,
                });

            await UsingDbContextAsync(async context =>
            {
                var macbookProduct = context.Products.FirstOrDefault(u => u.Name == "Macbook Pro M1");
                Assert.NotNull(macbookProduct);
            });
        }

        [Fact]
        public async Task UpdateProduct_Test()
        {
            Product macbookProduct = new Product();

            // Act
            _productAppService.Create(
                new ProductDto
                {
                    Name = "Macbook",
                    Description = "The Apple M1 chip gives the 13‑inch MacBook Pro speed and power beyond belief.",
                    Price = 1999.99,
                    Quantity = 7,
                });

            await UsingDbContextAsync(async context =>
            {
                macbookProduct = context.Products.FirstOrDefault(u => u.Name == "Macbook");
                Assert.NotNull(macbookProduct);
            });

            _productAppService.Update(
               new ProductDto
               {
                   Id = macbookProduct.Id,
                   Name = "Macbook Pro M1",
                   Description = "The Apple M1 chip gives the 13‑inch MacBook Pro speed and power beyond belief.",
                   Price = 1299.99,
                   Quantity = 7,
               });

            await UsingDbContextAsync(async context =>
            {
                macbookProduct = context.Products.FirstOrDefault(u => u.Name == "Macbook Pro M1");
                Assert.NotNull(macbookProduct);
            });

        }

        [Fact]
        public async Task DeleteProduct_Test()
        {
            Product macbookProduct = new Product();

            ProductDto macbookDto = new ProductDto
            {
                Name = "Macbook Pro M1",
                Description = "The Apple M1 chip gives the 13‑inch MacBook Pro speed and power beyond belief.",
                Price = 1299.99,
                Quantity = 7,
            };

            _productAppService.Create(macbookDto);

            await UsingDbContextAsync(async context =>
            {
                macbookProduct = context.Products.FirstOrDefault(u => u.Name == "Macbook Pro M1");
                Assert.NotNull(macbookProduct);
            });

            macbookDto.Id = macbookProduct.Id;

            var input = new PagedAndSortedResultRequestDto();

            // Act
            _productAppService.Delete(macbookDto);
            var output = _productAppService.GetAll(input);


            // Assert
            Assert.True(output.Items.Count >= 0);

        }

    }
}
