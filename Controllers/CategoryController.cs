using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost(Name = "CreateCategories")]
        public IActionResult CreateCategories([FromBody] CategoryEntity category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();


            return CreatedAtAction(nameof(GetCategories), new { id = category }, category);
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_db.Categories.ToList());
        }
    }
}
