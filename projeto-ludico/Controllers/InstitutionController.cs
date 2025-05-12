using System.Windows.Forms;
using System;
using projeto_ludico.Utils;
using projeto_ludico.Models;

public class InstitutionController
{
    private readonly InstitutionRepository _institutionRepository;

    public InstitutionController()
    {
        _institutionRepository = new InstitutionRepository();
    }

    public void RegisterInstitution(InstitutionsModel institutionsModel)
    {
        try
        {
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
            MessageBox.Show("Erro na operação do banco de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        catch (Exception ex)
        {
            // Captura qualquer outra exceção que não tenha sido tratada acima
            MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
