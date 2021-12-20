using Contracts.Contracts.Category;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Base;

namespace Services.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<CategoryDto>
    {
        public CategoryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}