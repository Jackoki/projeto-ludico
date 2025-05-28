using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            textBoxDescription.Text = boardgamesModel.description;
            textBoxMinPlayers.Text = boardgamesModel.min_players.ToString();
            textBoxMaxPlayers.Text = boardgamesModel.max_players.ToString();
            textBoxGameTime.Text = boardgamesModel.game_time.ToString();
            textBoxGameTime.Text = boardgamesModel.year.ToString();
        }

        private void loadComboBox() {
            ComboBoxLoader comboBoxLoader = new ComboBoxLoader();
        }

        //Ao clicar no botão de editar, será chamada a função de loadNewValues(), que esse cria um novo ParticipantModel
        //Esse ParticipantModel pega o Id anterior e recebe as informações dos formulários atuais
        private void btnCreate_Click(object sender, EventArgs e) {
            boardgamesController.EditBoardGames(loadNewValues());
        }

        private BoardGamesModel loadNewValues() {
            BoardGamesModel newBoardGamesModel = new BoardGamesModel();
            newBoardGamesModel.id = boardgamesModel.id;
            newBoardGamesModel.description = textBoxDescription.Text;
            newBoardGamesModel.min_players = parseIntOrDefault.ParseInt(textBoxMinPlayers.Text, "número mínimo de jogadores");
            newBoardGamesModel.max_players = parseIntOrDefault.ParseInt(textBoxMaxPlayers.Text, "número máximo de jogadores");
            newBoardGamesModel.game_time = parseIntOrDefault.ParseInt(textBoxGameTime.Text, "tempo de jogo");
            //newBoardGamesModel.year = parseIntOrDefault.ParseInt(textBoxMinPlayers.Text, "ano do jogo");

            return newBoardGamesModel;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("Tem certeza que deseja cancelar?", "Cancelar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
