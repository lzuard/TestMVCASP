using Contracts.Contracts.Product;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Base;

namespace Services.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<ProductDto>
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }
    }
}