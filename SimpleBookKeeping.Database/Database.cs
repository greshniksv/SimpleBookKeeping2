using Database.Models;
using Microsoft.EntityFrameworkCore;
using SimpleBookKeeping.Database.Models;

namespace SimpleBookKeeping.Database
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
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasIndex(i => i.Login);
            modelBuilder.Entity<User>().HasMany(x => x.PlanMembers).WithOne(x => x.User);
            modelBuilder.Entity<User>().HasMany(x => x.Plans).WithOne(x => x.User);
            modelBuilder.Entity<User>().HasMany(x => x.Spend).WithOne(x => x.User);

            modelBuilder.Entity<Spend>().HasKey(x => x.Id);

            modelBuilder.Entity<Plan>().HasKey(x => x.Id);
            modelBuilder.Entity<Plan>().HasIndex(i => i.Start);
            modelBuilder.Entity<Plan>().HasIndex(i => i.End);
            modelBuilder.Entity<Plan>().HasIndex(i => i.Deleted);
            modelBuilder.Entity<Plan>().HasMany(x => x.PlanMembers).WithOne(x => x.Plan);
            modelBuilder.Entity<Plan>().HasMany(x => x.Costs).WithOne(x => x.Plan);

            modelBuilder.Entity<PlanMember>().HasKey(x => x.Id);

            modelBuilder.Entity<Cost>().HasKey(x => x.Id);
            modelBuilder.Entity<Cost>().HasIndex(i => i.Deleted);
            modelBuilder.Entity<Cost>().HasMany(x => x.CostDetails).WithOne(x => x.Cost);

            modelBuilder.Entity<CostDetail>().HasIndex(i => i.Deleted);
            modelBuilder.Entity<CostDetail>().HasIndex(i => i.Date);
            modelBuilder.Entity<CostDetail>().HasMany(x => x.Spends).WithOne(x => x.CostDetail);

            base.OnModelCreating(modelBuilder);
        }
    }
}
