using CMS.BL.DTOs;
using CMS.BL.Service.roadmastep;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CMS.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoadmapStepsController : ControllerBase
    {
        private readonly IRoadmapStepService _service;

        public RoadmapStepsController(IRoadmapStepService service)
        {
            _service = service;
        }

        // GET: api/RoadmapSteps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoadmapStepGetDto>>> GetAll()
        {
            var steps = await _service.GetAllAsync();
            return Ok(steps);
        }

        // GET: api/RoadmapSteps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoadmapStepGetDto>> GetById(int id)
        {
            var step = await _service.GetByIdAsync(id);
            if (step == null)
                return NotFound();

            return Ok(step);
        }

        // POST: api/RoadmapSteps
        [HttpPost]
        public async Task<ActionResult<RoadmapStepGetDto>> Create([FromBody] RoadmapStepPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.RoadmapStepId }, created);
        }

        // PUT: api/RoadmapSteps/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RoadmapStepGetDto>> Update(int id, [FromBody] RoadmapStepPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/RoadmapSteps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
