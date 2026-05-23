using System.ComponentModel.DataAnnotations;

namespace APBD_Tutorial_5.DTOs;

public class PCRequestDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [Range(0.1, 1000)]
    public double Weight { get; set; }

    [Required]
    public int Warranty { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}