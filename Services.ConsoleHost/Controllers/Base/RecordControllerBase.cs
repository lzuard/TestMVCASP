using System.Threading.Tasks;
using Contracts.Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Infrastructure.Services.Interferes;

namespace Presentation.ConsoleHost.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordControllerBase<TService, TModelDto> : ControllerBase
        where TService : IRecordService<TModelDto> where TModelDto : RecordDtoBase
    {
        protected readonly TService Service;

        public RecordControllerBase(TService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Service.TryGetAll();
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Service.TryGet(id);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return Ok(result.Error.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TModelDto model)
        {
            var result = await Service.TryCreate(model);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(TModelDto model)
        {
            var result = await Service.TryUpdate(model);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int modelId)
        {
            var result = await Service.TryDelete(modelId);
            
            if (result.IsSuccess)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}