using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain
{
    
    [Table("db_report")]
    public class Report
    {
        [Key]
        [Column("report_id")]
        public long ReportId { get; set; }
        [Column("report_name")]
        public string ReportName { get; set; }
        [Column("report_description")]
        public string ReportDescription { get; set; }
        [Column("created_by")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_by")]
        [StringLength(50)]
        public string? UpdatedBy { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
