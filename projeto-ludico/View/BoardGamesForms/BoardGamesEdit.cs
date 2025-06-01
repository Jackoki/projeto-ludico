using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.Utils;
using projeto_ludico.View.BoardGamesForms;

namespace projeto_ludico.View.BoardGamesForms
{
    public partial class BoardGamesEdit : Form
    {
        BoardGamesModel boardgamesModel = new BoardGamesModel();
        BoardGamesController boardgamesController = new BoardGamesController();
        ParseIntOrDefault parseIntOrDefault = new ParseIntOrDefault();

        //Ao renderizar esse formulário, passamos o ID do participante pela identificação do row
        public BoardGamesEdit(DataGridViewRow row) {
            InitializeComponent();
            loadComboBox();
            loadBoardGames(row);
        }

        //Atribuimos os campos de preenchimento do formulário com as informações do participante identificado pelo Id passado pelo Row
        private void loadBoardGames(DataGridViewRow row) {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                boardgamesModel.id = id;
            }

            boardgamesModel = boardgamesController.GetBoardGamesById(boardgamesModel.id);

            txtDescricao.Text = boardgamesModel.description;
            txtQtdMin.Text = boardgamesModel.min_players.ToString();
            txtQtdMax.Text = boardgamesModel.max_players.ToString();
            txtTempoJogo.Text = boardgamesModel.game_time.ToString();
            txtAno.Text = boardgamesModel.year.ToString();
            

            foreach (var name in boardgamesModel.names)
            {
                if (!name.is_principal)
                {
                    lbAlternateNames.Items.Add(name.name);
                }
            }

            var principalName = boardgamesModel.names.FirstOrDefault(n => n.is_principal);
            if (principalName != null)
            {
                txtNome.Text = principalName.name;
            }

            foreach (var code in boardgamesModel.codes)
            {
                lbCodigosBarras.Items.Add(code.bar_code);
            }
        }

        private void loadComboBox() {
            ComboBoxLoader comboBoxLoader = new ComboBoxLoader();
        }

        private BoardGamesModel loadNewValues() {
            BoardGamesModel newBoardGamesModel = new BoardGamesModel();

            newBoardGamesModel.id = boardgamesModel.id;
            newBoardGamesModel.description = txtDescricao.Text;
            newBoardGamesModel.min_players = parseIntOrDefault.ParseInt(txtQtdMin.Text, "número mínimo de jogadores");
            newBoardGamesModel.max_players = parseIntOrDefault.ParseInt(txtQtdMax.Text, "número máximo de jogadores");
            newBoardGamesModel.game_time = parseIntOrDefault.ParseInt(txtTempoJogo.Text, "tempo de jogo");
            newBoardGamesModel.year = parseIntOrDefault.ParseInt(txtAno.Text, "ano do jogo");

            newBoardGamesModel.names.Clear();
            BoardGamesNamesModel principalName = new BoardGamesNamesModel
            {
                name = txtNome.Text,
                is_principal = true,
                id_board_game = newBoardGamesModel.id
            };
            newBoardGamesModel.names.Add(principalName);

            foreach (var item in lbAlternateNames.Items)
            {
                BoardGamesNamesModel altName = new BoardGamesNamesModel
                {
                    name = item.ToString(),
                    is_principal = false,
                    id_board_game = newBoardGamesModel.id
                };
                newBoardGamesModel.names.Add(altName);
            }

            newBoardGamesModel.codes.Clear();
            foreach (var item in lbCodigosBarras.Items)
            {
                BoardGamesBarCodesModel code = new BoardGamesBarCodesModel
                {
                    bar_code = item.ToString(),
                    id_board_game = newBoardGamesModel.id
                };
                newBoardGamesModel.codes.Add(code);
            }

            return newBoardGamesModel;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("Tem certeza que deseja cancelar?", "Cancelar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                BoardGamesModel updatedBoardGame = loadNewValues();
                boardgamesController.EditBoardGames(updatedBoardGame);
            }

            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddNome_Click(object sender, EventArgs e)
        {
            if (txtNomeAlternativo.Text != "")
            {
                lbAlternateNames.Items.Add(txtNomeAlternativo.Text);
            }
        }

        private void btnRemoveName_Click(object sender, EventArgs e)
        {
            if (lbAlternateNames.SelectedIndex != -1)
            {
                lbAlternateNames.Items.RemoveAt(lbAlternateNames.SelectedIndex);
            }
        }

        private void btnAddBarCode_Click(object sender, EventArgs e)
        {
            if (txtCodigoBarras.Text != "")
            {
                lbCodigosBarras.Items.Add(txtCodigoBarras.Text);
            }
        }

        private void btnRemoveBarCode_Click(object sender, EventArgs e)
        {
            if (lbCodigosBarras.SelectedIndex != -1)
            {
                lbCodigosBarras.Items.RemoveAt(lbCodigosBarras.SelectedIndex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja cancelar?", "Cancelar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
