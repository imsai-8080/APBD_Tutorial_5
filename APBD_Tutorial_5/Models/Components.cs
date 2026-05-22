namespace APBD_Tutorial_5.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Components
{
    [Key]
    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    public string Code { get; set; }

    [Required]
    [MaxLength(300)]
    public string Name { get; set; }

    public string? Description { get; set; } 

    [Required]
    public int ComponentManufacturerId { get; set; }

    [Required]
    public int ComponentTypeId { get; set; }

    [ForeignKey(nameof(ComponentManufacturerId))]
    public virtual ComponentManufacturers ComponentManufacturer { get; set; }

    [ForeignKey(nameof(ComponentTypeId))]
    public virtual ComponentTypes ComponentType { get; set; }

    public virtual ICollection<PCComponents> PCComponents { get; set; } = new List<PCComponents>();
}