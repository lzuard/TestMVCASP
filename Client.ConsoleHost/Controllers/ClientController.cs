using Contracts.Contracts;
using Microsoft.Extensions.Logging;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class ClientController : ModelControllerBase<ClientService, ClientDto>
    {
        public ClientController(ClientService service, ILogger<ModelControllerBase<ClientService, ClientDto>> logger) :
            base(service, logger)
        {
        }
    }
}