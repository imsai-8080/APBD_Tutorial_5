namespace APBD_Tutorial_5.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ComponentManufacturers
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; }

    [Required]
    [MaxLength(300)]
    public string FullName { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateTime FoundationDate { get; set; }

    public virtual ICollection<Components> Components { get; set; } = new List<Components>();
}