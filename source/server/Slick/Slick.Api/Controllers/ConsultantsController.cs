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
        private readonly IConsultantService specialisationLevelService;

        public ConsultantsController(IConsultantService specialisationLevelService)
        {
            this.specialisationLevelService = specialisationLevelService;
        }

        [HttpPost]
        public IActionResult Post(Consultant specialisationLevel)
        {
            var newLevel = specialisationLevelService.Create(specialisationLevel);
            if (newLevel.Id == Guid.Empty)
                return StatusCode(500);
            return CreatedAtAction("Get", newLevel);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var levels = specialisationLevelService.GetAll();
            return Ok(levels);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var level = specialisationLevelService.GetById(id);
            if (level == null)
                return NotFound();
            return Ok(level);
        }

        [HttpPut]
        public IActionResult Update(Consultant level)
        {
            specialisationLevelService.Update(level);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Consultant level)
        {
            specialisationLevelService.Delete(level);
            return NoContent();
        }
    }
}