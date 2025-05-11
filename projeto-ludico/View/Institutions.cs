using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using projeto_ludico.Controllers;

namespace projeto_ludico.View
{
    public partial class Institutions : BaseForm
    {
        public Institutions()
        {
            InitializeComponent();
            ConfigureInstitutionsViewer();
        }

        //Ao inicializar o formulário, será chamada essa função
        private void ConfigureInstitutionsViewer()
        {
            //Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite e um dicionário dos nomes a serem mostradas na coluna da tabela 
            string[] desiredColumns = { "name" };
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" }
            };

            //A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            ConfigureDataViewer(dataViewer, "institutions", desiredColumns, columnMappings);
        }

        private void PerformSearch(string searchString)
        {
            //Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite e um dicionário dos nomes a serem mostradas na coluna da tabela 
            string[] desiredColumns = { "name" };
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" }
            };

            //A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            ConfigureSearchDataViewer(dataViewer, searchString, "institutions", desiredColumns, columnMappings);
        }

        //Quando o usuário clicar no botão de pesquisa, será chamada a função de busca
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = boxSearch.Text.Trim();
            PerformSearch(searchString);
        }

    }
}
