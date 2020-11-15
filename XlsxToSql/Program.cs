using System.Collections.Generic;
using System.IO;
using XlsxToSql.Models;
using XlsxToSql.Services;

namespace XlsxToSql
{
    class Program
    {
        static void Main(string[] args)
        {
            string databaseName = "";
            string filepath = "F:\\Test\\Test.xlsx";
            string scriptpath = "F:\\Test\\Database Script.sql";

            var importService = new XlsxImportService();

            // Eventually support multiple pages

            // Get the table structure from the spreadsheet
            var tables = new List<TableDto>();

            tables.Add(importService.ImportSpreadsheetStruct(filepath));

            // Generate script from table
            var script = new ScriptGeneratorService().GenerateScript(databaseName, tables);

            // Export script
            using (StreamWriter outputFile = new StreamWriter(scriptpath))
            {
                outputFile.WriteLine(script);
            }
        }
    }
}
