using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Utils;

namespace projeto_ludico.Controllers
{
    internal class ResearchTable
    {
        public DataTable SearchWithFilters(string tableName, List<SearchFilter> filters, string[] columns = null, Dictionary<string, string> columnMappings = null)
        {
            SqliteConnection _connection = DatabaseConnection.GetConnection();

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            string selectedColumns = columns != null && columns.Length > 0 ? string.Join(", ", columns) : "*";

            // Construção dinâmica da cláusula WHERE com base nos filtros
            var filterClauses = new List<string>();
            foreach (var filter in filters)
            {
                string filterExpression = BuildFilterExpression(filter);
                filterClauses.Add(filterExpression);
            }

            string whereClause = string.Join(" AND ", filterClauses);

            string query = $"SELECT {selectedColumns} FROM {tableName} WHERE {whereClause};";

            DataTable resultTable = new DataTable();

            using (var command = new SqliteCommand(query, _connection))
            {
                // Adicionar parâmetros dinamicamente para cada filtro
                foreach (var filter in filters)
                {
                    command.Parameters.AddWithValue($"@{filter.ColumnName}", $"%{filter.SearchTerm}%");
                }

                using (var reader = command.ExecuteReader())
                {
                    resultTable.Load(reader);
                }
            }

            if (columnMappings != null)
            {
                var dataTableStructure = new DataTableStructure();
                dataTableStructure.RenameColumns(resultTable, columnMappings);
            }

            return resultTable;
        }

        private string BuildFilterExpression(SearchFilter filter)
        {
            string operatorSql;

            // Substituindo o switch expression com um switch tradicional
            switch (filter.Operator)
            {
                case SearchOperator.Equals:
                    operatorSql = "= @";
                    break;
                case SearchOperator.Contains:
                    operatorSql = "LIKE @";
                    break;
                case SearchOperator.StartsWith:
                    operatorSql = "LIKE @";
                    break;
                case SearchOperator.EndsWith:
                    operatorSql = "LIKE @";
                    break;
                default:
                    operatorSql = "LIKE @";
                    break;
            }

            return $"{filter.ColumnName} {operatorSql}{filter.ColumnName}";
        }


    }
}
