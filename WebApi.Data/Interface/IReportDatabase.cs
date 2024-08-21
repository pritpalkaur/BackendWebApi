using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain;

namespace WebApi.Data.Interface
{
    public interface IReportDatabase
    {
        Task<List<Report>> GetReportsAsync();
    }
}
