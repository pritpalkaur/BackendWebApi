using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
//using mMoser.Domin.Models.VendorModel;
using mMoser.Exceptions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mMoser.Exceptions.Data
{
    public partial class mMoserExceptionDbContext : IdentityDbContext
    {
        public mMoserExceptionDbContext(DbContextOptions<mMoserExceptionDbContext> options) : base(options)
        {
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //remove warning for the save point disabled
            optionsBuilder.ConfigureWarnings(w => w.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS));
        }
        public virtual DbSet<SpExceptionLogging> SpExceptionLogging { get; set; }
        public virtual DbSet<SpExceptionsDetals> SpExceptionsDetals { get; set; }

    }
}
