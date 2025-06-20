﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using projeto_ludico.Service;

namespace projeto_ludico.View.ParticipantsForms
{
    public partial class Participants : BaseForm
    {
        public Participants()
        {
            InitializeComponent();
            ConfigureInstitutionsViewer();
        }

        //Realiza a chamada das informações do SQL, passamos as colunas que queremos e as renomeamos no da DataGrid
        private void ConfigureInstitutionsViewer()
        {
            string[] desiredColumns = { 
                "participants.id", "participants.name", "participants.email", "participants.cpf", "participants.code", 
                "institutions.name AS institution_name", "institutions.id AS institution_id" 
            };

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" },
                { "email", "Email" },
                { "cpf", "CPF" },
                { "code", "Código" },
                { "institution_name", "Instituição" }
            };

            string joinClause = "LEFT JOIN institutions ON (participants.id_institution = institutions.id)";

            //Passamos o false para dizer que não iremos adicionar o botão "Gerenciar" na linha
            ConfigureDataViewer(dataViewer, "participants", desiredColumns, columnMappings, joinClause, false);

            OccultColumns(dataViewer, "id", "institution_id");
        }

        //Função responsável para realizar a atualização de pesquisa quando o usuário realizar a pesquisa no formulário
        private void PerformSearch(string searchString)
        {
            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] desiredColumns = {
                "participants.id", "participants.name", "participants.email", "participants.cpf", "participants.code",
                "institutions.name AS institution_name", "institutions.id AS institution_id"
            };

            string[] searchableColumns = { "participants.name", "participants.code", "participants.cpf" };  // Colunas usadas na busca

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" },
                { "email", "Email" },
                { "cpf", "CPF" },
                { "code", "Código" },
                { "institution_name", "Instituição" }
            };

            string joinClause = "LEFT JOIN institutions ON (participants.id_institution = institutions.id)";

            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            //Passamos o null no final pois não temos nenhum JOIN a ser retornado na tabela
            ConfigureSearchDataViewer(dataViewer, searchString, "participants", desiredColumns, columnMappings, searchableColumns, joinClause);

            // Oculta as colunas especificadas
            OccultColumns(dataViewer, "id", "institution_id");
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            string searchString = boxSearch.Text.Trim();
            PerformSearch(searchString);
        }

        //Criação dos botões de editar e deletar em cada linha de forma automática
        private void dataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataViewer.Rows[e.RowIndex];

            if (dataViewer.Columns[e.ColumnIndex].Name == "btnEdit") {
                ParticipantsEdit participantsEdit = new ParticipantsEdit(row);
                participantsEdit.Show();
            }

            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete") {
                ParticipantsDelete participantsDelete = new ParticipantsDelete();
                participantsDelete.DeleteParticipant(row);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ParticipantsCreate participantsCreate = new ParticipantsCreate();
            participantsCreate.Show();
        }
    }
}
