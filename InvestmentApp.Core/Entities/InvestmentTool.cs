public class InvestmentTool : BaseEntity
{
    public string Name { get; set; }   // Yatırım aracının adı (Örnek: Altın)
    public string Symbol { get; set; } // Yatırım aracının sembolü (Örnek: XAU)
    public decimal CurrentValue { get; set; } // Yatırım aracının güncel fiyatı
}
