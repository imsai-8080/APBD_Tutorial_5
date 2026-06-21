using APBD_Tutorial_5.DTOs;
using APBD_Tutorial_5.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Tutorial_5.Controllers;

[Route("api/pcs")]
[ApiController]
public class PcsController : ControllerBase
{
    private readonly IPcService _pcService;

    public PcsController(IPcService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPcs()
    {
        var pcs = await _pcService.GetAllPcsAsync();
        return Ok(pcs); // 200 OK
    }

    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPcComponents(int id)
    {
        var components = await _pcService.GetPcComponentsAsync(id);
        if (components == null) return NotFound(); // 404 Not Found
        return Ok(components);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePc([FromBody] PCRequestDto dto)
    {
        var result = await _pcService.AddPcAsync(dto);
        return CreatedAtAction(nameof(GetPcs), new { id = result.Id }, result); // 201 Created
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePc(int id, [FromBody] PCRequestDto dto)
    {
        var updated = await _pcService.UpdatePcAsync(id, dto);
        if (!updated) return NotFound();
        return Ok(); // 200 OK wg dokumentacji
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePc(int id)
    {
        var deleted = await _pcService.DeletePcAsync(id);
        if (!deleted) return NotFound();
        return NoContent(); // 204 No Content
    }
}