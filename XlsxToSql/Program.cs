using XlsxToSql.Services;

namespace XlsxToSql
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "F:\\Test\\Test.xlsx";

            var importService = new XlsxImportService();

            importService.ImportSpreadsheet(filepath);
        }
    }
}
