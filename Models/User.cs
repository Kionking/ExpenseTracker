using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        [JsonIgnore]
        public ICollection<Expense> Expenses { get; set; } = [];
    }
}
