using System.Threading.Tasks;
using Contracts.Contracts.Category;
using Contracts.Contracts.Product;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class ProductService : ServiceBase<ProductRepository, ProductDto>
    {
        private readonly CategoryService _categoryService;
        
        public ProductService(ProductRepository recordRepository, CategoryService categoryService) : base(recordRepository)
        {
            _categoryService = categoryService;
        }
        
        public async Task<OperationResult<ProductDto>> TryCreate(ProductApiDto apiModel)
        {
            OperationResult<ProductDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Create(result.Result);
            }

            return result;
        }

        public async Task<OperationResult<ProductDto>> TryUpdate(ProductApiDto apiModel)
        {
            OperationResult<ProductDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Update(result.Result);
            }

            return result;
        }
        
        public override Task<OperationResult<ProductDto>> TryCreate(ProductDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<ProductDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<ProductDto>> TryUpdate(ProductDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<ProductDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<bool>> TryDelete(int modelId)
        {
            string message = "You have no permission";

            var result = OperationResult<bool>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }
        
        private async Task<OperationResult<ProductDto>> GetModelByModelApi(ProductApiDto apiModel)
        {
            CategoryDto category;

            var categoryResult = await _categoryService.TryGet(apiModel.CategoryId);

            if (categoryResult.IsSuccess)
            {
                category = categoryResult.Result;
            }
            else
            {
                return OperationResult<ProductDto>.GetUnsuccessfulResult(categoryResult.Error.Message);
            }

            var product = new ProductDto
            {
                Art = apiModel.Art,
                Manufacture = apiModel.Manufacture,
                Name = apiModel.Name,
                Category = category,
                PackageType = apiModel.PackageType,
                PackageNumber = apiModel.PackageNumber,
                Quantity = apiModel.Quantity,
                Price = apiModel.Price,
                MinimalOrder = apiModel.MinimalOrder,
                Weight = apiModel.Weight,
                Height = apiModel.Height,
                Width = apiModel.Width,
                Length = apiModel.Length,
                Description = apiModel.Description,
                IsDiscount = apiModel.IsDiscount,
                Reason = apiModel.Reason
            };

            return OperationResult<ProductDto>.GetSuccessResult(product);
        }
    }
}