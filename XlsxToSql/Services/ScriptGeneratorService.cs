using System;
using System.Collections.Generic;
using System.Linq;
using XlsxToSql.Models;
using XlsxToSql.Models.Extensions;

namespace XlsxToSql.Services
{
    public class ScriptGeneratorService
    {
        public string GenerateScript(string database, List<TableDto> tables)
        {
            var script = "";

            if (!string.IsNullOrWhiteSpace(database))
            {
                script += string.Format("USE [{0}]{1}", database, Environment.NewLine);
                script += string.Format("GO{0}", Environment.NewLine);
                script += Environment.NewLine;
            }

            foreach (var table in tables)
            {
                script += CreateTableScript(table) + Environment.NewLine;
            }

            return script;
        }

        private string CreateTableScript(TableDto table)
        {
            if (string.IsNullOrWhiteSpace(table?.name)) throw new Exception("Table name not declared");

            var script = table.GenerateHeaderSQL();

            var colCount = 1;

            foreach (var column in table.Columns)
            {
                script += column.GenerateSQL(colCount++ == table.Columns.Count() ? true : false);
            }

            script += table.GenerateFooterSQL();

            return script;
        }
    }
}
