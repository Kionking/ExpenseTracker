using System.ComponentModel;

namespace ExpenseTracker.Models
{
    public class ExpenseEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }

        public int UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}
