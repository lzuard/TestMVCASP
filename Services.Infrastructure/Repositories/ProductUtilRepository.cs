using Contracts.Contracts.ProductUtil;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Base;

namespace Services.Infrastructure.Repositories
{
    public class ProductUtilRepository : RepositoryBase<ProductUtilDto>
    {
        public ProductUtilRepository(ApplicationContext context) : base(context)
        {
        }
    }
}