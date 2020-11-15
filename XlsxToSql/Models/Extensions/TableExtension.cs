using System;

namespace XlsxToSql.Models.Extensions
{
    public static class TableExtension
    {
        public static string GenerateFooterSQL(this TableDto table)
        {
            return string.Format(@");{0}", Environment.NewLine);
        }

        public static string GenerateHeaderSQL(this TableDto table)
        {
            return string.Format(
                "CREATE TABLE [{0}].[{1}] ({2}",
                table.Schema
                , table.name
                , Environment.NewLine
                );
        }
    }
}
