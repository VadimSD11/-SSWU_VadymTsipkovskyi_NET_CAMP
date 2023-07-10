using System.ComponentModel.DataAnnotations;

namespace Home_task_bettingWebApp.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }

        // Решта властивостей моделі
        public int EventId { get; set; }
        public int TeamId { get; set; }
        public string Outcome { get; set; }

        // Навігаційні властивості
        public virtual Event Event { get; set; }
        public virtual Team Team { get; set; }
    }
}
