using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Models.Contracts;
using Slick.Services.Contracts;
using Slick.Services.People;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService contractService;

        public ContractsController(IContractService contractService)
        {
            this.contractService = contractService;
        }

        [HttpPost]
        public IActionResult Post(Contract contract)
        {
            var newContract = contractService.Create(contract);
            if (newContract.Id == Guid.Empty)
                return StatusCode(500);
            return CreatedAtAction("Get", newContract);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var contracts = contractService.GetAll();
            return Ok(contracts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var contract = contractService.GetById(id);
            if (contract == null)
                return NotFound();
            return Ok(contract);
        }

        [HttpPut]
        public IActionResult Update(Contract contract)
        {
            contractService.Update(contract);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Contract contract)
        {
            contractService.Delete(contract);
            return NoContent();
        }
    }
}