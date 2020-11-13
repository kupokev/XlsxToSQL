using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;
using XlsxToSql.Models;

namespace XlsxToSql.Services
{
    public class XlsxImportService
    {
        public void ImportSpreadsheet(string filepath)
        {
            var columns = new List<ColumnDto>();

            using(ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filepath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                // Get column names
                for( int i = worksheet.Dimension.Start.Column; i <= worksheet.Dimension.End.Column; i++)
                {
                    string key = worksheet.Cells[1, i].Value == null ? "" : worksheet.Cells[1, i].Value.ToString();

                    if (!string.IsNullOrWhiteSpace(key)) //&& !columns.ContainsKey(key))
                    {
                        key = key.ToLower().Replace("-", "_");

                        //columns.Add(key, 0);

                        columns.Add(new ColumnDto()
                        {

                        });
                    }
                }

                // Get column lengths
                var len = 0;

                for (int i = worksheet.Dimension.Start.Column; i <= worksheet.Dimension.End.Column; i++)
                {
                    for (int j = worksheet.Dimension.Start.Row + 1; j <= worksheet.Dimension.End.Row; j++)
                    {

                    }
                }



                    System.Console.WriteLine(columns.ToString());
            }
        }
    }
}
