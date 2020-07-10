using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Entities
{
    class DBInitializer : CreateDatabaseIfNotExists<DBContext>
    {
        protected override void Seed(DBContext db)
        {
            // Use the seeds configured in Entities\Migrations\Configuration.cs
        }
    }
}
