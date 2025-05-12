using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;

namespace projeto_ludico.Utils
{
    internal class DataTableStructure
    {
        //Função com responsabilidade de retornar a estrutura padrão do DataView, nele se recebe 3 parâmetros:
        //O nome da tabela do banco de dados, as colunas a serem retornadas da tabela e por fim, os nomes das colunas a serem mostradas no formulário
        public DataTable getTableStructure(string tableName, string[] columns, Dictionary<string, string> columnMappings)
        {
            SqliteConnection _connection = DatabaseConnection.GetConnection();

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            //Realiza uma string para a montagem das colunas a serem selecionadas da tabela
            string selectedColumns = columns != null && columns.Length > 0 ? string.Join(", ", columns): "*";

            string query = $"SELECT {selectedColumns} FROM {tableName};";

            //Realiza a consulta para o tableData
            DataTable tableData = new DataTable();

            using (var command = new SqliteCommand(query, _connection))
            using (var reader = command.ExecuteReader())
            {
                tableData.Load(reader);
            }


            //Se não for passada os nomes dass colunas, não irá realizar a função de renomear as colunas do DataView
            if (columnMappings != null)
            {
                RenameColumns(tableData, columnMappings);
            }

            //Realiza o fechamento do banco de dados para permitir outras operações
            _connection.Dispose();

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
