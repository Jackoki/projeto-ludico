using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;

namespace projeto_ludico.Utils
{
    internal class DataTableSearchStructure
    {
        //Função com responsabilidade de retornar a estrutura padrão do DataView, nele se recebe 4 parâmetros:
        //O nome da tabela do banco de dados, a informação a ser buscada, as colunas a serem retornadas da tabela e por fim, os nomes das colunas a serem mostradas no formulário
        public DataTable getTableSearchStructure(string tableName, string searchInfo, string[] columns, Dictionary<string, string> columnMappings, string[] searchableColumns)
        {
            // Montar as colunas a serem selecionadas
            string selectedColumns = columns != null && columns.Length > 0 ? string.Join(", ", columns) : "*";

            // Construir a consulta com filtro, se necessário
            string query = $"SELECT {selectedColumns} FROM {tableName}";

            if (!string.IsNullOrEmpty(searchInfo) && searchableColumns != null && searchableColumns.Length > 0)
            {
                query += " WHERE ";
                List<string> conditions = new List<string>();
                foreach (string column in searchableColumns) // Use searchableColumns em vez de columns
                {
                    conditions.Add($"{column} LIKE @searchInfo");
                }
                query += string.Join(" OR ", conditions);
            }

            query += ";";

            // Realizar a consulta
            DataTable tableData = new DataTable();

            using (var _connection = DatabaseConnection.GetConnection())
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                using (var command = new SqliteCommand(query, _connection))
                {
                    // Adicionar o parâmetro de busca
                    if (!string.IsNullOrEmpty(searchInfo))
                    {
                        command.Parameters.AddWithValue("@searchInfo", $"%{searchInfo}%");
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        tableData.Load(reader);
                    }
                }
            }

            // Renomear colunas, se necessário
            if (columnMappings != null)
            {
                RenameColumns(tableData, columnMappings);
            }

            return tableData;
        }



        public void RenameColumns(DataTable tableData, Dictionary<string, string> columnMappings)
        {
            //Pra cada coluna passada, será retornada a estrutura dos nomes das colunas para a tabela
            foreach (var mapping in columnMappings)
            {
                if (tableData.Columns.Contains(mapping.Key))
                {
                    tableData.Columns[mapping.Key].ColumnName = mapping.Value;
                }
            }
        }

    }
}
