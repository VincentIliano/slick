using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Models.People;
using Slick.Services.People;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantService consultantService;

        public ConsultantsController(IConsultantService consultantService)
        {
            this.consultantService = consultantService;
        }

        [HttpPost]
        public IActionResult Post(Consultant consultant)
        {
            var newConsultant = consultantService.Create(consultant);
            if (newConsultant.Id == Guid.Empty)
                return StatusCode(500);
            return CreatedAtAction("Get", newConsultant);
        }

        [HttpGet]
        public IActionResult Get()
        {
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
            var consultant = consultantService.GetById(id);
            if (consultant == null)
                return NotFound();
            return Ok(consultant);
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