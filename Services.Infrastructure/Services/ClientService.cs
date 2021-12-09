using Contracts.Contracts.Records;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;

namespace Services.Infrastructure.Services
{
    public class ClientService : RecordServiceBase<ClientRepository, ClientRecordDto>
    {
        public ClientService(ClientRepository recordRepository) : base(recordRepository)
        {
        }
    }
}