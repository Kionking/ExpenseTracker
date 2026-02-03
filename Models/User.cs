using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTracker.Models
{
    public class User : IdentityUser
    {
        //[JsonIgnore]
        //public ICollection<Expense> Expenses { get; set; } = [];
    }
}
