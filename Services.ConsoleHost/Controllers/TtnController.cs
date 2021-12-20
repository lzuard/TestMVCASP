using Contracts.Contracts.Ttn;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class TtnController :RecordControllerBase<TtnService, TtnDto>
    {
        public TtnController(TtnService service) : base(service)
        {
        }
    }
}