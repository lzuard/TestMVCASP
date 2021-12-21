using Contracts.Contracts.ProductSupply;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Base;

namespace Services.Infrastructure.Repositories
{
    public class ProductSupplyRepository : RepositoryBase<ProductSupplyDto>
    {
        public ProductSupplyRepository(ApplicationContext context) : base(context)
        {
        }
    }
}