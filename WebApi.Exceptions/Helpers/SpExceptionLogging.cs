using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mMoser.Exceptions.Helpers
{

    public class SpExceptionLogging
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("ReturnValue")]
        public string ReturnValue { get; set; }
    }
}
