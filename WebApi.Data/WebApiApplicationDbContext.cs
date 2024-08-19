﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Webapi.Domain;

namespace WebApi.Data
{
    public partial class WebApiApplicationDbContext : IdentityDbContext
    {
        public WebApiApplicationDbContext(DbContextOptions<WebApiApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //remove warning for the save point disabled
            optionsBuilder.ConfigureWarnings(w => w.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS));
        }

        public DbSet<Products> Products { get; set; }
    }
}

