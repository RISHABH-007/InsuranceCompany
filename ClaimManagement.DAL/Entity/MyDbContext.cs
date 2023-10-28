using Microsoft.EntityFrameworkCore;

namespace ClaimManagement.DAL.Entity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
          
        }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Surveyor> Surveyors { get; set; }
        public DbSet<ClaimDetails> ClaimDetails { get; set; }
        public DbSet<Fees> Fees { get; set; }
        public DbSet<SurveyReport> SurveyReport { get; set;}
        public DbSet<PendingStatusReport> PendingStatusReport { get; set; }
        public DbSet<PaymentOfClaims> PaymentOfClaims { get; set; }
        public DbSet<User> User { get; set; }

    }
}
