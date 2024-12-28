using System.Reflection;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Brand>()
                .HasOne(b => b.User)
                .WithMany(u => u.Brands)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Use NoAction instead of Cascade

   

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<BrandBranch> BrandBranches { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventVoucher> EventVouchers { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<QuestionSet> QuestionSets { get; set; } = null!;
        public DbSet<UserEvent> UserEvents { get; set; } = null!;
        public DbSet<UserVoucher> UserVouchers { get; set; } = null!;
        public DbSet<Voucher> Vouchers { get; set; } = null!;
        public DbSet<WishList> WishLists { get; set; } = null!;
        public DbSet<UserPiece> UserPieces { get; set; } = null!;
        public DbSet<VoucherPiece> VoucherPieces { get; set; } = null!;
        public DbSet<GamePrototype> GamePrototypes { get; set; } = null!;
        public DbSet<QuizzGame> QuizzGames { get; set; } = null!;
        public DbSet<ShakeGame> ShakeGames { get; set; } = null!;
        public DbSet<ExchangePiece> ExchangePieces { get; set; } = null!;

    }
}