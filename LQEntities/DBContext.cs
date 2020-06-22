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
        public DbSet<InstrumentMonitor> InstrumentsMonitor { get; set; }
        public DbSet<MarketData> MarketDataSet { get; set; }
        public DbSet<MarketDataDepth> MarketDataDepthSet { get; set; }
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<StrategyInstrument> StrategyInstruments { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }

        public DBContext() : base("LQConnectionString")
        {
        }
    }
}