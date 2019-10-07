﻿using EntityFrameworkCore.RawSQLExtensions.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using Z.EntityFramework.Plus;

namespace INOM.Entities
{
    public class DBContext : DbContext
    {
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<BrokerProductType> BrokerProductTypes { get; set; }
        public DbSet<BrokerProductException> BrokerProductExceptions { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<MarketProduct> MarketProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderFund> OrderFunds { get; set; }
        public DbSet<OrderBondEquity> OrderBondEquities { get; set; }
        public DbSet<MarketOrder> MarketOrders { get; set; }
        public DbSet<FundsOrder> FundsOrders { get; set; }
        public DbSet<FundsTrade> FundsTrades { get; set; }
        public DbSet<OrderTracking> OrdersTracking { get; set; }
        public DbSet<InstructionTracking> InstructionsTracking { get; set; }
        public DbSet<UserAccess> UserAccesses { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<InstructionFundsCancelOrder> InstructionFundsCancelOrders { get; set; }
        public DbSet<InstructionFundsTransferFund> InstructionFundsTransferFunds { get; set; }
        public DbSet<InstructionFundsPromoteClass> InstructionFundsPromoteClasses { get; set; }
        public DbSet<InstructionFundsAmendOrder> InstructionFundsAmendOrders { get; set; }
        public DbSet<Scheduler> Schedulers { get; set; }
        public DbSet<InstructionFundsPermanent> InstructionFundsPermanents { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<SettlementSwift> SettlementSwifts { get; set; }
        public DbSet<SettlementMep> SettlementMeps { get; set; }
        public DbSet<SettlementSap> SettlementSaps { get; set; }
        public DbSet<MarketInstruction> MarketInstructions { get; set; }
        public DbSet<FundsInstruction> FundsInstructions { get; set; }
        public DbSet<CalypsoResponse> CalypsoResponses { get; set; }
        public DbSet<UIOrderResult> UIOrderResults { get; set; }
        public DbSet<UIInstructionResult> UIInstructionResults { get; set; }
        public DbSet<UIChannel> UIChannels { get; set; }
        public DbSet<InstructionResult> InstructionsResults { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<OrderToReceipt> OrderToReceipts { get; set; }
        public DbSet<OrderToBT> OrdersToBT { get; set; }
        public DbSet<InstructionToReceipt> InstructionToReceipts { get; set; }
        public DbSet<CalypsoInstrument> CalypsoInstruments { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<InstrumentBond> InstrumentBonds { get; set; }
        public DbSet<InstrumentEquity> InstrumentEquities { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<CalypsoCalendar> CalypsoCalendars { get; set; }
        public DbSet<CalypsoHoliday> CalypsoHolidays { get; set; }
        public DbSet<Mapping> Mappings { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<SettlementAccountingEntry> SettlementAccountingEntries { get; set; }
        public DbSet<MarketTrade> MarketTrades { get; set; }
        public DbSet<MarketPend> MarketsPend { get; set; }
        public DbSet<MarketHist> MarketsHist { get; set; }
		public DbSet<InstrumentFamily> InstrumentFamilies { get; set; }
        public DbSet<InstrumentFamilyMarket> InstrumentFamilyMarkets { get; set; }
        public DbSet<InstrumentFamilyPend> InstrumentFamiliesPend { get; set; }
        public DbSet<InstrumentFamilyMarketPend> InstrumentFamilyMarketsPend { get; set; }
        public DbSet<InstrumentFamilyHist> InstrumentFamiliesHist { get; set; }
        public DbSet<InstrumentFamilyMarketHist> InstrumentFamilyMarketsHist { get; set; }
        public DbSet<RejectParameter> RejectParameters { get; set; }
        public DbSet<InstrumentMarket> InstrumentMarkets { get; set; }
        public DbSet<InstrumentMarketMarket> InstrumentMarketMarkets { get; set; }


        public DbSet<InstrumentMarketPend> InstrumentMarketsPend { get; set; }
        public DbSet<InstrumentMarketMarketPend> InstrumentMarketMarketsPend { get; set; }

        public DbSet<InstrumentMarketHist> InstrumentMarketsHist { get; set; }
        public DbSet<InstrumentMarketMarketHist> InstrumentMarketMarketsHist { get; set; }

        #region BYMA
        public DbSet<BymaOrder> BymaOrders { get; set; }
        public DbSet<BymaExecutionReport> BymaExecutionReports { get; set; }
        public DbSet<BymaTradeCaptureReport> BymaTradeCaptureReports { get; set; }
        public DbSet<BymaOrderCancellation> BymaOrderCancellations { get; set; }
        public DbSet<InstrumentByma> InstrumentsByma { get; set; }
        #endregion

        #region MAE
        public DbSet<MaeOrder> MaeOrders { get; set; }
        public DbSet<MaeExecutionReport> MaeExecutionReports { get; set; }
        public DbSet<MaeTradeCaptureReport> MaeTradeCaptureReports { get; set; }
        public DbSet<MaeOrderCancellation> MaeOrderCancellations { get; set; }
        public DbSet<InstrumentMae> InstrumentsMae { get; set; }

        #endregion




        // Audit tables ----------------------------------------------------------------
        public DbSet<AuditEntry> AuditEntries { get; set; }
        public DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }
        // -----------------------------------------------------------------------------

        // Fee Settlement Fund Tables --------------------------------------------------
        public DbSet<FeeSettlementFund> FeeSettlementFund { get; set; }
        public DbSet<FeeSettlementErrorLog> FeeSettlementErrorLog { get; set; }
        // -----------------------------------------------------------------------------

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
            AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
               // ADD "Where(x => x.AuditEntryID == 0)" to allow multiple SaveChanges with same Audit
               (context as DBContext).AuditEntries.AddRange(audit.Entries);
        }

        public DBContext()
        {
            var options = new DbContextOptionsBuilder<DBContext>()
                .UseSqlServer(Support.Config.ReadSettings.ReadDBConnection())
                .Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderFund>();

            // Order and Instruction sequence Field OrderNumber.
            modelBuilder.HasSequence<int>("OrderInstructionNumberIDs", schema: "shared")
                .StartsAt(1) // TODO: check for migration which number should be for first trade in OMS. 
                .IncrementsBy(1);

            // Order and Instruction ID sequence.
            modelBuilder.HasSequence<int>("OrderInstructionIDs", schema: "shared")
                .StartsAt(1) // TODO: check for migration which number should be for first trade in OMS. 
                .IncrementsBy(1);

            // <Market>Trades ID sequence.
            modelBuilder.HasSequence<int>("MarketTradeIDs", schema: "shared")
                .StartsAt(1) // TODO: check for migration which number should be for first trade in OMS. 
                .IncrementsBy(1);


            // Use same sequence for all order and instruction records.
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderID)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.OrderInstructionIDs");

            modelBuilder.Entity<Instruction>()
                .Property(o => o.InstructionID)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.OrderInstructionIDs");

            // MarketProducts
            modelBuilder.Entity<MarketProduct>()
                .HasKey(c => new { c.MarketID, c.ProductID });

            // BrokerProductTypes
            modelBuilder.Entity<BrokerProductType>()
                .HasKey(c => new { c.BrokerID, c.ProductTypeID });

            // BrokerProductExceptions
            modelBuilder.Entity<BrokerProductException>()
                .HasKey(c => new { c.BrokerID, c.ProductID });

            // Use same sequence for all <Market>Trade records.
            modelBuilder.Entity<FundsTrade>()
                .Property(o => o.MarketTradeID)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.MarketTradeIDs");

            // FundsTrades
            modelBuilder.Entity<FundsTrade>()
                .HasOne(p => p.FundsOrder)
                .WithMany(b => b.FundsTrades);

            // Use same sequence for all <Market>Trade records.
            modelBuilder.Entity<MarketTrade>()
                .Property(o => o.MarketTradeID)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.MarketTradeIDs");

            //// BymaTrades
            //modelBuilder.Entity<BymaTrade>()
            //    .HasOne(p => p.BymaOrder)
            //    .WithMany(b => b.BymaTrades);

            // Use same sequence for all <FeeSettlementFund> Fee Settlements records.
            modelBuilder.Entity<FeeSettlementFund>()
                .Property(o => o.FeeSettlementID)
                .HasDefaultValueSql("NEXT VALUE FOR shared.MarketTradeIDs");

            // InstrumentFamilyMarketPend
            modelBuilder.Entity<InstrumentFamilyMarketPend>()
                .HasKey(i => new { i.InstrumentFamilyID, i.MarketID});

            // InstrumentFamilyMarket
            modelBuilder.Entity<InstrumentFamilyMarket>()
                .HasKey(i => new { i.InstrumentFamilyID, i.MarketID });

            // InstrumentFamilyMarketHist
            modelBuilder.Entity<InstrumentFamilyMarketHist>()
                .HasKey(i => new { i.InstrumentFamilyID, i.MarketID });

            // InstrumentMarketMarket
            modelBuilder.Entity<InstrumentMarketMarket>()
                .HasKey(i => new { i.InstrumentID, i.MarketID });

            // InstrumentMarketMarket
            modelBuilder.Entity<InstrumentMarketMarketPend>()
                .HasKey(i => new { i.InstrumentID, i.MarketID });

            // InstrumentMarketMarket
            modelBuilder.Entity<InstrumentMarketMarketHist>()
                .HasKey(i => new { i.InstrumentID, i.MarketID });

        }

        /// <summary>
        /// Definicion del connection string.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Support.Config.ReadSettings.ReadDBConnection());
            optionsBuilder.EnableSensitiveDataLogging();
        }


        public int GetMarketSequence()
        {
            return Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.MarketSeqID;").SingleAsync().Result;
        }

        public int GetNextSequenceValue()
        {
            try
            {
                var rawQuery = Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.OrderInstructionNumberIDs;");
                var task = rawQuery.SingleAsync();
                int nextVal = task.Result;
                //int nextVal = 0;
                return nextVal;
            }
            catch (Exception ex)
            {
                string aa = ex.Message;
                return 0;
            }
        }
    }
}
