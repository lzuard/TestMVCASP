using Contracts.Contracts.Records;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Base;

namespace Services.Infrastructure.Repositories
{
    public class ClientRepository : RecordRepositoryBase<ClientRecordDto>
    {
        public ClientRepository(ApplicationContext context) : base(context)
        {
        }
    }
}