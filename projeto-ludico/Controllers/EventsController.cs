using projeto_ludico.Models;
using projeto_ludico.Repository;
using projeto_ludico.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace projeto_ludico.Controllers
{
    public class EventsController
    {
        //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
        private EventsRepository _repository;

        public EventsController()
        {
            _repository = new EventsRepository();
        }

        public void CreateEvent(EventsModel eventsModel)
        {
            try
            {
                //Chamada da classe ValidationUtil para validar os tipos de dados
                if (!ValidationUtils.IsValidName(eventsModel.name))
                {
                    throw new ArgumentException("Nome não pode ser vazio.");
                }


                _repository.AddEvent(eventsModel);
                MessageBox.Show("Registro bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            catch (ArgumentException ex)
            {
                // Captura a exceção de ArgumentException (campo de texto vazio) e exibe uma mensagem
                MessageBox.Show(ex.Message, "Falha na criação do evento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void UpdateEvent(EventsModel eventsModel)
        {
            try
            {
                //Chamada da classe ValidationUtil para validar os tipos de dados
                if (!ValidationUtils.IsValidName(eventsModel.name))
                {
                    throw new ArgumentException("Nome não pode ser vazio.");
                }


                _repository.UpdateEvent(eventsModel);
                MessageBox.Show("Evento alterado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            catch (ArgumentException ex)
            {
                // Captura a exceção de ArgumentException (campo de texto vazio) e exibe uma mensagem
                MessageBox.Show(ex.Message, "Falha na edição do evento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void DeleteEvent(int id)
        {
            try
            {
                _repository.DeleteEvent(id);
                MessageBox.Show("Evento deletado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public EventsModel GetEventsById(int id)
        {
            try
            {
                EventsModel eventsModel = new EventsModel();

                eventsModel = _repository.GetEventsById(id);

                if (eventsModel == null)
                {
                    throw new KeyNotFoundException("Evento não encontrado.");
                }

                return eventsModel;
            }

            catch (KeyNotFoundException ex)
            {
                // Se não encontrar o participante
                MessageBox.Show(ex.Message, "Falha na consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            catch (InvalidOperationException ex)
            {
                // Erro ao realizar a operação, como problemas com o banco de dados
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            catch (Exception ex)
            {
                // Qualquer outro erro inesperado
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
} 
