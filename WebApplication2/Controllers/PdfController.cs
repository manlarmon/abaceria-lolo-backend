using Microsoft.AspNetCore.Mvc;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AbaceriaLolo.WebAPI.Controllers
{
    [ApiController]
    [Route("Pdf")]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;
        private readonly IInventorySectionRepository _inventorySectionRepository;

        public PdfController(IPdfService pdfService, IInventorySectionRepository inventorySectionRepository)
        {
            _pdfService = pdfService;
            _inventorySectionRepository = inventorySectionRepository;
        }

        [HttpGet("inventory")]
        [Authorize]
        public async Task<IActionResult> GetInventoryPdf()
        {
            var inventorySections = await _inventorySectionRepository.GetAllInventorySectionsAsync();
            var pdfBytes = await _pdfService.GenerateInventoryPdfAsync(inventorySections);

            return File(pdfBytes, "application/pdf", "Inventory.pdf");
        }
    }
}
