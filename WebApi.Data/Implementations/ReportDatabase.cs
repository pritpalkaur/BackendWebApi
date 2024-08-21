using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Interface;
using WebApi.Domain;
using System.Data.SqlClient;

namespace WebApi.Data.Implementations
{
    public class ReportDatabase : IReportDatabase
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ReportDatabase(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<List<Report>> GetReportsAsync()
        {
            var reports = new List<Report>();

            using (var connection = _dbConnectionFactory.CreateConnection())
            using (var command = new SqlCommand("SELECT * FROM db_report", connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    reports.Add(new Report
                    {
                        ReportId = reader.GetInt64(reader.GetOrdinal("report_id")),
                        ReportName = reader.GetString(reader.GetOrdinal("report_name")),
                        ReportDescription = reader.IsDBNull(reader.GetOrdinal("report_description"))
                                            ? null
                                            : reader.GetString(reader.GetOrdinal("report_description")),
                        CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at")),
                        CreatedBy = reader.GetString(reader.GetOrdinal("created_by")),
                        UpdatedBy = reader.IsDBNull(reader.GetOrdinal("updated_by"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("updated_by")),
                        UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime(reader.GetOrdinal("updated_at"))
                    });
                }
            }

            return reports;
        }
    }
}

