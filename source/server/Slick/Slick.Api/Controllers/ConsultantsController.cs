using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Api.Dtos;
using Slick.Models.Contracts;
using Slick.Models.People;
using Slick.Services.Contracts;
using Slick.Services.People;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantService consultantService;
        private readonly IContractService contractService;

        public ConsultantsController(IConsultantService consultantService, IContractService contractService)
        {
            this.consultantService = consultantService;
            this.contractService = contractService;
        }

        [HttpPost]
        public IActionResult Post(Consultant consultant)
        {
            var newConsultant = consultantService.Create(consultant);
            if (newConsultant.Id == Guid.Empty)
                return StatusCode(500);
            return CreatedAtAction("Get", newConsultant);
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var consultants = consultantService.GetAll();
        //    return Ok(consultants);
        //}

        /// [controller]?sort=firstname&filter=firstname
        [HttpGet]
        public IActionResult Get([FromQuery]string sort, [FromQuery]string filter, [FromQuery] string value)
        {
            if (!String.IsNullOrEmpty(filter))
            {
                if (String.IsNullOrEmpty(value))
                    return BadRequest("Parameterless searches have been disabled");

                var consultantDtos = new List<ConsultantDto>();

                IEnumerable<Consultant> consultantsFromDb = new List<Consultant>();

                if (filter == "firstname")
                    consultantsFromDb = consultantService.GetByfirstName(value);
                else
                    consultantsFromDb = consultantService.GetByLastname(value);

                foreach (var c in consultantsFromDb)
                {
                    consultantDtos.Add(new ConsultantDto
                    {
                        FirstName = c.Firstname,
                        LastName = c.Lastname,
                        Email = c.Email,
                        WorkEmail = c.WorkEmail,
                        Telephone = c.Telephone,
                        Mobile = c.Mobile,
                        Straat = c.Address.Straat,
                        Number = c.Address.Number,
                        Country = c.Address.Country,
                        Zipcode = c.Address.Zipcode
                    });
                }

                return Ok(consultantDtos);
            }
            var consultants = consultantService.GetAll();
            return Ok(consultants);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetOverview([FromQuery]string orderby, [FromQuery]bool isDescending, [FromQuery] int page, [FromQuery] int size)
        {
            var consultants = consultantService.GetOverview(orderby, isDescending, page, size);
            if (consultants == null)
                return NotFound();
            return Ok(consultants);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var c = consultantService.GetById(id);
            if (c == null)
                return NotFound();

            var consultantDto = new ConsultantDto
            {
                FirstName = c.Firstname,
                LastName = c.Lastname,
                Email = c.Email,
                WorkEmail = c.WorkEmail,
                Telephone = c.Telephone,
                Mobile = c.Mobile,
                Straat = c.Address?.Straat,
                Number = c.Address?.Number,
                Country = c.Address?.Country,
                Zipcode = c.Address?.Zipcode
            };

            var contractsFromDb = contractService.GetContractsForConsultant(id);
            consultantDto.Contracts = new List<ContractDto>();
            foreach(Contract con in contractsFromDb)
            {
                consultantDto.Contracts.Add(new ContractDto
                {
                    EndDate = con.EndDate,
                    StartDate = con.StartDate,
                    DocumentUrl = con.DocumentUrl,
                    Salary = con.Salary,
                    SignedDate = con.SignedDate
                });
            }

            return Ok(consultantDto);
        }

        [HttpPut]
        public IActionResult Update(Consultant consultant)
        {
            consultantService.Update(consultant);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Consultant consultant)
        {
            consultantService.Delete(consultant);
            return NoContent();
        }
    }
}