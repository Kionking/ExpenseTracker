using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ExpenseController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("CreateExpense")]
        public async Task<IActionResult> CreateExpense([FromBody] Expense expense)
        {
            _db.Expenses.Add(expense);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExpenseById), new { id = expense.Id }, expense);
        }

        [HttpGet("GetExpensesById")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var expenses = await _db.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (expenses is null)
                return NotFound();

            return Ok(expenses);
        }

        [HttpGet("GetAllExpenses")]
        public async Task<IActionResult> GetExpenses()
        {
            var expenses = await _db.Expenses.ToListAsync();
            if (expenses.Count <= 0)
                return NotFound();

            return Ok(expenses);
        }

        [HttpDelete("DeleteExpenseById")]
        public async Task<IActionResult> DeleteExpenseById(int id)
        {
            var expense = await _db.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (expense is null)
                return NotFound();

            _db.Expenses.Remove(expense);
            await _db.SaveChangesAsync();

            return Ok(expense);
        }

        [HttpGet("GetAllExpensesByUserId")]
        public async Task<IActionResult> GetExpensesByUserId(int userId)
        {
            var expenses = await _db.Expenses.Where(e => e.UserId == userId).ToListAsync();
            if (expenses.Count <= 0)
                return NotFound();
            return Ok(expenses);
        }

        [HttpGet("GetAllExpensesByDateRange")]
        public async Task<IActionResult> GetExpensesByDateRange(DateOnly startDate, DateOnly endDate)
        {
            var expenses = await _db.Expenses
                .Where(e => e.Date >= startDate && e.Date <= endDate)
                .ToListAsync();

            if (expenses.Count <= 0)
                return NotFound();

            return Ok(expenses);
        }

        //:TODO: Implement GET by CategoryId
        //:TODO: Implement GET by Sum of Expenses
    }
}
