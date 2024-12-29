using System.Globalization;
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

            builder.Entity<User>().HasData( //all passwords are "123456"
                new User { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab3"), Email = "player@example.com", Hash = "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=", Role = "player", FullName = "Player 1", Phone="0333444555"},
                new User { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab4"), Email = "brand@example.com", Hash = "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=", Role = "brand", FullName = "Brand 1", Phone="0333444556" },
                new User { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab5"), Email = "admin@example.com", Hash = "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=", Role = "admin", FullName = "Admin 1", Phone="0333444557" }
            );
           
            builder.Entity<Brand>().HasData(
                new Brand { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab6"), Name = "Brand 1", UserId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab4"),  }
            );

            builder.Entity<Voucher>().HasData(
                new Voucher { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab7"), BrandId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab6"), Code = "Voucher 1", Description = "Đổi 1 tỉ tiền mặt", ExpiredAt = DateTime.ParseExact("30/01/2025", "dd/MM/yyyy", CultureInfo.InvariantCulture), PieceCount=2, ImageUrl="", QrCodeUrl="", Value=1000000, Quantity=10000000 },
                new Voucher { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab8"), BrandId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab6"), Code = "Voucher 2", Description = "Chúc bạn 1 ngày zui zẻ", ExpiredAt = DateTime.ParseExact("30/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), PieceCount=2, ImageUrl="", QrCodeUrl="", Value=1000000, Quantity=10000000 }
            );            

            builder.Entity<VoucherPiece>().HasData(
                new VoucherPiece { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab12"), VoucherId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab7"), PieceNumber = 1,  ImageUrl = "https://roflmagnets.com/447-medium_default/number-1.jpg" },
                new VoucherPiece { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab13"), VoucherId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab7"), PieceNumber = 2, ImageUrl = "https://roflmagnets.com/304-large_default/number-2.jpg" },
                new VoucherPiece { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab14"), VoucherId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab8"), PieceNumber = 1, ImageUrl = "https://roflmagnets.com/447-medium_default/number-1.jpg" },
                new VoucherPiece { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab15"), VoucherId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab8"), PieceNumber = 2, ImageUrl = "https://roflmagnets.com/304-large_default/number-2.jpg" }
            );

            builder.Entity<Event>().HasData(
                new Event { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), BrandId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab6"), Name = "Event Example", StartAt = DateTime.ParseExact("30/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), EndAt = DateTime.ParseExact("30/01/2025", "dd/MM/yyyy", CultureInfo.InvariantCulture), Status = Domain.Enums.EventStatus.Accepted}
            );

            builder.Entity<EventVoucher>().HasData(
                new EventVoucher { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab10"), EventId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), VoucherId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab7"), Quantity = 100000000},
                new EventVoucher { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab11"), EventId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), VoucherId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab8"), Quantity = 1}
            );

            builder.Entity<UserEvent>().HasData(
                new UserEvent { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab16"), UserId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab3"), EventId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), TurnsLeft = 300 }
            );

            builder.Entity<QuestionSet>().HasData(
                new QuestionSet { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab17"), BrandId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab6"), Name = "Question Set 1" }
            );

            builder.Entity<Question>().HasData(
                new Question { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab18"), QuestionSetId = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab17"), Content = "What is the capital of Vietnam?", CorrectAnswer = 1, AnswerList = "Hanoi;Ho Chi Minh;Da Nang;Hue" },
                new Question { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab19"), QuestionSetId = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab17"), Content = "What is the capital of France?", CorrectAnswer = 2, AnswerList = "Lyon;Paris;Marseille;Nice" },
                new Question { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab20"), QuestionSetId = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab17"), Content = "What is the capital of USA?", CorrectAnswer = 3, AnswerList = "New York;Washington D.C;Los Angeles;Chicago" },
                new Question { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab21"), QuestionSetId = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab17"), Content = "What is the capital of Japan?", CorrectAnswer = 4, AnswerList = "Tokyo;Osaka;Kyoto;Hokkaido" },
                new Question { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab22"), QuestionSetId = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab17"), Content = "What is the capital of South Korea?", CorrectAnswer = 1, AnswerList = "Seoul;Busan;Incheon;Daegu" },
                new Question { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab23"), QuestionSetId = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab17"), Content = "What is the capital of China?", CorrectAnswer = 2, AnswerList = "Beijing;Shanghai;Guangzhou;Shenzhen" },
                new Question { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab24"), QuestionSetId = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab17"), Content = "What is the capital of Thailand?", CorrectAnswer = 3, AnswerList = "Bangkok;Chiang Mai;Phuket;Pattaya" },
                new Question { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab25"), QuestionSetId = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab17"), Content = "What is the capital of Singapore?", CorrectAnswer = 4, AnswerList = "Singapore;Sentosa;Jurong;Changi" }
            );

            builder.Entity<GamePrototype>().HasData(
                new GamePrototype { Id = Guid.Parse("9e4f49fe-0786-44c6-9061-53d2ed84fab3"), Name = "Quiz Game", Type = "Quiz", Status = "Active", CanExchangeVoucherPieces=false, GameplayInstruction = "Answer the questions in livestream, choose right answers exceeding threshold to win a voucher", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCqwR5F3YJTWvePHVfsLoUgppmfPwEKJTV3A&s" },
                new GamePrototype { Id = Guid.Parse("9e4f49fe-0786-44c6-9061-1232aa84fab3"), Name = "Shake Game", Type = "Shake", Status = "Active", CanExchangeVoucherPieces=true, GameplayInstruction = "Shake your phone to win a voucher piece, combine all difference pieces to get a voucher", ImageUrl = "https://play-lh.googleusercontent.com/gtcbFGJIhU9Zfni1REuvrzlyQ0AnSV-9wUlL_hf32ACzwGAfeL1ttJJ09RSfvFoNA7nI=w240-h480-rw" }
            );
            builder.Entity<Game>().HasData(
                new Game { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab26"), EventId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), GamePrototypeId = Guid.Parse("9e4f49fe-0786-44c6-9061-53d2ed84fab3"), Status = "Active", StartTime = DateTime.ParseExact("30/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), EndTime = DateTime.ParseExact("30/01/2025", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Game { Id = Guid.Parse("9e4f49fe-0783-44c6-9061-3d2ed84fab27"), EventId = Guid.Parse("9e4f49fe-0783-44c6-9061-53d2ed84fab9"), GamePrototypeId = Guid.Parse("9e4f49fe-0786-44c6-9061-1232aa84fab3"), Status = "Active", StartTime = DateTime.ParseExact("30/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), EndTime = DateTime.ParseExact("30/01/2025", "dd/MM/yyyy", CultureInfo.InvariantCulture) }
            );

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