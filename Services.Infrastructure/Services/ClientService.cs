using Contracts.Contracts;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;

namespace Services.Infrastructure.Services
{
    public class ClientService : ServiceBase<ClientRepository, ClientDto>
    {
        public ClientService(ClientRepository repository) : base(repository)
        {
        }
    }
}