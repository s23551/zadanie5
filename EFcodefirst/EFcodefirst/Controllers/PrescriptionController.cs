using EFcodefirst.RequestModels;
using EFcodefirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFcodefirst.Controllers;

[ApiController]
[Route("prescriptions")]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionRequest PrescriptionRequest)
    {
        var success = await _prescriptionService.FulfillPrescription(PrescriptionRequest);
        return success ? Ok() : BadRequest();
    }
}