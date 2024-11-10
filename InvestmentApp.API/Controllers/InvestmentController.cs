using Management.Api.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class InvestmentController : ControllerBase
{
    private readonly IInvestService _investService;

    public InvestmentController(IInvestService investService)
    {
        _investService = investService;
    }

    // Tüm yatırımları getirme (Admin ve Superadmin için)
    [HttpGet("get-investments")]
    [Authorize]
    [UserTypeAuthorize(UserType.Admin, UserType.Superadmin)]
    public async Task<IActionResult> GetAllInvestments([FromQuery] bool includeDeleted = false)
    {
        var investments = await _investService.GetAllInvestmentsAsync(includeDeleted);
        return Ok(new { success = true, message = "Investments retrieved successfully.", data = investments });
    }

    // Kullanıcıya ait yatırımları getirme
    [HttpGet("get-investments-by-user/{userId}")]
    [Authorize]
    public async Task<IActionResult> GetInvestmentsByUser(Guid userId, [FromQuery] bool includeDeleted = false)
    {
        // Kullanıcı ID'sini token'dan alıyoruz
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId.ToString() != currentUserId)
        {
            return Unauthorized(new { success = false, message = "You can only view your own investments." });
        }

        var investments = await _investService.GetInvestmentsByUserIdAsync(userId, includeDeleted);
        return Ok(new { success = true, message = "User investments retrieved successfully.", data = investments });
    }

    // Yatırım ID'sine göre yatırımı getirme
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetInvestmentById(Guid id, [FromQuery] bool includeDeleted = false)
    {
        var investment = await _investService.GetInvestmentByIdAsync(id, includeDeleted);
        if (investment == null)
            return NotFound(new { success = false, message = "Investment not found." });

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Kullanıcı ID'sini token'dan alıyoruz
        if (investment.UserId.ToString() != currentUserId)
        {
            return Unauthorized(new { success = false, message = "You can only view your own investments." });
        }

        return Ok(new { success = true, message = "Investment retrieved successfully.", data = investment });
    }

    // Yeni yatırım oluşturma
    [HttpPost("create-investment")]
    [Authorize]
    public async Task<IActionResult> CreateInvestment([FromBody] CreateInvestmentDto investmentDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // Kullanıcı ID'sini token'dan alıyoruz

        // Yatırım oluşturma işlemi
        var createdInvestment = await _investService.CreateInvestmentAsync(investmentDto, Guid.Parse(userId));

        if (createdInvestment == null)
        {
            return BadRequest(new { success = false, message = "Investment creation failed." });
        }

        return Ok(new { success = true, message = "Investment created successfully.", data = createdInvestment });
    }

    // Yatırım güncelleme
    [HttpPut("{id}/update-investment")]
    [Authorize]
    public async Task<IActionResult> UpdateInvestment(Guid id, [FromBody] UpdateInvestmentDto investmentDto)
    {
        var investment = await _investService.GetInvestmentByIdAsync(id);
        if (investment == null)
            return NotFound(new { success = false, message = "Investment not found." });

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // Kullanıcı ID'sini token'dan alıyoruz
        if (investment.UserId.ToString() != userId)
        {
            return Unauthorized(new { success = false, message = "You can only update your own investments." });
        }

        // Yatırım bilgilerini güncelle
        investment.Amount = investmentDto.Amount;
        investment.Price = investmentDto.Price;
        investment.InvestmentDate = investmentDto.InvestmentDate;

        var updated = await _investService.UpdateInvestmentAsync(investment);
        if (!updated)
            return BadRequest(new { success = false, message = "Investment update failed." });

        return Ok(new { success = true, message = "Investment updated successfully." });
    }

    // Yatırım silme (Sadece kullanıcı kendi yatırımlarını silebilir)
    [HttpDelete("{id}/delete-investment")]
    [Authorize]
    public async Task<IActionResult> DeleteInvestment(Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // Kullanıcı ID'sini token'dan alıyoruz
        var investment = await _investService.GetInvestmentByIdAsync(id);

        if (investment == null)
            return NotFound(new { success = false, message = "Investment not found." });

        // Kullanıcının sadece kendi yatırımlarını silebilmesi için kontrol yapıyoruz
        if (investment.UserId.ToString() != userId)
        {
            return Unauthorized(new { success = false, message = "You can only delete your own investments." });
        }

        var deleted = await _investService.DeleteInvestmentAsync(id);
        if (!deleted)
            return BadRequest(new { success = false, message = "Investment deletion failed." });

        return Ok(new { success = true, message = "Investment deleted successfully." });
    }
}
