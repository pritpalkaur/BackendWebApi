using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapi.Domain
{

    [Table("db_product")]
    public class Products
    {
        [Key]
        [Column("product_id")]
        public long ProductId { get; set; }
        [Column("product_name")]
        public string ProductName { get; set; }
        [Column("product_description")]
        public string ProuctDescription { get; set; }
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