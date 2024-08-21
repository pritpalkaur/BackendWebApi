using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Business;
using WebApi.Business.Interface;
using WebApi.Domain;
using WebApi.Data;
using WebApi.Data.Interface;

namespace WebApi.Business.Implementations
{
    public class ReportBusiness : IReportBusiness
    {
        private readonly IReportDatabase _IReportDatabase;
        public ReportBusiness(IReportDatabase IReportDatabase)
        {
            _IReportDatabase = IReportDatabase;
        }
        public async Task<List<Report>> GetReportsAsync()
        {
            return await _IReportDatabase.GetReportsAsync();
        }
    }
}
