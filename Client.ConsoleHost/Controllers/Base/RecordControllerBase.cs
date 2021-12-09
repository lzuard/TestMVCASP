﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Infrastructure.Services.Interferes;

namespace Presentation.ConsoleHost.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordControllerBase<TService, TModelDto> : ControllerBase
        where TService : IRecordService<TModelDto> where TModelDto : RecordDtoBase
    {
        protected readonly ILogger<RecordControllerBase<TService, TModelDto>> Logger;
        protected readonly TService Service;

        public RecordControllerBase(TService recordService,
            ILogger<RecordControllerBase<TService, TModelDto>> logger)
        {
            Service = recordService;
            Logger = logger;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TModelDto>>> GetAll()
        {
            var result = await Service.TryGetAll();
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            
            Logger.LogError(result.Error.Message);

            return NoContent();
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TModelDto>> Get(int id)
        {
            var result = await Service.TryGet(id);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            
            Logger.LogError(result.Error.Message);

            return NotFound();
        }

        [HttpPut]
        public virtual async Task<ActionResult<TModelDto>> Create(TModelDto model)
        {
            var result = await Service.TryCreate(model);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            
            Logger.LogError(result.Error.Message);

            return NoContent();
        }

        [HttpPost]
        public virtual async Task<ActionResult<TModelDto>> Update(TModelDto model)
        {
            var result = await Service.TryUpdate(model);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            
            Logger.LogError(result.Error.Message);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int modelId)
        {
            var result = await Service.TryDelete(modelId);
            
            if (result.IsSuccess)
            {
                return Ok();
            }
            
            Logger.LogError(result.Error.Message);

            return NotFound();
        }
    }
}