using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using System.Collections.Generic;
using System.Data;

public class DataTableStructure
{
    //Função responsável para chamar as outras funções de forma organizada
    public DataTable GetTableStructure(string tableName, string[] columns, Dictionary<string, string> columnMappings, string joinClause) {
        using (var connection = GetOpenConnection()) //Primeiramente nos conectamos no banco de dados
        {
            string query = BuildQuery(tableName, columns, joinClause); //Função chamada para montar a query
            DataTable tableData = ExecuteQuery(query, connection); //Função chamada para executar a query

            if (columnMappings != null) {
                RenameColumns(tableData, columnMappings); //Função chamada para realizar a nomeação das colunas no tableData a ser retornado
            }

            return tableData;
        }
    }

    //Realiza a conexão por meio da classe DatabaseConnection que criamos
    private SqliteConnection GetOpenConnection() {
        var connection = DatabaseConnection.GetConnection();

        if (connection.State != ConnectionState.Open) {
            connection.Open();
        }

        return connection;
    }

    //Realiza a montagem da query por meio do nome da tabela passada, colunas a serem retornadas e os joins
    private string BuildQuery(string tableName, string[] columns, string joinClause) {
        //Se não for passada nenhuma coluna em específico para o SELECT, será resgatado todas as colunas
        string selectedColumns = columns != null && columns.Length > 0 ? string.Join(", ", columns) : "*";

        return $"SELECT {selectedColumns} FROM {tableName} {joinClause};";
    }

    //Executa a query a partir da query montada acima
    private DataTable ExecuteQuery(string query, SqliteConnection connection) {
        DataTable tableData = new DataTable();

        using (var command = new SqliteCommand(query, connection))
        using (var reader = command.ExecuteReader())
        {
            tableData.Load(reader);
        }

        return tableData;
    }

    //Renomeia as colunas de forma vísual na tabela passada
    private void RenameColumns(DataTable table, Dictionary<string, string> columnMappings) {
        foreach (var mapping in columnMappings) {
            if (table.Columns.Contains(mapping.Key)) {
                table.Columns[mapping.Key].ColumnName = mapping.Value;
            }
        }
    }
}
