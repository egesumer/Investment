public class Investment : BaseEntity
{
    public Guid UserId { get; set; }    // Kullanıcı Referansı
    public User User { get; set; }
    
    public Guid InvestmentToolId { get; set; }   // Yatırım aracı (Örnek: Altın)
    public InvestmentTool InvestmentTool { get; set; }

    public decimal Amount { get; set; }   // Yatırım miktarı (Örneğin, 1 Cumhuriyet Altını)
    public decimal Price { get; set; }    // Yatırımın alındığı fiyat
    public DateTime InvestmentDate { get; set; } // Yatırım Tarihi
}
