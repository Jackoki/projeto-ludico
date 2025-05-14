using System;
using System.Data;
using System.Windows.Forms;
using projeto_ludico.Database;

namespace projeto_ludico.Utils
{
    //Função responsável para carregar as informações de uma tabela do banco de dados em um ComboBox
    internal class ComboBoxLoader
    {
        public void LoadComboBox(ComboBox comboBox, string tableName, string valueColumn, string displayColumn) {
            try {
                // Obtem os dados do banco de dados
                DataTable dataTable = GetDataFromDatabase(tableName, valueColumn, displayColumn);

                // Configura o ComboBox com os dados obtidos
                ConfigureComboBox(comboBox, dataTable, displayColumn, valueColumn);
            }
            
            catch (Exception ex) {
                MessageBox.Show($"Erro ao carregar: {ex.Message}");
            }
        }

        private DataTable GetDataFromDatabase(string tableName, string valueColumn, string displayColumn) {
            //Realiza a consulta do banco de dados baseado no resgate do valor (Id), Display (Nome) e o nome da Tablela
            string query = $"SELECT {valueColumn}, {displayColumn} FROM {tableName}";
            DataTable dataTable = new DataTable();

            using (var connection = DatabaseConnection.GetConnection()) {
                using (var command = connection.CreateCommand()) {
                    command.CommandText = query;

                    using (var reader = command.ExecuteReader()) {
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }

        //Realiza a nomeação do ComboBox
        //Um ComboBox precisa tem 2 propriedades guardadas, o DisplayMember, que é o texto a ser mostrado no ComboBox
        //Cada DisplayMember tem um ValueMember em conjunto, ou seja, ao selecionar um DisplayMember, estamos selecionado também o ValueMember
        //Esse ValueMember é utilizado para resgatar o valor do ID selecionado
        private void ConfigureComboBox(ComboBox comboBox, DataTable dataTable, string displayColumn, string valueColumn) {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayColumn;
            comboBox.ValueMember = valueColumn;
        }

    }
}
