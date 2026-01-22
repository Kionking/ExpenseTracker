namespace ExpenseTracker.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<ExpenseEntity> Expenses { get; set; } = [];
    }
}
