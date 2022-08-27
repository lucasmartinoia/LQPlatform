using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using LatamQuants.Entities;
using System.Data.Entity.Migrations;

namespace LQTrader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainProfile());

            });
            mappingConfig.AssertConfigurationIsValid();
            IMapper mapper = mappingConfig.CreateMapper();
            Service.mapper = mapper;
            //---

            // Update database if it necessary
            using (var db = new DBContext())
            {
                RunUpdate(db.Database.Connection.ConnectionString);
                db.SaveChanges();
                RunUpdate(db.Database.Connection.ConnectionString); // We call it again to force executing the seeds everytime
            }

            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TraderView());
        }

        private static void RunUpdate(string pConnString)
        {
            var configuration = new LatamQuants.Entities.Migrations.Configuration();

            //could use connectionName or connectionString and Provider
            configuration.TargetDatabase =
                new System.Data.Entity.Infrastructure.DbConnectionInfo(pConnString, "System.Data.SqlClient");

            var migrator = new DbMigrator(configuration);
            //just for debugginf purposes
            var pendings = migrator.GetPendingMigrations();
            migrator.Update();
        }
    }
}
