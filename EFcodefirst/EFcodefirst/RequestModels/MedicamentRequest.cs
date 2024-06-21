namespace EFcodefirst.RequestModels;

public class MedicamentRequest
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; }
    public string Details { get; set; }
}