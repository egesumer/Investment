public class InvestService : IInvestService
{
    private readonly IInvestRepository _investRepository;
    private readonly IInvestmentToolRepository _investmentToolRepository;

    public InvestService(IInvestRepository investRepository, IInvestmentToolRepository investmentToolRepository)
    {
        _investRepository = investRepository;
        _investmentToolRepository = investmentToolRepository;
    }

    public async Task<Investment> CreateInvestmentAsync(CreateInvestmentDto investmentDto, Guid userId)
{
    // Yatırım aracının verilerini almak için InvestmentTool repository'sini kullanmalıyız
    var investmentTool = await _investmentToolRepository.GetByIDAsync(investmentDto.InvestmentToolId);

    if (investmentTool == null)
    {
        throw new Exception("Investment Tool not found.");
    }

    // Yatırım bilgilerini oluşturuyoruz
    var investment = new Investment
    {
        UserId = userId,
        InvestmentToolId = investmentDto.InvestmentToolId,
        Amount = investmentDto.Amount, // Amount'u kullanıcı giriyor
        Price = investmentTool.CurrentValue, // Güncel fiyatı veritabanından alıyoruz
        InvestmentDate = investmentDto.InvestmentDate, // Yatırım tarihi
        CreationDate = DateTime.Now // Yatırım oluşturma tarihi
    };

    // Yatırımı veritabanına ekliyoruz
    var success = await _investRepository.AddAsync(investment);
    
    if (success)
    {
        return investment;
    }
    return null;
}



    // Diğer metodlar (Tüm yatırımlar, ID ile yatırım getirme, güncelleme, silme)
    public async Task<IEnumerable<Investment>> GetAllInvestmentsAsync(bool includeDeleted = false)
    {
        return await _investRepository.GetAllAsync(includeDeleted);
    }

    public async Task<Investment> GetInvestmentByIdAsync(Guid id, bool includeDeleted = false)
    {
        return await _investRepository.GetByIDAsync(id, includeDeleted);
    }

    public async Task<bool> UpdateInvestmentAsync(Investment investment)
    {
        return await _investRepository.UpdateAsync(investment);
    }

    public async Task<bool> DeleteInvestmentAsync(Guid id)
    {
        var investment = await _investRepository.GetByIDAsync(id);
        if (investment == null)
        {
            return false;
        }
        return await _investRepository.DeleteAsync(investment);
    }

    public async Task<IEnumerable<Investment>> GetInvestmentsByUserIdAsync(Guid userId, bool includeDeleted = false)
    {
        return await _investRepository.GetWhereAsync(i => i.UserId == userId, includeDeleted);
    }

    public async Task<Investment> GetInvestmentByToolAndUserAsync(Guid userId, Guid toolId, bool includeDeleted = false)
    {
        return await _investRepository.SingleOrDefaultAsync(i => i.UserId == userId && i.InvestmentToolId == toolId, includeDeleted);
    }
}
