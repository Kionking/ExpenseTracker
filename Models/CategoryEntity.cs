namespace ExpenseTracker.Models
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<ExpenseEntity> Expenses { get; set; } = [];
    }
}
