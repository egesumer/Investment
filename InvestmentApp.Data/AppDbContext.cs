using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; } 
        public DbSet<Investment> Investments { get; set; }
        public DbSet<InvestmentTool> InvestmentTools { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<User>()
            .ToTable("User")
            .HasIndex(u => u.Username)
            .IsUnique(); 

            modelBuilder.Entity<Investment>()
            .HasOne(i => i.User)
            .WithMany(u => u.Investments)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            // Investment ile InvestmentTool arasında 1:N ilişkiyi kuruyoruz
            modelBuilder.Entity<Investment>()
            .HasOne(i => i.InvestmentTool)
            .WithMany()
            .HasForeignKey(i => i.InvestmentToolId)
            .OnDelete(DeleteBehavior.Cascade);

            //  Superadmin kullanıcısını seed data olarak ekleme
                modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid(),
                Username = "superadmin",
                PasswordHash = PasswordHasher.HashPassword("superadmin"),
                UserType = UserType.Superadmin,
                TotalInvestment = 0.0m,
                CreationDate = DateTime.Now
            },
            new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                PasswordHash = PasswordHasher.HashPassword("admin"),
                UserType = UserType.Admin,
                TotalInvestment = 0.0m,
                CreationDate = DateTime.Now
            },
            new User
            {
                Id = Guid.NewGuid(),
                Username = "customer",
                PasswordHash = PasswordHasher.HashPassword("customer"),
                UserType = UserType.Customer,
                TotalInvestment = 0.0m,
                CreationDate = DateTime.Now
            }
            );
                    modelBuilder.Entity<InvestmentTool>().HasData(
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Gold",
                Symbol = "XAU",
                CurrentValue = 101500.00m, // Altın fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Silver",
                Symbol = "XAG",
                CurrentValue = 1250.00m, // Gümüş fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Apple Stock",
                Symbol = "AAPL",
                CurrentValue = 2200.00m, // Apple Hisse Senedi fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Bitcoin",
                Symbol = "BTC",
                CurrentValue = 1250000.00m, // Bitcoin fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Ethereum",
                Symbol = "ETH",
                CurrentValue = 90000.00m, // Ethereum fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Litecoin",
                Symbol = "LTC",
                CurrentValue = 1500.00m, // Litecoin fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Tesla Stock",
                Symbol = "TSLA",
                CurrentValue = 2500.00m, // Tesla Hisse Senedi fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Beyaz Eşya",
                Symbol = "BEYAZE",
                CurrentValue = 2000.00m, // Beyaz eşya sektörü fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "XRP (Ripple)",
                Symbol = "XRP",
                CurrentValue = 10.00m, // XRP fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Nasdaq-100 Index",
                Symbol = "IXIC",
                CurrentValue = 9000.00m, // Nasdaq Endeksi fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Amazon Stock",
                Symbol = "AMZN",
                CurrentValue = 3500.00m, // Amazon Hisse Senedi fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Dow Jones Index",
                Symbol = "DJI",
                CurrentValue = 20000.00m, // Dow Jones Endeksi fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "SP500 Index",
                Symbol = "SPX",
                CurrentValue = 15000.00m, // S&P 500 Endeksi fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Platinum",
                Symbol = "PLT",
                CurrentValue = 200000.00m, // Platin fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Palladium",
                Symbol = "PA",
                CurrentValue = 300000.00m, // Paladyum fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Borsa İstanbul 100 Endeksi",
                Symbol = "BIST100",
                CurrentValue = 1500.00m, // Borsa İstanbul Endeksi (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Natural Gas",
                Symbol = "NG",
                CurrentValue = 300.00m, // Doğal gaz fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Crude Oil",
                Symbol = "CL",
                CurrentValue = 750.00m, // Ham petrol fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Silver ETF",
                Symbol = "SLV",
                CurrentValue = 2000.00m, // Gümüş ETF fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            },
            new InvestmentTool
            {
                Id = Guid.NewGuid(),
                Name = "Bitcoin Cash",
                Symbol = "BCH",
                CurrentValue = 6000.00m, // Bitcoin Cash fiyatı (TL cinsinden)
                CreationDate = DateTime.Now
            }
        );

                    
        }
    }
}
