using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    #region Open Closed Principle
    public abstract class ReportGenerator
    {
        public abstract void GenerateReport(Data data);
    }


    public class ExcelReportGenerator : ReportGenerator
    {
        public override void GenerateReport(Data data)
        {
            Console.WriteLine("Generating Excel report");
        }
    }

    public class PdfReportGenerator : ReportGenerator
    {
        public override void GenerateReport(Data data)
        {
            Console.WriteLine("Generating Pdf report");
        }
    }

    public class WordReportGenerator : ReportGenerator
    {
        public override void GenerateReport(Data data)
        {
            Console.WriteLine("Generating Word report");
        }
    }

    #endregion
}
