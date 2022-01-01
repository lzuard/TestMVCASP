using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Product;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<ProductDto>
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<OperationResult<IEnumerable<ProductDto>>> GetAll()
        {
            IEnumerable<ProductDto> result = await Context.Products
                .Include(x => x.Category)
                .Include(x => x.Category.ParentCategory)
                .ToListAsync();

            return OperationResult<IEnumerable<ProductDto>>.GetSuccessResult(result);
        }

        public override async Task<OperationResult<ProductDto>> Get(int modelId)
        {
            ProductDto model = await Context.Products
                .Include(x => x.Category)
                .Include(x => x.Category.ParentCategory)
                .FirstOrDefaultAsync(x => x.Id == modelId);

            if (model == null)
            {
                string error = $"{typeof(ProductDto)} with id {modelId} not found";

                return OperationResult<ProductDto>.GetUnsuccessfulResult(error);
            }

            return OperationResult<ProductDto>.GetSuccessResult(model);
        }
    }
}