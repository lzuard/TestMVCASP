using Contracts.Contracts.Address;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;

namespace Services.Infrastructure.Services
{
    public class AddressService : ServiceBase<AddressRepository, AddressDto>
    {
        public AddressService(AddressRepository recordRepository) : base(recordRepository)
        {
        }
    }
}