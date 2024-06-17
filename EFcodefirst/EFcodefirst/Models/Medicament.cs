using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFcodefirst.Models;

[Table("Medicament")]
public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    
    [MaxLength(200)]
    [Required]
    public string Name { get; set; }
    
    [MaxLength(200)]
    [Required]
    public string Description { get; set; }
    
    [MaxLength(200)]
    [Required]
    public string Type { get; set; }
}