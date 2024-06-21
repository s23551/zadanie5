using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EFcodefirst.Models;

[Table("Prescription_Medicament")]
public class Prescription_Medicament
{
    [Key]
    public int IdMedicament { get; set; }

    [Key]
    public int IdPrescription {
        get;
        set;
    }
    
    [ForeignKey("IdMedicament")]
    public virtual Medicament Medicament { get; set; }
    
    [ForeignKey("IdPrescription")]
    public virtual Prescription Prescription { get; set; }
    
    public int? Dose { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Details { get; set; }
}
