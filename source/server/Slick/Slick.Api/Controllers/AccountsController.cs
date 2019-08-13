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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IEmployeeService employeeService;
        private readonly IAccountManagerService accountManagerService;

        public AccountsController(IAccountService accountService, IEmployeeService employeeService, IAccountManagerService accountManagerService)
        {
            this.accountService = accountService;
            this.employeeService = employeeService;
            this.accountManagerService = accountManagerService;
        }

        [HttpPost]
        public IActionResult Post(Account account)
        {
            var newAccount = accountService.Create(account);
            if (newAccount.Id == Guid.Empty)
                return StatusCode(500);
            return CreatedAtAction("Get", newAccount);
        }

        /// [controller]?sort=firstname&filter=firstname
        [HttpGet]
        public IActionResult Get([FromQuery]string sort, [FromQuery]string filter, [FromQuery] string value)
        {
            if (!String.IsNullOrEmpty(filter))
            {
                if (String.IsNullOrEmpty(value))
                    return BadRequest("Parameterless searches have been disabled");

                var accountDtos = new List<AccountDto>();

                IEnumerable<Account> accountsFromDb = new List<Account>();

                if (filter == "companyname")
                    accountsFromDb = accountService.getByCompanyName(value);
                else
                    accountsFromDb = new List<Account> { accountService.GetByVatNumber(value) };

                foreach (var c in accountsFromDb)
                {
                    accountDtos.Add(new AccountDto
                    {
                        CompanyName = c.CompanyName,
                        VatNumber = c.VatNumber,
                        Telephone = c.Telephone,
                        Straat = c.Address.Straat,
                        Number = c.Address.Number,
                        Country = c.Address.Country,
                        Zipcode = c.Address.Zipcode
                    });
                }

                return Ok(accountDtos);
            }
            var accounts = accountService.GetAll();
            return Ok(accounts);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetOverview([FromQuery]string orderby, [FromQuery]bool isDescending, [FromQuery] int page, [FromQuery] int size)
        {
            var accounts = accountService.GetOverview(orderby, isDescending, page, size);
            if (accounts == null)
                return NotFound();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var c = accountService.GetById(id);
            if (c == null)
                return NotFound();

            var accountDto = new AccountDto
            {
               CompanyName = c.CompanyName,
               VatNumber = c.VatNumber,
                Telephone = c.Telephone,
                Straat = c.Address?.Straat,
                Number = c.Address?.Number,
                Country = c.Address?.Country,
                Zipcode = c.Address?.Zipcode
            };

            var accountManagersFromDb = accountManagerService.GetByAccount(id);

            foreach (var accountManager in accountManagersFromDb)
            {
                accountDto.AccountManagers.Add(new AccountManagerDto
                {
                    Account = accountDto,
                    Employee = Mapper.mapEmployee(employeeService.GetById(accountManager.EmployeeId)),
                    IsActive = accountManager.IsActive
                });
            }

            return Ok(accountDto);
        }

        [HttpDelete]
        public IActionResult Delete(Account account)
        {
            accountService.Delete(account);
            return NoContent();
        }

    }
}