using System.ComponentModel.DataAnnotations;

namespace Home_task_bettingWebApp.Models
{
    public class Balance
    {
        [Key]
        public int BalanceId { get; set; }

        // Решта властивостей моделі
        public int UserId { get; set; }
        public decimal Amount { get; set; }

        // Навігаційні властивості
        //public virtual User User { get; set; }
    }
}
