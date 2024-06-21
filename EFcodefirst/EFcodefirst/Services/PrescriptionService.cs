using EFcodefirst.Context;
using EFcodefirst.Exceptions;
using EFcodefirst.Models;
using EFcodefirst.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace EFcodefirst.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly ApbdContext _dbContext;

    public PrescriptionService(ApbdContext apbdContext)
    {
        _dbContext = apbdContext;
    }

    public async Task<bool> FulfillPrescription(PrescriptionRequest Request)
    {
        EnsureDueDateAfterDate(Request);
        EnsureMedicamentsListNotBiggerThan10(Request);
        EnsureMedicamentsListNotEmpty(Request);
        EnsureMedicamentsExist(Request);

        var Patient = Request.Patient;
        CheckOrCreatePatient(Patient);

        var requestedPrescription = new Prescription()
        {
            Patient = Patient,
            Doctor = Request.Doctor,
            Date = Request.Date,
            DueDate = Request.DueDate
        };
        await _dbContext.Prescriptions.AddAsync(requestedPrescription);
        var IdPrescription = requestedPrescription.IdPrescription;
        
        foreach (var Medicament in Request.Medicaments)
        {
            var requestedPrescriptionMedicamentAssotiation = new Prescription_Medicament()
            {
                IdPrescription = IdPrescription,
                IdMedicament = Medicament.IdMedicament,
                Dose = Medicament.Dose,
                Details = Medicament.Details
            };
            await _dbContext.PrescriptionMedicaments.AddAsync(requestedPrescriptionMedicamentAssotiation);
        }

        return true;
    }

    private static void EnsureDueDateAfterDate(PrescriptionRequest Request)
    {
        if (Request.DueDate < Request.Date)
        {
            throw new DueDateBeforeDateException();
        }
    }

    private static void EnsureMedicamentsListNotBiggerThan10(PrescriptionRequest Request)
    {
        if (Request.Medicaments.Count > 10)
        {
            throw new MedicamentsListAbove10Exception();
        }
    }

    private static void EnsureMedicamentsListNotEmpty(PrescriptionRequest Request)
    {
        if (Request.Medicaments.Count < 1)
        {
            throw new MedicamentsListEmptyException();
        }
    }

    private void EnsureMedicamentsExist(PrescriptionRequest Request)
    {
        foreach (var requestMedicament in Request.Medicaments) 
        {
            EnsureSingleMedicamentExists(requestMedicament);    
        }
    }

    private async void EnsureSingleMedicamentExists(MedicamentRequest Medicament)
    {
        var checkForExisitingMedicament =
            await _dbContext.Medicaments.Where(m => m.IdMedicament == Medicament.IdMedicament).CountAsync();

        if (checkForExisitingMedicament != 1)
        {
            throw new MedicamentDoesNotExistException();
        }
    }

    private async void CheckOrCreatePatient(Patient Patient)
    {
        var checkForPatientExist = await _dbContext.Patients.ContainsAsync(Patient);
        if (!checkForPatientExist)
        {
            await _dbContext.Patients.AddAsync(Patient);
        }
        
    }
}