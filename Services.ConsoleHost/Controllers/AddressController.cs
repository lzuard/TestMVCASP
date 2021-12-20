using Contracts.Contracts.Address;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class AddressController : RecordControllerBase<AddressService, AddressDto>
    {
        public AddressController(AddressService service) : base(service)
        {
        }
    }
}