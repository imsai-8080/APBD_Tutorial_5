namespace APBD_Tutorial_5.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PCComponents
{
    public int PCId { get; set; }

    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; }

    [Required]
    public int Amount { get; set; }

    [ForeignKey(nameof(PCId))]
    public virtual PCs PC { get; set; }

    [ForeignKey(nameof(ComponentCode))]
    public virtual Components Component { get; set; }
}