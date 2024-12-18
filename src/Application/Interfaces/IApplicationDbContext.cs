using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}