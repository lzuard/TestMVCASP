using System.Threading.Tasks;
using Contracts.Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Infrastructure.Services.Interferes;

namespace Presentation.ConsoleHost.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordControllerBase<TService, TModelDto> : ControllerBase
        where TService : IService<TModelDto> where TModelDto : RecordDtoBase
    {
        protected readonly TService Service;

        public RecordControllerBase(TService service)
        {
            Service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await Service.TryGetAll();
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await Service.TryGet(id);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return Ok(result.Error.Message);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TModelDto model)
        {
            var result = await Service.TryCreate(model);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Error.Message);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(TModelDto model)
        {
            var result = await Service.TryUpdate(model);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int modelId)
        {
            return BadRequest(error:"You have no permission");
            
            var result = await Service.TryDelete(modelId);
            
            if (result.IsSuccess)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}