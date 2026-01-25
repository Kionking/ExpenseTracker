using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategories([FromBody] Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();


            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpGet("GetCategoryById")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category is null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var category = await _db.Categories.ToListAsync();
            return Ok(category);
        }
    }
}
