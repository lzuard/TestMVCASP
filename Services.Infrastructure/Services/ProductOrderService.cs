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
        
        public ProductOrderService(ProductOrderRepository recordRepository,
            ProductService productService) : base(recordRepository)
        {
            _productService = productService;
        }

        public async Task<OperationResult<bool>> CreateProductOrderByOrder(OrderDto order,
            List<ProductOrderApiDto> orderProducts)
        {
            foreach (ProductOrderApiDto productOrder in orderProducts)
            {
                var productResult = await _productService.TryGet(productOrder.ProductId);

                if (!productResult.IsSuccess)
                {
                    return OperationResult<bool>.GetUnsuccessfulResult(productResult.Error
                        .Message);
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
                    return OperationResult<bool>.GetUnsuccessfulResult(createProductOrderResult.Error.Message);
                }

                if (product.Quantity - productOrder.Quantity < 0)
                {
                    string message = $"The quantity of goods in stock cannot be negative {product.Name}";
                    
                    return OperationResult<bool>.GetUnsuccessfulResult(message);
                }
                
                product.Quantity -= productOrder.Quantity;

                var updateProductResult = await _productService.TryUpdate(product);
                
                if (!updateProductResult.IsSuccess)
                {
                    return OperationResult<bool>.GetUnsuccessfulResult(updateProductResult.Error.Message);
                }
            }

            return OperationResult<bool>.GetSuccessResult(true);
        }
    }
}