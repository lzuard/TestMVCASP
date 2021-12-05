using Contracts.Contracts;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Base;

namespace Services.Infrastructure.Repositories
{
    public class ClientRepository : RepositoryBase<ClientDto>
    {
        public ClientRepository(ApplicationContext context) : base(context)
        {
        }
    }
}