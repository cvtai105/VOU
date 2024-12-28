using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Brand> Brands { get; }
        DbSet<BrandBranch> BrandBranches { get; }
        DbSet<Event> Events { get; }
        DbSet<EventVoucher> EventVouchers { get; }
        DbSet<Game> Games { get; }
        DbSet<Question> Questions { get; }
        DbSet<QuestionSet> QuestionSets { get; }
        DbSet<User> Users { get; }
        DbSet<UserEvent> UserEvents { get; }
        DbSet<UserVoucher> UserVouchers { get; }
        DbSet<Voucher> Vouchers { get; }
        DbSet<WishList> WishLists { get; }
        DbSet<UserPiece> UserPieces { get; }
        DbSet<VoucherPiece> VoucherPieces { get; }
        DbSet<GamePrototype> GamePrototypes { get; }
        DbSet<QuizzGame> QuizzGames { get; }
        DbSet<ShakeGame> ShakeGames { get; }
        DbSet<ExchangePiece> ExchangePieces { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}