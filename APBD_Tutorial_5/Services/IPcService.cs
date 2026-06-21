using APBD_Tutorial_5.DTOs;

namespace APBD_Tutorial_5.Services;

public interface IPcService
{
    Task<IEnumerable<PCResponseDto>> GetAllPcsAsync();
    Task<IEnumerable<PCComponentResponseDto>?> GetPcComponentsAsync(int id);
    Task<PCResponseDto> AddPcAsync(PCRequestDto dto);
    Task<bool> UpdatePcAsync(int id, PCRequestDto dto);
    Task<bool> DeletePcAsync(int id);
}