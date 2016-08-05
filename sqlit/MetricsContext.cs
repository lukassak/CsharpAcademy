using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;

namespace sqlit
{
    public class MetricsContext:DbContext
    {
        public DbSet<UsageData> UsageDatas { get; set; }
        public DbSet<ComputerDetail> ComputerDetails { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "metrics.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }


}
