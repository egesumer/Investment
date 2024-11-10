public class InvestmentDto
{
    public Guid Id { get; set; } // Yatırım ID'si
    public Guid InvestmentToolId { get; set; } // Yatırım aracının ID'si
    public string InvestmentToolName { get; set; } // Yatırım aracının adı (Altın, Gümüş vb.)
    public decimal Amount { get; set; } // Yatırım miktarı
    public decimal Price { get; set; } // Yatırımın alındığı fiyat
    public DateTime InvestmentDate { get; set; } // Yatırım tarihi
}
