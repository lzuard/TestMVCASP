using Contracts.Contracts.Records;
using Microsoft.Extensions.Logging;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class ClientController : RecordControllerBase<ClientService, ClientRecordDto>
    {
        public ClientController(ClientService recordService, ILogger<RecordControllerBase<ClientService, ClientRecordDto>> logger) :
            base(recordService, logger)
        {
        }
    }
}