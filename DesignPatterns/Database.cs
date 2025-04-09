using Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Open Closed Principle
namespace Design
{
    public abstract class Database  // Interface is also a good choice
    {
        public abstract Data LoadData();
    }
}

namespace PostgresStuff // this can go in a separate library
{

    public class PostgresDatabaseAdapter : Design.Database
    {
        public override Data LoadData()
        {
            var db = new PostgresDatabase("connectionStringAndPassordForPostgres");
            db.DoSomethingSpecificToPostgres();
            Console.WriteLine("Loading data from Postgres");
            return db.LoadData("select * from table");
        }
    }
}

namespace SqlServerStuff // this can go in a separate library
{
    public class SqlServerDatabaseAdapter : Design.Database
    {
        public override Data LoadData()
        {
            var db = new SqlServerDatabase("connectionStringAndPassordForSqlServer");
            db.DoSomethingSpecificToSqlServer();
            Console.WriteLine("Loading data from SqlServer");
            return db.LoadDataButInASqlServerKindOfWay("select * from table");
        }
    }
}
#endregion