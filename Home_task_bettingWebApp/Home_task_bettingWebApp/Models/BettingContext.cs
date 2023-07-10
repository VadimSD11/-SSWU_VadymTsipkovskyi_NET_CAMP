using Microsoft.EntityFrameworkCore;
namespace Home_task_bettingWebApp.Models
{
    public class BettingContext:DbContext
    {
        public BettingContext(DbContextOptions<BettingContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=MyBettingDB;Trusted_Connection=True;multipleactiveresultsets=True;TrustServerCertificate=True;");
        }
     
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coefficient> Coefficients { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Balance> Balances { get; set; }
    }
}
