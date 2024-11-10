public class InvestmentToolService : IInvestmentToolService
{
    private readonly IInvestmentToolRepository _investmentToolRepository;

    public InvestmentToolService(IInvestmentToolRepository investmentToolRepository)
    {
        _investmentToolRepository = investmentToolRepository;
    }

    // Yeni yatırım aracı eklemek
    public async Task<InvestmentTool> CreateInvestmentToolAsync(CreateInvestmentToolDto dto)
    {
        var investmentTool = new InvestmentTool
        {
            Name = dto.Name,
            Symbol = dto.Symbol,
            CurrentValue = dto.CurrentValue,
            CreationDate = DateTime.Now
        };

        var success = await _investmentToolRepository.AddAsync(investmentTool);
        if (success)
        {
            return investmentTool;
        }

        return null;
    }

    // Tüm yatırım araçlarını almak
    public async Task<IEnumerable<InvestmentTool>> GetAllInvestmentToolsAsync()
    {
        return await _investmentToolRepository.GetAllAsync();
    }

    // Yatırım aracı ID'si ile almak
    public async Task<InvestmentTool> GetInvestmentToolByIdAsync(Guid id)
    {
        return await _investmentToolRepository.GetByIDAsync(id);
    }

    // Yatırım aracını güncellemek
    public async Task<bool> UpdateInvestmentToolAsync(Guid id, UpdateInvestmentToolDto dto)
    {
        var investmentTool = await _investmentToolRepository.GetByIDAsync(id);

        if (investmentTool == null)
        {
            throw new Exception("Investment Tool not found");
        }

        investmentTool.Name = dto.Name;
        investmentTool.Symbol = dto.Symbol;
        investmentTool.CurrentValue = dto.CurrentValue;
        investmentTool.ModifiedDate = DateTime.Now;

        return await _investmentToolRepository.UpdateAsync(investmentTool);
    }

    // Yatırım aracını silmek
    public async Task<bool> DeleteInvestmentToolAsync(Guid id)
    {
        var investmentTool = await _investmentToolRepository.GetByIDAsync(id);

        if (investmentTool == null)
        {
            throw new Exception("Investment Tool not found");
        }

        return await _investmentToolRepository.DeleteAsync(investmentTool);
    }
}