using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LatamQuants.Entities
{
    public partial class DBContext : DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }

        public DBContext() : base("LQConnectionString")
        {
        }
    }
}