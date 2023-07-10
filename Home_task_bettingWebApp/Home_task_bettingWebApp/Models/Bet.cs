using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Home_task_bettingWebApp.Models
{
    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        // Решта властивостей моделі
        public int UserId { get; set; }
        public int EventId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BetTime { get; set; }

        // Навігаційні властивості
        public virtual User User { get; set; }
        public virtual Event Event { get; set; }
    }
}
