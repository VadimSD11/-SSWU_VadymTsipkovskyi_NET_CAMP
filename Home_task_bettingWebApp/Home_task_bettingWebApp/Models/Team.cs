using System.ComponentModel.DataAnnotations;

namespace Home_task_bettingWebApp.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        // Решта властивостей моделі
        public string Name { get; set; }
        public string Country { get; set; }

        // Навігаційні властивості
        public virtual ICollection<Coefficient> Coefficients { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
