public interface IInvestmentToolRepository : IRepository<InvestmentTool>
{
    Task<InvestmentTool> GetBySymbolAsync(string symbol);
}