using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LatamQuants.Support;

namespace LatamQuants.Entities
{
    public partial class DBContext : DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<InstrumentMonitor> InstrumentsMonitor { get; set; }
        public DbSet<MarketData> MarketDataSet { get; set; }
        public DbSet<MarketDataDepth> MarketDataDepthSet { get; set; }
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<MonitorSetting> MonitorSettings { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AcceptedOpportunity> AcceptedOpportunities { get; set; }
        public DbSet<InstrumentOption> InstrumentOptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.Instance.ConnectionStrings.LQConnectionString);            
        }
    }
}