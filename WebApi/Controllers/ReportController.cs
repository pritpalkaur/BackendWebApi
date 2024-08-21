using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Interface;
using WebApi.Exceptions.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ILoggingService _ILoggingService;
        private readonly IReportBusiness _IReportBusiness;
        public ReportController(IReportBusiness IReportBusiness, ILoggingService ILoggingService)
        {
            _IReportBusiness = IReportBusiness;
            _ILoggingService = ILoggingService;
        }
        // Method to get a product by its ID
        [HttpGet("GetReports")]
        public async Task<IActionResult> GetReports()
        {

            var reports = await _IReportBusiness.GetReportsAsync();

            // If product is found, return 200 OK with the product details
            return Ok(reports);
        }
    }
}
