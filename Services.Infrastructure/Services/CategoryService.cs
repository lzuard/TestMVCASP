using System.Threading.Tasks;
using Contracts.Contracts.Category;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class CategoryService : ServiceBase<CategoryRepository, CategoryDto>
    {
        public CategoryService(CategoryRepository recordRepository) : base(recordRepository)
        {
        }

        public async Task<OperationResult<CategoryDto>> TryCreate(CategoryApiDto apiModel)
        {
            CategoryDto parentCategory = null;

            if (apiModel.ParentCategoryId != null)
            {
                var result = await Repository.Get((int)apiModel.ParentCategoryId);

                if (result.IsSuccess)
                {
                    parentCategory = result.Result;
                }
                else
                {
                    return OperationResult<CategoryDto>.GetUnsuccessfulResult(result.Error.Message);
                }
            }

            var category = new CategoryDto
            {
                Name = apiModel.Name,
                ParentCategory = parentCategory
            };

            return await Repository.Create(category);
        }

        public async Task<OperationResult<CategoryDto>> TryUpdate(CategoryApiDto apiModel)
        {
            CategoryDto parentCategory = null;

            if (apiModel.ParentCategoryId != null)
            {
                var result = await Repository.Get((int)apiModel.ParentCategoryId);

                if (result.IsSuccess)
                {
                    parentCategory = result.Result;
                }
                else
                {
                    return OperationResult<CategoryDto>.GetUnsuccessfulResult(result.Error.Message);
                }
            }

            var category = new CategoryDto
            {
                Name = apiModel.Name,
                ParentCategory = parentCategory
            };

            return await Repository.Update(category);
        }

        public override Task<OperationResult<CategoryDto>> TryCreate(CategoryDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<CategoryDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<CategoryDto>> TryUpdate(CategoryDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<CategoryDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<bool>> TryDelete(int modelId)
        {
            string message = "You have no permission";

            var result = OperationResult<bool>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }
    }
}