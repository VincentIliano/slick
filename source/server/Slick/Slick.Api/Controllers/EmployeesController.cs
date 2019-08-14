using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Api.Dtos;
using Slick.Models.People;
using Slick.Services.Customers;
using Slick.Services.People;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var newEmployee = employeeService.Create(employee);
            if (newEmployee.Id == Guid.Empty)
                return StatusCode(500);
            return CreatedAtAction("Get", newEmployee);
        }


        /// [controller]?sort=firstname&filter=firstname
        [HttpGet]
        public IActionResult Get([FromQuery]string sort, [FromQuery]string filter, [FromQuery] string value)
        {
            if (!String.IsNullOrEmpty(filter))
            {
                if (String.IsNullOrEmpty(value))
                    return BadRequest("Parameterless searches have been disabled");

                var employeeDtos = new List<EmployeeDto>();

                IEnumerable<Employee> employeesFromDb = new List<Employee>();

                if (filter == "firstname")
                    employeesFromDb = employeeService.GetByfirstName(value);
                else
                    employeesFromDb = employeeService.GetByLastname(value);

                foreach (var c in employeesFromDb)
                {
                    employeeDtos.Add(Mapper.MapEmployee(c));
                }

                return Ok(employeeDtos);
            }
            var employees = employeeService.GetAll();
            return Ok(Mapper.MapEmployees(employees));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetOverview([FromQuery]string orderby, [FromQuery]bool isDescending, [FromQuery] int page, [FromQuery] int size)
        {
            var employees = employeeService.GetOverview(orderby, isDescending, page, size);
            if (employees == null)
                return NotFound();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var c = employeeService.GetById(id);
            if (c == null)
                return NotFound();

            var employeeDto = Mapper.MapEmployee(c);

            return Ok(employeeDto);
        }

        [HttpPut]
        public IActionResult Update(Employee employee)
        {
            employeeService.Update(employee);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Employee employee)
        {
            employeeService.Delete(employee);
            return NoContent();
        }

    }
}