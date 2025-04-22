namespace jcevallosS2.Views;

public partial class vPrincipal : ContentPage
{
    public vPrincipal()
    {
        InitializeComponent();
    }

    private async void btnNotas_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (pkEstudiante.SelectedItem == null)
            {
                await DisplayAlert("Error", "Seleccione un estudiante.", "OK");
                return;
            }

            String nombre = pkEstudiante.SelectedItem?.ToString() ?? "Sin seleccionar";
            Double seguimiento1 = Double.Parse(seguimiento1Entry.Text);
            Double examen1 = Double.Parse(examen1Entry.Text);
            Double seguimiento2 = Double.Parse(seguimiento2Entry.Text);
            Double examen2 = Double.Parse(examen2Entry.Text);

        
            if (seguimiento1 < 0 || seguimiento1 > 10 ||
                examen1 < 0 || examen1 > 10 ||
                seguimiento2 < 0 || seguimiento2 > 10 ||
                examen2 < 0 || examen2 > 10)
            {
                await DisplayAlert("Error", "Las notas deben estar entre 0 y 10", "OK");
                return;
            }

           
            Double parcial1 = (seguimiento1 * 0.3) + (examen1 * 0.2);
            Double parcial2 = (seguimiento2 * 0.3) + (examen2 * 0.2);
            Double notaFinal = parcial1 + parcial2;

            String estado;
            if (notaFinal >= 7)
                estado = "Aprobado";
            else if (notaFinal >= 5)
                estado = "Complementario";
            else
                estado = "Reprobado";

          
            await DisplayAlert("Resultados", 
                                $"Nombre: {nombre}\nFecha: {fecha.Date:d}\n" +
                                $"Nota Parcial 1: {parcial1:F2}" +
                                $"\nNota Parcial 2: {parcial2:F2}\n" +
                                $"Nota Final: {notaFinal:F2}\nEstado: {estado}", "OK");
        }
        catch (Exception)
        {
            await DisplayAlert("Error", "Por favor, complete todos los campos correctamente.", "OK");
        }
    }
}
