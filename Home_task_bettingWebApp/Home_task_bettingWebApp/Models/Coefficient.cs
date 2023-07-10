using System.ComponentModel.DataAnnotations;

namespace Home_task_bettingWebApp.Models
{
    public class Coefficient
    {
        [Key]
        public int CoefficientId { get; set; }

        // Решта властивостей моделі
        public int EventId { get; set; }
        public int TeamId { get; set; }
        public decimal WinCoefficient { get; set; }
        public decimal DrawCoefficient { get; set; }
        public decimal LoseCoefficient { get; set; }

        // Навігаційні властивості
        public virtual Event Event { get; set; }
        public virtual Team Team { get; set; }
    }
}
