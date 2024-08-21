using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Exceptions.Data
{
    public class LoggingDbContext : DbContext
    {
        public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options)
        {
        }

        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
    }
    [Table("db_ExceptionLog")]
    public class ExceptionLog
    {
        [Key]
        [Column("ExceptionId")]
        public int ExceptionId { get; set; }
        [Column("Timestamp")]
        public DateTime Timestamp { get; set; }
        [Column("Message")]
        public string Message { get; set; }
        [Column("StackTrace")]
        public string StackTrace { get; set; }
        [Column("Source")]
        public string Source { get; set; }
    }

}
