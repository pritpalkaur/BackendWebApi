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
    }
}
