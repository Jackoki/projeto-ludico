using projeto_ludico.Models;
using projeto_ludico.Repository;
using projeto_ludico.Utils;
using System;
using System.Windows.Forms;

namespace projeto_ludico.Controllers
{
    internal class ListController
    {
        //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
        private readonly ListRepository _repository;

        public ListController()
        {
            _repository = new ListRepository();
        }

        public void CreateList(ListModel listModel)
        {
            try
            {
                //Chamada da classe ValidationUtil para validar os tipos de dados do listModel
                if (!ValidationUtils.IsValidName(listModel.name))
                    throw new ArgumentException("O nome da lista é inválido.");

                _repository.CreateList(listModel);

                MessageBox.Show("Lista criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                // Exibe um erro inesperado
                MessageBox.Show("Erro ao criar lista: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EditList(ListModel listModel)
        {
            try
            {
                // Valida o nome da lista
                if (!ValidationUtils.IsValidName(listModel.name))
                    throw new ArgumentException("O nome da lista é inválido.");

                _repository.UpdateList(listModel);
                MessageBox.Show("Nome da lista editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Falha ao editar lista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro no banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Exibe um erro inesperado
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteList(int id)
        {
            try
            {
                _repository.DeleteList(id);
                MessageBox.Show("Lista deletada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                // Exibe um erro inesperado
                MessageBox.Show("Erro ao deletar lista: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
