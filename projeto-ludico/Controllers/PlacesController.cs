using System.Windows.Forms;
using System;
using projeto_ludico.Utils;
using projeto_ludico.Models;

public class PlacesController
{
    private readonly PlacesRepository _placesRepository;

    public PlacesController()
    {
        _placesRepository = new PlacesRepository();
    }

    public void RegisterPlace(PlacesModel placesModel)
    {
        try
        {
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
            MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void EditPlace(PlacesModel placesModel)
    {
        try
        {
            if (!ValidationUtils.IsValidName(placesModel.name))
                throw new ArgumentException("Nome não pode ser vazio.");

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
            MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
