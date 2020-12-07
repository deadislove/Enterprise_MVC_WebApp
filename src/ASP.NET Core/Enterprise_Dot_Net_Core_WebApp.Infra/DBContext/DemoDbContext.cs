using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.DBContext
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        { }

        public DbSet<Enterprise_MVC_Core> Enterprise_MVC_Cores { get; set; }
    }
}
