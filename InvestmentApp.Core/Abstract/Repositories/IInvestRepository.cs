public interface IInvestRepository : IRepository<Investment>
{
    Task<IEnumerable<Investment>> GetInvestmentsByUserIdAsync(Guid userId, bool includeDeleted = false);
    Task<Investment> GetInvestmentByToolAndUserAsync(Guid userId, Guid toolId, bool includeDeleted = false);
}
