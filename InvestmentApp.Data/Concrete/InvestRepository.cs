using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;

public class InvestRepository : GenericRepository<Investment>, IInvestRepository
{
    private readonly AppDbContext _db;

    public InvestRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    // Kullanıcıya ait tüm yatırımları getirme
    public async Task<IEnumerable<Investment>> GetInvestmentsByUserIdAsync(Guid userId, bool includeDeleted = false)
    {
        if (includeDeleted)
        {
            return await _db.Investments
                            .Where(i => i.UserId == userId)
                            .ToListAsync();
        }

        return await _db.Investments
                         .Where(i => i.UserId == userId && !i.IsDeleted)
                         .ToListAsync();
    }

    // Belirli bir yatırım aracı (InvestmentTool) ve kullanıcıya ait yatırımı almak
    public async Task<Investment> GetInvestmentByToolAndUserAsync(Guid userId, Guid toolId, bool includeDeleted = false)
    {
        if (includeDeleted)
        {
            return await _db.Investments
                            .Where(i => i.UserId == userId && i.InvestmentToolId == toolId)
                            .FirstOrDefaultAsync();
        }

        return await _db.Investments
                         .Where(i => i.UserId == userId && i.InvestmentToolId == toolId && !i.IsDeleted)
                         .FirstOrDefaultAsync();
    }
}
