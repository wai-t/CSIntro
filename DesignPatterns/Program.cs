// See https://aka.ms/new-console-template for more information
using Design;


// in this example, the main program depends on 
// DataProcessor, which depends on PostgresDatabase and SqlServerDatabase, and 
// ExcelReportGenerator, PdfReportGenerator, and WordReportGenerator
// If something changes anything that depends on it must be recompiled or
// recoded if methods or properties are removed or changed
var dataProcessor = new Design.DataProcessor();
dataProcessor.ProcessData();

#region Dependency Inversion
// Dependency inversion means that the DataProcessor class does not depend on the implementations of
// PostgresDatabase, SqlServerDatabase, ExcelReportGenerator, PdfReportGenerator, or WordReportGenerator
// but only on the interfaces Database and ReportGenerator. This means that if any of the implementations
// change, the DataProcessor class does not need to be recompiled or recoded. The main program here
// does depend on all of the implementations, but it's much easier to manage as these are all in one
// place and not scattered throughout the code.
//
var reportGeneratorDI = new OnlyDoReports().getReportGenerator();
var databaseDI = new OnlyDoPostgresDatabses().getDatabase();
var dataProcessorDI = new Design.DIDataProcessor(databaseDI, reportGeneratorDI);
dataProcessorDI.ProcessData();
#endregion