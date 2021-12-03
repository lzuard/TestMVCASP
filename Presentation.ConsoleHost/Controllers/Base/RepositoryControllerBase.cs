using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Infrastructure.Services.Interferes;

namespace Presentation.ConsoleHost.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryControllerBase<TService, TModelDto> : ControllerBase
        where TService : IEntityService<TModelDto> where TModelDto : DtoBase
    {
        private readonly ILogger<RepositoryControllerBase<TService, TModelDto>> _logger;
        private readonly TService _service;

        public RepositoryControllerBase(TService service,
            ILogger<RepositoryControllerBase<TService, TModelDto>> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TModelDto>>> GetAll()
        {
            var result = await _service.TryGetAll();
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TModelDto>> Get(int id)
        {
            var result = await _service.TryGet(id);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult<TModelDto>> Create(TModelDto model)
        {
            var result = await _service.TryCreate(model);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TModelDto>> Update(TModelDto model)
        {
            var result = await _service.TryUpdate(model);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int modelId)
        {
            var result = await _service.TryDelete(modelId);
            
            if (result.IsSuccess)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}