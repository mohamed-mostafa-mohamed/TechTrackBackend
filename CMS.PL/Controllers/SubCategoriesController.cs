using CMS.BL.DTOs;
using CMS.BL.Service.subcategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CMS.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryService _service;

        public SubCategoriesController(ISubCategoryService service)
        {
            _service = service;
        }

        // GET: api/SubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryGetDto>>> GetAll()
        {
            var subCategories = await _service.GetAllAsync();
            return Ok(subCategories);
        }

        // GET: api/SubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryGetDto>> GetById(int id)
        {
            var subCategory = await _service.GetByIdAsync(id);
            if (subCategory == null)
                return NotFound();

            return Ok(subCategory);
        }


        // POST: api/SubCategories
        [HttpPost]
        public async Task<ActionResult<SubCategoryGetDto>> Create([FromBody] SubCategoryPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdSubCategory = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById),
                new { id = createdSubCategory.SubCategoryId },
                createdSubCategory);
        }

        // PUT: api/SubCategories/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoryGetDto>> Update(int id, [FromBody] SubCategoryPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedSubCategory = await _service.UpdateAsync(id, dto);
            if (updatedSubCategory == null)
                return NotFound();

            return Ok(updatedSubCategory);
        }

        // DELETE: api/SubCategories/5
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
