using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    public interface IDataprocessingResourceProvider
    {
        // No segregation. Database stuff mixed in with report generation stuff
        Database getDatabase();
        ReportGenerator getReportGenerator();
    }

    public class MyResourceProvider : IDataprocessingResourceProvider
    {
        public Database getDatabase()
        {
            return new SqlServerStuff.SqlServerDatabaseAdapter();
        }

        public ReportGenerator getReportGenerator()
        {
            return new ExcelReportGenerator();
        }
    }

    #region Interface Segregation Principle
    public interface IDatabaseResourceProvider
    {
        Database getDatabase();
    }

    public interface IReportGeneratorResourceProvider
    {
        ReportGenerator getReportGenerator();
    }

    public class OnlyDoReports : IReportGeneratorResourceProvider
    {
        // OnlyDoReports is not concerned with databases
        public ReportGenerator getReportGenerator()
        {
            return new ExcelReportGenerator();
        }
    }

    public class OnlyDoPostgresDatabses : IDatabaseResourceProvider
    {
        // OnlyDoPostgresDatabses is not concerned with reports
        public Database getDatabase()
        {
            return new PostgresStuff.PostgresDatabaseAdapter();
        }
    }
    #endregion
}
