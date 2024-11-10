public class User : BaseEntity
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string? Email { get; set; }
    public UserType UserType { get; set; }
    public decimal TotalInvestment { get; set; }
    public ICollection<Investment> Investments { get; set; }
}