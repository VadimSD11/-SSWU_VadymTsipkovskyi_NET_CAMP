using System.ComponentModel.DataAnnotations;

namespace Home_task_bettingWebApp.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        // Решта властивостей моделі
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PrizePool { get; set; }
        public string Location { get; set; }
        public int AmountOfViewers { get; set; }
        public string Description { get; set; }
        // Навігаційні властивості
        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ICollection<Coefficient> Coefficients { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
