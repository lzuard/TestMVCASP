using System.Linq;
using System.Threading.Tasks;
using Contracts.Contracts.Ttn;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class TtnService : ServiceBase<TtnRepository, TtnDto>
    {
        public TtnService(TtnRepository recordRepository) : base(recordRepository)
        {
        }

        public override async Task<OperationResult<TtnDto>> TryCreate(TtnDto model)
        {
            var filterDto = new TtnFilterDto
            {
                Number = model.Number
            };

            var filterResult = await Repository.GetByFilter(filterDto);

            if (filterResult.IsSuccess)
            {
                int countTtns = filterResult.Result.Count();

                if (countTtns != 0)
                {
                    string message = $"Tth with number {model.Number} already exist";

                    return OperationResult<TtnDto>.GetUnsuccessfulResult(message);
                }
            }

            return await base.TryCreate(model);
        }

        public override async Task<OperationResult<TtnDto>> TryUpdate(TtnDto model)
        {
            var filterDto = new TtnFilterDto
            {
                Number = model.Number
            };

            var filterResult = await Repository.GetByFilter(filterDto);

            if (filterResult.IsSuccess)
            {
                int countTtns = filterResult.Result.Count();

                if (countTtns != 0)
                {
                    string message = $"Tth with number {model.Number} already exist";

                    return OperationResult<TtnDto>.GetUnsuccessfulResult(message);
                }
            }

            return await base.TryUpdate(model);
        }
    }
}