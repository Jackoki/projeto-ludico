using projeto_ludico.Models;
using projeto_ludico.Repository;
using projeto_ludico.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_ludico.Controllers
{
    internal class RPGController
    {
        private readonly RPGRepository _rpgRepository;

        public RPGController()
        {
            _rpgRepository = new RPGRepository();
        }

        public void RegisterRPG(RPGModel rpgModel)
        {
            try
            {
                if (!ValidationUtils.IsValidName(rpgModel.name))
                    throw new ArgumentException("Nome não pode ser vazio.");

                _rpgRepository.AddRPG(rpgModel.name, rpgModel.description);
                MessageBox.Show("RPG registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Falha ao registrar RPG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro no banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EditRPG(RPGModel rpgModel)
        {
            try
            {
                if (!ValidationUtils.IsValidName(rpgModel.name))
                    throw new ArgumentException("Nome não pode ser vazio.");

                _rpgRepository.UpdateRPG(rpgModel);
                MessageBox.Show("RPG editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Falha ao editar RPG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro no banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteRPG(RPGModel rpgModel)
        {
            try
            {
                _rpgRepository.DeleteRPG(rpgModel.id);
                MessageBox.Show("RPG deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro no banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public RPGModel GetRpg(int id) {
            try {
                RPGModel rpgModel = new RPGModel();

                rpgModel = _rpgRepository.GetRpg(id);

                if (rpgModel == null) {
                    throw new KeyNotFoundException("RPG não encontrado.");
                }

                return rpgModel;
            }

            catch (KeyNotFoundException ex) {
                MessageBox.Show(ex.Message, "Falha na consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro ao carregar informações do RPG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            catch (Exception ex) {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
