using Microsoft.EntityFrameworkCore;

namespace Database.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Spend> Spends { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanMember> PlanMembers { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<CostDetail> CostsDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>().HasIndex(i => i.Start);
            modelBuilder.Entity<Plan>().HasIndex(i => i.End);
            modelBuilder.Entity<Plan>().HasIndex(i => i.Deleted);

            modelBuilder.Entity<CostDetail>().HasIndex(i => i.Deleted);
            modelBuilder.Entity<CostDetail>().HasIndex(i => i.Date);

            modelBuilder.Entity<Cost>().HasIndex(i => i.Deleted);

            modelBuilder.Entity<User>().HasIndex(i => i.Login);

            base.OnModelCreating(modelBuilder);
        }
    }
}
