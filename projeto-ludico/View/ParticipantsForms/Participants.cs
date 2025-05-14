using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_ludico.Service;
using projeto_ludico.View.Institutions;
using projeto_ludico.View.InstitutionsForms;

namespace projeto_ludico.View.ParticipantsForms
{
    public partial class Participants : BaseForm
    {
        public Participants()
        {
            InitializeComponent();
            ConfigureInstitutionsViewer();
        }


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

            ConfigureDataViewer(dataViewer, "participants", desiredColumns, columnMappings, joinClause);

            OccultColumns(dataViewer, "id", "institution_id");
        }

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

        private void dataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            DataGridViewRow row = dataViewer.Rows[e.RowIndex];

            if (dataViewer.Columns[e.ColumnIndex].Name == "btnEdit") {
                //InstitutionsEdit institutionsEdit = new InstitutionsEdit();
                //institutionsEdit.EditInstitution(row);
                //institutionsEdit.Show();
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
