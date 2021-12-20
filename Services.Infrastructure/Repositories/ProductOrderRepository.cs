using Contracts.Contracts.ProductOrder;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Base;

namespace Services.Infrastructure.Repositories
{
    public class ProductOrderRepository : RepositoryBase<ProductOrderDto>
    {
        public ProductOrderRepository(ApplicationContext context) : base(context)
        {
        }
    }
}