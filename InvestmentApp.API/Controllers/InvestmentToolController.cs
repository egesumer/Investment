using Management.Api.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class InvestmentToolController : ControllerBase
{
    private readonly IInvestmentToolService _investmentToolService;

    public InvestmentToolController(IInvestmentToolService investmentToolService)
    {
        _investmentToolService = investmentToolService;
    }

    // Yatırım aracı oluşturma (Sadece Admin ve SuperAdmin)
    [HttpPost("create-investment-tool")]
    [Authorize]
    [UserTypeAuthorize(UserType.Admin, UserType.Superadmin)]
    public async Task<IActionResult> CreateInvestmentTool([FromBody] CreateInvestmentToolDto dto)
    {
        var createdInvestmentTool = await _investmentToolService.CreateInvestmentToolAsync(dto);

        if (createdInvestmentTool == null)
        {
            return BadRequest(new { success = false, message = "Investment tool creation failed." });
        }

        return Ok(new { success = true, message = "Investment tool created successfully.", data = createdInvestmentTool });
    }

    // Tüm yatırım araçlarını getirme
    [HttpGet("get-investment-tools")]
    [Authorize]
    public async Task<IActionResult> GetAllInvestmentTools()
    {
        var investmentTools = await _investmentToolService.GetAllInvestmentToolsAsync();
        return Ok(new { success = true, message = "Investment tools retrieved successfully.", data = investmentTools });
    }

    // Yatırım aracı ID'sine göre getirme
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetInvestmentToolById(Guid id)
    {
        var investmentTool = await _investmentToolService.GetInvestmentToolByIdAsync(id);
        if (investmentTool == null)
            return NotFound(new { success = false, message = "Investment tool not found." });

        return Ok(new { success = true, message = "Investment tool retrieved successfully.", data = investmentTool });
    }

    // Yatırım aracı güncelleme (Sadece Admin ve SuperAdmin)
    [HttpPut("{id}/update-investment-tool")]
    [Authorize]
    [UserTypeAuthorize(UserType.Admin, UserType.Superadmin)]
    public async Task<IActionResult> UpdateInvestmentTool(Guid id, [FromBody] UpdateInvestmentToolDto dto)
    {
        var updated = await _investmentToolService.UpdateInvestmentToolAsync(id, dto);
        if (!updated)
            return BadRequest(new { success = false, message = "Investment tool update failed." });

        return Ok(new { success = true, message = "Investment tool updated successfully." });
    }

    // Yatırım aracı silme (Sadece Admin ve SuperAdmin)
    [HttpDelete("{id}/delete-investment-tool")]
    [Authorize]
    [UserTypeAuthorize(UserType.Admin, UserType.Superadmin)]
    public async Task<IActionResult> DeleteInvestmentTool(Guid id)
    {
        var deleted = await _investmentToolService.DeleteInvestmentToolAsync(id);
        if (!deleted)
            return BadRequest(new { success = false, message = "Investment tool deletion failed." });

        return Ok(new { success = true, message = "Investment tool deleted successfully." });
    }
}
