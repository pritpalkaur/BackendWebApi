using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace mMoser.Exceptions.Data
{
    public class SpExceptionsDetals
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("message")]
        public string message { get; set; }
        [Column("stack_trace")]
        public string stack_trace { get; set; }
        [Column("inner_exception")]
        public string inner_exception { get; set; }
        [Column("created_at")]
        public DateTime created_at { get; set; }

    }
}