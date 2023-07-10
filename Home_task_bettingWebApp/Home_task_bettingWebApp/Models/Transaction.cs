using System.ComponentModel.DataAnnotations;

namespace Home_task_bettingWebApp.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        // Решта властивостей моделі
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionTime { get; set; }
        public string Description { get; set; } 

        // Навігаційні властивості
       // public virtual User User { get; set; }
    }
}
