using System.Windows.Forms;
using System;
using projeto_ludico.Utils;
using projeto_ludico.Models;

//Controller é responsável para a realização de chamada de funções UI para caso ocorra erros/exceções
//Ocorre a chamada de função de inserção de dados no banco de dados a partir dos arquivos do tipo Repository
public class InstitutionController
{
    //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
    private readonly InstitutionRepository _institutionRepository;

    public InstitutionController()
    {
        _institutionRepository = new InstitutionRepository();
    }

    public void RegisterInstitution(InstitutionsModel institutionsModel)
    {
        try
        {
            //Chamada da classe ValidationUtil para validar os tipos de dados do institutionsModel
            if (!ValidationUtils.IsValidName(institutionsModel.Name)) {
                throw new ArgumentException("Nome não pode ser vazio.");
            }

            _institutionRepository.AddInstitution(institutionsModel.Name);
            MessageBox.Show("Registro bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        catch (ArgumentException ex)
        {
            // Captura a exceção de ArgumentException (campo de texto vazio) e exibe uma mensagem
            MessageBox.Show(ex.Message, "Falha na criação da instituição", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message,  "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        catch (Exception ex)
        {
            // Captura qualquer outra exceção que não tenha sido tratada acima
            MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void EditInstitution(InstitutionsModel institutionsModel)
    {
        try
        {
            // Valida o nome da instituição
            if (!ValidationUtils.IsValidName(institutionsModel.Name))
            {
                throw new ArgumentException("Nome não pode ser vazio.");
            }

            // Atualiza a instituição no banco de dados
            _institutionRepository.UpdateInstitution(institutionsModel);
            MessageBox.Show("Instituição editada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (ArgumentException ex)
        {
            // Exibe uma mensagem de erro caso o nome seja inválido
            MessageBox.Show(ex.Message, "Falha na edição da instituição", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (InvalidOperationException ex)
        {
            // Exibe um erro relacionado ao banco de dados
            MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            // Exibe um erro inesperado
            MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    public void DeleteInstitution(InstitutionsModel institutionsModel)
    {
        try {
            _institutionRepository.DeleteInstitution(institutionsModel.Id);
            MessageBox.Show("Instituição deletada!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}
