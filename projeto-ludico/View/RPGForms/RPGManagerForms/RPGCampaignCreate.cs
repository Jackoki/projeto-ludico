using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.Utils;
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
    public partial class RPGCampaignCreate : Form
    {
        public int id_role_play;

        public RPGCampaignCreate(int id_role_play) {
            this.id_role_play = id_role_play;
            InitializeComponent();
            loadComboBox();
        }

        private void loadComboBox() {
            ComboBoxLoader comboBoxLoader = new ComboBoxLoader();
            comboBoxLoader.LoadComboBox(comboBoxEvents, "events", "id", "name");
            comboBoxEvents.SelectedIndex = -1;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RPGCampaignModel rpgCampaignModel = new RPGCampaignModel();
            rpgCampaignModel.name = txtBoxName.Text.Trim();
            rpgCampaignModel.description = txtDescricao.Text.Trim();
            rpgCampaignModel.id_role_play_game = id_role_play;
            rpgCampaignModel.id_event = comboBoxEvents.SelectedValue != null ? Convert.ToInt32(comboBoxEvents.SelectedValue) : 0;

            RPGCampaignController rpgCampaignController = new RPGCampaignController();
            rpgCampaignController.RegisterCampaignRPG(rpgCampaignModel);
        }
    }
}
