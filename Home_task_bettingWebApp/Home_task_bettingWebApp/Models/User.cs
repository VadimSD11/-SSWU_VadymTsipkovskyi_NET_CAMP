﻿using System.ComponentModel.DataAnnotations;

namespace Home_task_bettingWebApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        // Решта властивостей моделі
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        // Навігаційні властивості
        //public virtual ICollection<Bet> Bets { get; set; }
        //public virtual Balance Balance { get; set; }

    }
}
