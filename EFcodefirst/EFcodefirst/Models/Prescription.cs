using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace EFcodefirst.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }
    
    [ForeignKey("IdPatient")]
    public virtual Patient Patient { get; set; }
    
    [ForeignKey("IdDoctor")]
    public virtual Doctor Doctor { get; set; }
}