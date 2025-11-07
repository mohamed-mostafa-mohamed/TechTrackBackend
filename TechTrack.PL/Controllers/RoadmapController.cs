using CMS.BL.DTOs;
using CMS.BL.Service.roadmap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CMS.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoadmapController : ControllerBase
    {
        private readonly IRoadmapService _service;

        public RoadmapController(IRoadmapService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roadmaps = await _service.GetAllAsync();
            return Ok(roadmaps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var roadmap = await _service.GetByIdAsync(id);
            if (roadmap == null) return NotFound();
            return Ok(roadmap);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoadmapPostDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.RoadmapId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoadmapPostDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
