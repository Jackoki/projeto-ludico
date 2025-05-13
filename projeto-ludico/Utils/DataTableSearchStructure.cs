using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using System.Collections.Generic;
using System.Data;

public class DataTableSearchStructure
{
    public DataTable GetTableSearchStructure(string tableName, string searchInfo, string[] columns, Dictionary<string, string> columnMappings, string[] searchableColumns, string joinClause) {
        using (var connection = GetOpenConnection()) // Realiza a conexão no banco de dados
        {
            string query = BuildQuery(tableName, columns, joinClause, searchInfo, searchableColumns); // Chamada da função de montagem da query
            DataTable tableData = ExecuteQuery(query, connection, searchInfo); // Chamada da função de execução da query

            if (columnMappings != null)
            {
                RenameColumns(tableData, columnMappings); // Renomeação das colunas da tabela passada
            }

            return tableData;
        }
    }

    // Método para abrir uma conexão com o banco
    private SqliteConnection GetOpenConnection() {
        var connection = DatabaseConnection.GetConnection();

        if (connection.State != ConnectionState.Open) {
            connection.Open();
        }

        return connection;
    }

    // Monta a query SQL com suporte a filtros de busca
    private string BuildQuery(string tableName, string[] columns, string joinClause, string searchInfo, string[] searchableColumns) {
        // Definir as colunas a serem retornadas
        string selectedColumns = columns != null && columns.Length > 0 ? string.Join(", ", columns) : "*"; // Se nenhuma coluna for repassada, pegará todas elas

        // Constroi a base da query a partir dos parâmetros passados
        string query = $"SELECT {selectedColumns} FROM {tableName} {joinClause}";

        // Adiciona filtros de busca, se necessário do Where para a query final
        if (!string.IsNullOrEmpty(searchInfo) && searchableColumns != null && searchableColumns.Length > 0) {
            query += " WHERE " + BuildSearchConditions(searchableColumns);
        }

        return query + ";";
    }

    // Constrói as condições de busca para a cláusula WHERE pelos parâmetros de colunas a serem buscadas
    private string BuildSearchConditions(string[] searchableColumns) {
        List<string> conditions = new List<string>();

        foreach (string column in searchableColumns) {
            conditions.Add($"{column} LIKE @searchInfo");
        }

        return string.Join(" OR ", conditions);
    }

    // Executa a query e retorna os resultados em um DataTable
    private DataTable ExecuteQuery(string query, SqliteConnection connection, string searchInfo) {
        DataTable tableData = new DataTable();

        using (var command = new SqliteCommand(query, connection)) {
            if (!string.IsNullOrEmpty(searchInfo)) {
                command.Parameters.AddWithValue("@searchInfo", $"%{searchInfo}%");
            }

            using (var reader = command.ExecuteReader()) {
                tableData.Load(reader);
            }
        }

        return tableData;
    }

    // Renomeia as colunas da tabela com base no mapeamento fornecido
    private void RenameColumns(DataTable table, Dictionary<string, string> columnMappings) {
        foreach (var mapping in columnMappings) {
            if (table.Columns.Contains(mapping.Key)) {
                table.Columns[mapping.Key].ColumnName = mapping.Value;
            }
        }
    }
}
