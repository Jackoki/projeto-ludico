using System.Windows.Forms;
using System;
using projeto_ludico.Utils;
using projeto_ludico.Models;

public class PlacesController
{
    //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
    private readonly PlacesRepository _placesRepository;

    public PlacesController()
    {
        _placesRepository = new PlacesRepository();
    }

    public void RegisterPlace(PlacesModel placesModel)
    {
        try
        {
            //Chamada da classe ValidationUtil para validar os tipos de dados do placesModel
            if (!ValidationUtils.IsValidName(placesModel.name))
                throw new ArgumentException("Nome não pode ser vazio.");

            _placesRepository.AddPlace(placesModel.name);
            MessageBox.Show("Local registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Falha ao registrar local", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Erro no banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
             // Captura qualquer outra exceção que não tenha sido tratada acima
            MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void EditPlace(PlacesModel placesModel)
    {
        try
        {
            // Valida o nome do local
            if (!ValidationUtils.IsValidName(placesModel.name))
                throw new ArgumentException("Nome não pode ser vazio.");

            // Atualiza o local no banco de dados
            _placesRepository.UpdatePlace(placesModel);
            MessageBox.Show("Local editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Falha ao editar local", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Erro no banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            // Captura qualquer outra exceção que não tenha sido tratada acima
            MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void DeletePlace(PlacesModel placesModel)
    {
        try
        {
            _placesRepository.DeletePlace(placesModel.id);
            MessageBox.Show("Local deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Erro no banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            // Captura qualquer outra exceção que não tenha sido tratada acima
            MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
