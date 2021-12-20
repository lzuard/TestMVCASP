using System.Threading.Tasks;
using Contracts.Contracts.Address;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class AddressService : ServiceBase<AddressRepository, AddressDto>
    {
        public AddressService(AddressRepository recordRepository) : base(recordRepository)
        {
        }

        public override Task<OperationResult<bool>> TryDelete(int modelId)
        {
            string message = "You have no permission";
            
            var result = OperationResult<bool>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }
    }
}