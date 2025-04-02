using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{

    public enum ReportType
    {
        Pdf,
        Excel,
        Word
    }
    public class DataProcessor
    {
        bool usePostgres = false;
        ReportType reportType = ReportType.Pdf;

        public void ProcessData()
        {
            Data data;
            if (usePostgres)
            {
                var db = new PostgresDatabase("connectionStringAndPassordForPostgres");
                db.DoSomethingSpecificToPostgres();
                data = db.LoadData("select * from table");
            }
            else
            {
                var db = new SqlServerDatabase("connectionStringAndPassordForSqlServer");
                db.DoSomethingSpecificToSqlServer();
                data = db.LoadDataButInASqlServerKindOfWay("select * from table");
            }

            // do something with data
            switch (reportType)
            {
                case ReportType.Pdf:
                    data.ToPdf();
                    break;
                case ReportType.Excel:
                    data.ToExcel();
                    break;
                case ReportType.Word:
                    data.ToWord();
                    break;
            }
        }
        #region With Liskov
        public static void ProcessDataLiskov(Database db, ReportGenerator reportGenerator)
        {
            // Liskov substitution principle says that anything that inherits from Database
            // and ReportGenerator can be used here
            Data data = db.LoadData();
            reportGenerator.GenerateReport(data);
        }
        #endregion
    }


    public class SqlServerDatabase
    {
        private string v;

        public SqlServerDatabase(string v)
        {
            this.v = v;
        }

        internal void DoSomethingSpecificToSqlServer()
        {
            throw new NotImplementedException();
        }

        internal Data LoadDataButInASqlServerKindOfWay(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class PostgresDatabase
    {
        private string v;

        public PostgresDatabase(string v)
        {
            this.v = v;
        }

        internal void DoSomethingSpecificToPostgres()
        {
            throw new NotImplementedException();
        }

        internal Data LoadData(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class Data
    {
        public void ToExcel()
        {
            throw new NotImplementedException();
        }

        public void ToPdf()
        {
            throw new NotImplementedException();
        }

        public void ToWord()
        {
            throw new NotImplementedException();
        }
    }

    #region Dependency Inversion
    // With Dependency Inversion Principle
    public class DIDataProcessor
    {
        private Database db;
        private ReportGenerator reportGenerator;
        public DIDataProcessor(Database db, ReportGenerator reportGenerator)
        {
            this.db = db;
            this.reportGenerator = reportGenerator;
        }
        public void ProcessData()
        {
            Data data = db.LoadData();
            reportGenerator.GenerateReport(data);
        }
    }
    #endregion

}
