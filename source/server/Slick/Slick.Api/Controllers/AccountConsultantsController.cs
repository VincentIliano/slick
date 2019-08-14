using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Api.Dtos;
using Slick.Models.Customers;
using Slick.Services.Customers;
using Slick.Services.People;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountConsultantsController : ControllerBase
    {
        private readonly IAccountConsultantService accountConsultantService;
        private readonly IConsultantService consultantService;
        private readonly IAccountService accountService;
        private readonly IEmployeeService employeeService;

        public AccountConsultantsController(IAccountConsultantService accountConsultantService, IConsultantService consultantService, IAccountService accountService, IEmployeeService employeeService)
        {
            this.accountConsultantService = accountConsultantService;
            this.consultantService = consultantService;
            this.accountService = accountService;
            this.employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult Post(AccountConsultant accountConsultant)
        {
            var newAccountConsultant = accountConsultantService.Create(accountConsultant);
            if (newAccountConsultant.Id == Guid.Empty)
                return StatusCode(500);
            return CreatedAtAction("Get", newAccountConsultant);
        }

        /// [controller]?sort=firstname&filter=firstname
        [HttpGet]
        public IActionResult Get([FromQuery]string sort, [FromQuery]string filter, [FromQuery] string value)
        {
            if (!String.IsNullOrEmpty(filter))
            {
                if (String.IsNullOrEmpty(value))
                    return BadRequest("Parameterless searches have been disabled");

                var accountConsultantDtos = new List<AccountConsultantDto>();

                IEnumerable<AccountConsultant> accountConsultantsFromDb = new List<AccountConsultant>();

                foreach (var c in accountConsultantsFromDb)
                {
                    accountConsultantDtos.Add(Mapper.MapAccountConsultant(c));
                }

                return Ok(accountConsultantDtos);
            }
            var accountConsultants = accountConsultantService.GetAll();
            return Ok(accountConsultants);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetOverview([FromQuery]string orderby, [FromQuery]bool isDescending, [FromQuery] int page, [FromQuery] int size)
        {
            var accountConsultants = accountConsultantService.GetOverview(orderby, isDescending, page, size);
            if (accountConsultants == null)
                return NotFound();
            return Ok(accountConsultants);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var c = accountConsultantService.GetById(id);
            if (c == null)
                return NotFound();

            var accountConsultantDto = Mapper.MapAccountConsultant(c);

            var accountFromDb = accountService.GetById(c.AccountId);
            var consultantFromDb = consultantService.GetById(c.ConsultantId);
            var employeeFromDb = employeeService.GetById(c.EmployeeId);

            accountConsultantDto.Account = Mapper.MapAccount(accountFromDb);
            accountConsultantDto.Consultant = Mapper.MapConsultant(consultantFromDb);
            accountConsultantDto.Employee = Mapper.MapEmployee(employeeFromDb);

            return Ok(accountConsultantDto);
        }

        [HttpPut]
        public IActionResult Update(AccountConsultant accountConsultant)
        {
            accountConsultantService.Update(accountConsultant);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(AccountConsultant accountConsultant)
        {
            accountConsultantService.Delete(accountConsultant);
            return NoContent();
        }
    }
}