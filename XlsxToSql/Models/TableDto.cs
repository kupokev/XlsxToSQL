using System.Collections.Generic;

namespace XlsxToSql.Models
{
    public class TableDto
    {
        public TableDto()
        {
            Columns = new List<ColumnDto>();
        }

        public string name { get; set; }

        public string schema { get; set; }

        public int recordCount { get; set; }

        public object[,] Rows { get; set; }

        public string Schema
        {
            get
            {
                return string.IsNullOrWhiteSpace(schema) ? "dbo" : schema.Trim();
            }
        }

        public List<ColumnDto> Columns { get; set; }
    }
}
