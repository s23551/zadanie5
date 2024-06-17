using EFcodefirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EFcodefirst.Context;

public class ApbdContext : DbContext
{
    public ApbdContext()
    {
    }

    public ApbdContext(DbContextOptions<ApbdContext> options) : base(options)
    {
    }
    
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }

}