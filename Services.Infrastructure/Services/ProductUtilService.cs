using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Product;
using Contracts.Contracts.ProductUtil;
using Contracts.Contracts.Utilization;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class ProductUtilService : ServiceBase<ProductUtilRepository, ProductUtilDto>
    {
        private readonly ProductService _productService;
        private readonly EmployeeService _employeeService;
        
        public ProductUtilService(
            ProductUtilRepository recordRepository,
            ProductService productService,
            EmployeeService employeeService) : base(recordRepository)
        {
            _productService = productService;
            _employeeService = employeeService;
        }

        public async Task<OperationResult<List<ProductUtilDto>>> TryCreateUtilProductsByUtilization(
            UtilizationDto utilization, List<ProductUtilApiDto> utilProducts)
        {
            var result = new List<ProductUtilDto>();
            
            foreach (ProductUtilApiDto utilProduct in utilProducts)
            {
                var employeeResult = await _employeeService.TryGet(utilProduct.EmployeeId);
                var productResult = await _productService.TryGet(utilProduct.ProductId);

                if (!productResult.IsSuccess)
                {
                    return OperationResult<List<ProductUtilDto>>.GetUnsuccessfulResult(productResult.Error.Message);
                }
                
                if (!employeeResult.IsSuccess)
                {
                    return OperationResult<List<ProductUtilDto>>.GetUnsuccessfulResult(employeeResult.Error.Message);
                }

                ProductDto product = productResult.Result;

                var model = new ProductUtilDto
                {
                    Utilization = utilization,
                    Employee = employeeResult.Result,
                    Product = product,
                    Quantity = utilProduct.Quantity,
                    Reason = utilProduct.Reason
                };

                var createProductUtilResult = await Repository.Create(model);

                if (!createProductUtilResult.IsSuccess)
                {
                    return OperationResult<List<ProductUtilDto>>.GetUnsuccessfulResult(createProductUtilResult
                        .Error.Message);
                }

                result.Add(model);

                int newQuantity = product.Quantity -= utilProduct.Quantity;

                var changeQuantityResult = await _productService.TryChangeQuantity(product, newQuantity);

                if (!changeQuantityResult.IsSuccess)
                {
                    foreach (var createdUtilProduct in result)
                    {
                        await Repository.Delete(createdUtilProduct.Id);
                    }

                    return OperationResult<List<ProductUtilDto>>.GetUnsuccessfulResult(changeQuantityResult.Error
                        .Message);
                }
            }

            return OperationResult<List<ProductUtilDto>>.GetSuccessResult(result);
        }
    }
}