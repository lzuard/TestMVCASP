using System.Threading.Tasks;
using Contracts.Contracts.Ttn;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class TtnService : ServiceBase<TtnRepository,TtnDto>
    {
        public TtnService(TtnRepository recordRepository) : base(recordRepository)
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