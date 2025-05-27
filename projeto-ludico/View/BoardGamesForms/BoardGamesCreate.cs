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
    public partial class BoardGamesCreate : Form
    {
        BoardGamesModel boardgamesModel = new BoardGamesModel();
        ParseIntOrDefault parseIntOrDefault = new ParseIntOrDefault();

        //Ao renderizar a função, será carregado o ComboBox da função abaixo, atribuindo o Nome e Id como Valor
        public BoardGamesCreate() {
            InitializeComponent();
        }

        //Ao clicar no botão de criação, será montado as informações preenchidas ao participante, sendo esse passado no Controller, que por sua vez chama o Repository
        private void btnCreate_Click(object sender, EventArgs e) {
            boardgamesModel.name = textBoxName.Text;
            boardgamesModel.description = textBoxDescription.Text;
            boardgamesModel.min_players = parseIntOrDefault.ParseInt(textBoxMinPlayers.Text, "número mínimo de jogadores");
            boardgamesModel.max_players = parseIntOrDefault.ParseInt(textBoxMaxPlayers.Text, "número máximo de jogadores");
            boardgamesModel.game_time = parseIntOrDefault.ParseInt(textBoxGameTime.Text, "tempo de jogo");

            BoardGamesController boardgamesController = new BoardGamesController();
            boardgamesController.RegisterBoardGames(boardgamesModel);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("Tem certeza que deseja cancelar?", "Cancelar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                this.Close();
            }
        }
    }
}
