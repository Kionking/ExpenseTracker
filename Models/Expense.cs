using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        
        public DateOnly? Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
