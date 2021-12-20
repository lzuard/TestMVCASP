using Contracts.Contracts.Address;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Base;

namespace Services.Infrastructure.Repositories
{
    public class AddressRepository :RepositoryBase<AddressDto>
    {
        public AddressRepository(ApplicationContext context) : base(context)
        {
        }
    }
}