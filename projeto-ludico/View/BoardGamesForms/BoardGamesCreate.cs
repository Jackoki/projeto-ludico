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

        private void PreencherBoardGameModel()
        {
            boardgamesModel.description = txtDescricao.Text;
            boardgamesModel.min_players = parseIntOrDefault.ParseInt(txtQtdMin.Text, "número mínimo de jogadores");
            boardgamesModel.max_players = parseIntOrDefault.ParseInt(txtQtdMax.Text, "número máximo de jogadores");
            boardgamesModel.game_time = parseIntOrDefault.ParseInt(txtTempoJogo.Text, "tempo de jogo");
            boardgamesModel.year = parseIntOrDefault.ParseInt(txtAno.Text, "ano do jogo");

            boardgamesModel.names.Clear();
            BoardGamesNamesModel principalName = new BoardGamesNamesModel
            {
                name = txtNome.Text,
                is_principal = true
            };

            boardgamesModel.names.Add(principalName);

            foreach (var item in lbAlternateNames.Items)
            {
                BoardGamesNamesModel altName = new BoardGamesNamesModel
                {
                    name = item.ToString(),
                    is_principal = false
                };
                boardgamesModel.names.Add(altName);
            }

            boardgamesModel.codes.Clear();
            foreach (var item in lbCodigosBarras.Items)
            {
                BoardGamesBarCodesModel code = new BoardGamesBarCodesModel
                {
                    bar_code = item.ToString()
                };
                boardgamesModel.codes.Add(code);
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

        private void btnSalvar_Click(object sender, EventArgs e) {
            try {
                PreencherBoardGameModel();

                BoardGamesController boardgamesController = new BoardGamesController();
                boardgamesController.RegisterBoardGames(boardgamesModel);
            }

            catch (ArgumentException ex) {
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
    }
}
