using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;

namespace projeto_ludico.Utils
{
    internal class DataTableStructure
    {
        public static DataTable getTableStructure(string tableName, string[] columns = null, Dictionary<string, string> columnMappings = null)
        {
            SqliteConnection _connection = DatabaseConnection.GetConnection();

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            string selectedColumns = columns != null && columns.Length > 0 ? string.Join(", ", columns): "*";

            string query = $"SELECT {selectedColumns} FROM {tableName};";

            DataTable tableData = new DataTable();

            using (var command = new SqliteCommand(query, _connection))
            using (var reader = command.ExecuteReader())
            {
                tableData.Load(reader);
            }

            if (columnMappings != null)
            {
                RenameColumns(tableData, columnMappings);
            }

            return tableData;
        }

        private static void RenameColumns(DataTable table, Dictionary<string, string> columnMappings)
        {
            foreach (var mapping in columnMappings)
            {
                if (table.Columns.Contains(mapping.Key))
                {
                    table.Columns[mapping.Key].ColumnName = mapping.Value;
                }
            }
        }

    }
}
