using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Models.Skills;
using Slick.Services.Skills;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialisationLevelsController : ControllerBase
    {
        private readonly ISpecialisationLevelService specialisationLevelService;

        public SpecialisationLevelsController(ISpecialisationLevelService specialisationLevelService)
        {
            this.specialisationLevelService = specialisationLevelService;
        }

        [HttpPost]
        public IActionResult Post(SpecialisationLevel specialisationLevel)
        {
            var newLevel = specialisationLevelService.Create(specialisationLevel);
            return CreatedAtAction("Get", newLevel);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var levels = specialisationLevelService.GetAll();
            return Ok(levels);
        }

        [HttpGet]
        public IActionResult GetById(Guid id)
        {
            var level = specialisationLevelService.GetById(id);
            if (level == null)
                return NotFound();
            return Ok(level);
        }

        [HttpPut]
        public IActionResult Update(SpecialisationLevel level)
        {
            specialisationLevelService.Update(level);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(SpecialisationLevel level)
        {
            specialisationLevelService.Delete(level);
            return NoContent();
        }
    }
}