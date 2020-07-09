using CPN.NetCore.DTO.Core;
using CPN.NetCore.Entity.Core;
using CPN.NetCore.Service.Spec.Core.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPN.NetCore.API.Controllers.Core
{
    public abstract class CRUDControllerBase<TService, TDTO, TDomain, TId> : CustomControllerBase
        where TDTO : BaseDTO<TId>
        where TDomain : Domain<TId>
        where TService : ICRUDDomainService<TDTO, TDomain, TId>
    {
        protected TService Service { get; private set; }

        public CRUDControllerBase(TService service)
        {
            Service = service;
        }

        [HttpGet("{id}", Name="Get")]
        public async Task<IActionResult> Get(TId id)
        {
            var dto = await Service.GetByIdAsync(id);

            return ReturnResult(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dtos = await Service.GetAllNoTrackingAsync();

            return ReturnResult(dtos);
        }

        [HttpPost]
        public IActionResult Post(TDTO dto)
        {
            dto = Service.Add(dto);

            return CreatedAtRoute(nameof(Get), new { Id = dto.Id}, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(TId id, TDTO dto)
        {
            dto.Id = id;
            
            Service.Update(id, dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(TId id)
        {
            Service.Remove(id);

            return NoContent();
        }


        private IActionResult ReturnResult<T>(T data)
        {
            if (data == null)
                return NotFound();

            return Ok(data);
        }
    }
}
