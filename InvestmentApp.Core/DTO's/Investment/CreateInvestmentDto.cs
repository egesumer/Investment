public class CreateInvestmentDto
{
    public Guid InvestmentToolId { get; set; } // Yatırım aracının ID'si
    public decimal Amount { get; set; } // Yatırım miktarı
    public DateTime InvestmentDate { get; set; } // Yatırım tarihi
}
