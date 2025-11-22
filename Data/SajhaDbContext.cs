using Microsoft.EntityFrameworkCore;
using SajhaBhavishyaAPI.Models.Entities;


namespace SajhaBhavishyaAPI.Data
{
    public class SajhaDbContext : DbContext
    {
        public SajhaDbContext(DbContextOptions<SajhaDbContext> options)
           : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<SavingsAccount> SavingsAccount { get; set; }
        public DbSet<MemberTransaction> MemberTransactions { get; set; }
        //public DbSet<AuditLog> AuditLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberTransaction>()
       .ToTable("MemberTransactions");
            modelBuilder.Entity<Member>()
                .HasMany(s => s.SavingsAccounts)
                .WithOne(m => m.Member)
                .HasForeignKey(s => s.MemberId);

            modelBuilder.Entity<Member>()
                .HasMany(t => t.MemberTransactions)
                .WithOne(m => m.Member)
                .HasForeignKey(t => t.MemberId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
