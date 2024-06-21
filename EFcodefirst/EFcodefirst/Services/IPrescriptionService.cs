using EFcodefirst.Models;
using EFcodefirst.RequestModels;

namespace EFcodefirst.Services;

public interface IPrescriptionService
{
    Task<bool> FulfillPrescription(PrescriptionRequest Request);
}