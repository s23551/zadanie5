using EFcodefirst.Models;

namespace EFcodefirst.RequestModels;

public class PrescriptionRequest
{
    public Patient Patient {
        get;
        set;
    }

    public ICollection<MedicamentRequest> Medicaments { get; set; }

    public Doctor Doctor { get; set; }

    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
}