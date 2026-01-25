using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
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

        //:TODO: Implement GET by UserId and CategoryId
        //:TODO: Implement GET by Sum of Expenses
        //:TODO: Implement GET by Date Range
    }
}
