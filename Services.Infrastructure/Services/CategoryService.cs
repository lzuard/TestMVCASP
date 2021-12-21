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
            OperationResult<CategoryDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Create(result.Result);
            }

            return result;
        }

        public async Task<OperationResult<CategoryDto>> TryUpdate(CategoryApiDto apiModel)
        {
            OperationResult<CategoryDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Update(result.Result);
            }

            return result;
        }

        private async Task<OperationResult<CategoryDto>> GetModelByModelApi(CategoryApiDto apiModel)
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

            return OperationResult<CategoryDto>.GetSuccessResult(category);
        }
    }
}