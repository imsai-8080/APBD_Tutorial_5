using APBD_Tutorial_5.Data;
using APBD_Tutorial_5.Entities;
using APBD_Tutorial_5.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APBD_Tutorial_5.Services;

public class PcService : IPcService
{
    private readonly AppDbContext _context;

    public PcService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PCResponseDto>> GetAllPcsAsync()
    {
        return await _context.PCs
            .Select(p => new PCResponseDto {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            }).ToListAsync();
    }

    public async Task<IEnumerable<PCComponentResponseDto>?> GetPcComponentsAsync(int id)
    {
        var pcExists = await _context.PCs.AnyAsync(p => p.Id == id);
        if (!pcExists) return null;

        return await _context.PCComponents
            .Where(pcc => pcc.PCId == id)
            .Select(pcc => new PCComponentResponseDto {
                ComponentCode = pcc.ComponentCode,
                ComponentName = pcc.Component.Name,
                Amount = pcc.Amount
            }).ToListAsync();
    }

    public async Task<PCResponseDto> AddPcAsync(PCRequestDto dto)
    {
        var newPc = new PCs {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _context.PCs.Add(newPc);
        await _context.SaveChangesAsync();

        return new PCResponseDto {
            Id = newPc.Id,
            Name = newPc.Name,
            Weight = newPc.Weight,
            Warranty = newPc.Warranty,
            CreatedAt = newPc.CreatedAt,
            Stock = newPc.Stock
        };
    }

    public async Task<bool> UpdatePcAsync(int id, PCRequestDto dto)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc == null) return false;

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePcAsync(int id)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc == null) return false;

        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();
        return true;
    }
}