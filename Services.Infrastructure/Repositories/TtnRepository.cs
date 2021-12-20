using Contracts.Contracts.Ttn;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Base;

namespace Services.Infrastructure.Repositories
{
    public class TtnRepository : RepositoryBase<TtnDto>
    {
        public TtnRepository(ApplicationContext context) : base(context)
        {
        }
    }
}