public interface IInvestmentToolService
{
    Task<InvestmentTool> CreateInvestmentToolAsync(CreateInvestmentToolDto dto);
    Task<IEnumerable<InvestmentTool>> GetAllInvestmentToolsAsync();
    Task<InvestmentTool> GetInvestmentToolByIdAsync(Guid id);
    Task<bool> UpdateInvestmentToolAsync(Guid id, UpdateInvestmentToolDto dto);
    Task<bool> DeleteInvestmentToolAsync(Guid id);
}