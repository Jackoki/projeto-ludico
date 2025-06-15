using projeto_ludico.View.EscapeRoomsForms;
using projeto_ludico.View.ListForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_ludico.View.RPGForms
{
    public partial class RPGManager : BaseForm
    {
        public int id_role_play;

        public RPGManager(DataGridViewRow row) {
            if (row.Cells["id"] != null && row.Cells["id"].Value != null) {
                int.TryParse(row.Cells["id"].Value.ToString(), out id_role_play);
            }

            InitializeComponent();
            ConfigureRPGViewer();
        }

        private void ConfigureRPGViewer() {
            string[] desiredColumns = { "name", "id" };
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome da Campanha" },
            };

            ConfigureDataViewerWithoutButtons(dataViewer, "role_play_games_campaigns", desiredColumns, columnMappings, null);

            // Verifica se o botão delete já foi adicionado
            if (!dataViewer.Columns.Contains("btnDelete")) {
                var deleteButton = CreateDeleteButton();
                dataViewer.Columns.Add(deleteButton);
            }

            // Verifica se o botão delete já foi adicionado
            if (!dataViewer.Columns.Contains("btnManagement")) {
                var managementButton = CreateManagementButton();
                dataViewer.Columns.Add(managementButton);
            }

            OccultColumns(dataViewer, "id");
        }


        private void PerformSearch(string searchString) {
            string[] desiredColumns = { "name", "id" };
            string[] searchableColumns = { "name" };

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome da Campanha" },
            };

            ConfigureSearchDataViewer(dataViewer, searchString, "role_play_games_campaigns", desiredColumns, columnMappings, searchableColumns, null);
            OccultColumns(dataViewer, "id");
        }

        private void DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataViewer.Rows[e.RowIndex];

            if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete") {
                RPGCampaignDelete rpgCampaignDelete = new RPGCampaignDelete();
                rpgCampaignDelete.DeleteCampaignRPG(row);
            }

            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnManagement") {
                RPGParticipants rpgParticipants = new RPGParticipants(row);
                rpgParticipants.Show();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            RPGCampaignCreate rpgCampaignCreate = new RPGCampaignCreate(id_role_play);
            rpgCampaignCreate.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            string searchString = boxSearch.Text.Trim();
            PerformSearch(searchString);
        }
    }
}
