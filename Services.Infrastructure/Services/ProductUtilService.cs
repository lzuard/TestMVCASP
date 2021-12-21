using Contracts.Contracts.ProductUtil;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;

namespace Services.Infrastructure.Services
{
    public class ProductUtilService : ServiceBase<ProductUtilRepository,ProductUtilDto>
    {
        public ProductUtilService(ProductUtilRepository recordRepository) : base(recordRepository)
        {
        }
    }
}