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
        private readonly WebApiApplicationDbContext _context;
        private readonly string _connectionString;

        public ReportDatabase(WebApiApplicationDbContext context)
        {
            _context = context;
            _connectionString = _context.Database.GetDbConnection().ConnectionString; // Get the connection string from EF context
        }

        public async Task<List<Report>> GetReportsAsync()
        {
            List<Report> reports = new List<Report>();

            try
            {
                // Using ADO.NET to make the database call
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM db_report", conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Report report = new Report
                                {
                                    ReportId = reader.GetInt64(reader.GetOrdinal("report_id")), // Changed from GetInt32 to GetInt64
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
                                };

                                reports.Add(report);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("An error occurred while fetching reports", ex);
            }

            return reports;
        }


    }
}


