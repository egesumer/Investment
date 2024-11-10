public interface IInvestService
{
    Task<Investment> CreateInvestmentAsync(CreateInvestmentDto investmentDto, Guid userId);
    Task<IEnumerable<Investment>> GetAllInvestmentsAsync(bool includeDeleted = false);
    Task<Investment> GetInvestmentByIdAsync(Guid id, bool includeDeleted = false);
    Task<bool> UpdateInvestmentAsync(Investment investment);
    Task<bool> DeleteInvestmentAsync(Guid id);
    Task<IEnumerable<Investment>> GetInvestmentsByUserIdAsync(Guid userId, bool includeDeleted = false);
    Task<Investment> GetInvestmentByToolAndUserAsync(Guid userId, Guid toolId, bool includeDeleted = false);
}
