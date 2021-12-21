using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Product;
using Contracts.Contracts.ProductSupply;
using Contracts.Contracts.Supply;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class ProductSupplyService : ServiceBase<ProductSupplyRepository, ProductSupplyDto>
    {
        private readonly ProductService _productService;

        public ProductSupplyService(
            ProductSupplyRepository recordRepository,
            ProductService productService)
            : base(recordRepository)
        {
            _productService = productService;
        }

        public async Task<OperationResult<List<ProductSupplyDto>>> CreateSupplyProductsByOrder(
            SupplyDto supply,
            List<ProductSupplyApiDto> supplyProducts)
        {
            var createdSupplyProducts = new List<ProductSupplyDto>();

            foreach (ProductSupplyApiDto supplyProduct in supplyProducts)
            {
                var productResult = await _productService.TryGet(supplyProduct.ProductId);

                if (!productResult.IsSuccess)
                {
                    return OperationResult<List<ProductSupplyDto>>.GetUnsuccessfulResult(productResult.Error.Message);
                }

                ProductDto product = productResult.Result;

                var model = new ProductSupplyDto
                {
                    Supply = supply,
                    Product = product,
                    Quantity = supplyProduct.Quantity
                };

                var createProductSupplyResult = await Repository.Create(model);

                if (!createProductSupplyResult.IsSuccess)
                {
                    return OperationResult<List<ProductSupplyDto>>.GetUnsuccessfulResult(createProductSupplyResult
                        .Error.Message);
                }

                createdSupplyProducts.Add(model);

                int newQuantity = product.Quantity -= supplyProduct.Quantity;

                var changeQuantityResult = await _productService.TryChangeQuantity(product, newQuantity);

                if (!changeQuantityResult.IsSuccess)
                {
                    foreach (var createdSupplyProduct in createdSupplyProducts)
                    {
                        await Repository.Delete(createdSupplyProduct.Id);
                    }

                    return OperationResult<List<ProductSupplyDto>>.GetUnsuccessfulResult(changeQuantityResult.Error
                        .Message);
                }
            }

            return OperationResult<List<ProductSupplyDto>>.GetSuccessResult(createdSupplyProducts);
        }
    }
}