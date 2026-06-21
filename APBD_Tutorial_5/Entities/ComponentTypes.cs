using System.ComponentModel.DataAnnotations;

namespace APBD_Tutorial_5.Entities;

public class ComponentTypes
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; }

    public virtual ICollection<Components> Components { get; set; } = new List<Components>();
}