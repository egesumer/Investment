using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;

public class InvestmentToolRepository : GenericRepository<InvestmentTool>, IInvestmentToolRepository
{
    private readonly AppDbContext db;

    public InvestmentToolRepository(AppDbContext db) : base(db)
    {
        this.db = db;
    }

    // Yatırım aracının sembolüne göre arama yapıyoruz
    public async Task<InvestmentTool> GetBySymbolAsync(string symbol)
    {
        return await db.Set<InvestmentTool>().FirstOrDefaultAsync(x => x.Symbol == symbol && !x.IsDeleted);
    }
}