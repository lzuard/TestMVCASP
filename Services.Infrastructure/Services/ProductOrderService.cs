using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Order;
using Contracts.Contracts.Product;
using Contracts.Contracts.ProductOrder;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class ProductOrderService : ServiceBase<ProductOrderRepository, ProductOrderDto>
    {
        private readonly ProductService _productService;

        public ProductOrderService(
            ProductOrderRepository recordRepository,
            ProductService productService)
            : base(recordRepository)
        {
            _productService = productService;
        }

        public async Task<OperationResult<List<ProductOrderDto>>> TryCreateProductOrderByOrder(OrderDto order,
            List<ProductOrderApiDto> orderProducts)
        {
            var createdOrderProducts = new List<ProductOrderDto>();

            foreach (ProductOrderApiDto productOrder in orderProducts)
            {
                var productResult = await _productService.TryGet(productOrder.ProductId);

                if (!productResult.IsSuccess)
                {
                    return OperationResult<List<ProductOrderDto>>.GetUnsuccessfulResult(productResult.Error.Message);
                }

                ProductDto product = productResult.Result;

                var model = new ProductOrderDto
                {
                    Order = order,
                    Product = product,
                    Quantity = productOrder.Quantity
                };

                var createProductOrderResult = await Repository.Create(model);

                if (!createProductOrderResult.IsSuccess)
                {
                    return OperationResult<List<ProductOrderDto>>.GetUnsuccessfulResult(createProductOrderResult.Error
                        .Message);
                }

                createdOrderProducts.Add(model);

                int newQuantity = product.Quantity -= productOrder.Quantity;

                var changeQuantityResult = await _productService.TryChangeQuantity(product, newQuantity);

                if (!changeQuantityResult.IsSuccess)
                {
                    foreach (var createdSupplyProduct in createdOrderProducts)
                    {
                        await Repository.Delete(createdSupplyProduct.Id);
                    }

                    return OperationResult<List<ProductOrderDto>>.GetUnsuccessfulResult(changeQuantityResult.Error
                        .Message);
                }
            }

            return OperationResult<List<ProductOrderDto>>.GetSuccessResult(createdOrderProducts);
        }
    }
}