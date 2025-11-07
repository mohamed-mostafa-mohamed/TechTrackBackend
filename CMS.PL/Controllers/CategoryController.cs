using CMS.BL.DTOs;
using CMS.BL.Service.category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CMS.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryGetDto>>> GetAll()
            => Ok(await _service.GetAllCategoriesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryGetDto>> GetById(int id)
        {
            var category = await _service.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryGetDto>> Create([FromBody] CategoryPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateCategoryAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.CategoryId }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryGetDto>> Update(int id, [FromBody] CategoryPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateCategoryAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteCategoryAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}