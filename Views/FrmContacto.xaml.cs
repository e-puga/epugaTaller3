namespace epugaTaller3.Views;

public partial class FrmContacto : ContentPage
{
	public FrmContacto()
	{
		InitializeComponent();
	}

    private void btnEnviar_Clicked(object sender, EventArgs e)
    {
		try
		{
			string tipoIdentificacion = pckTipoIdentificacion.Items[pckTipoIdentificacion.SelectedIndex].ToString();
			string identificacion = txtIdentificacion.Text;
			string nombres = txtNombres.Text;
			string apellidos = txtApellidos.Text;
			string fecha = Convert.ToString(dtFecha);
			string correo = txtCorreo.Text;
			int salario = Convert.ToInt32(txtSalario.Text);

			if (string.IsNullOrEmpty(tipoIdentificacion) ||
                string.IsNullOrEmpty(identificacion) ||
                string.IsNullOrEmpty(nombres) ||
                string.IsNullOrEmpty(apellidos) ||
                string.IsNullOrEmpty(fecha) ||
                string.IsNullOrEmpty(correo) ||
                salario == null) 
			{
				DisplayAlert("VALIDACION", "Por favor, completa todos los datos", "ACEPTAR");
			}

			double aporteIESS = salario * 0.0945;

			Navigation.PushAsync(new DetalleFrmContacto(tipoIdentificacion, identificacion, nombres, apellidos, fecha, correo, salario, aporteIESS));

		}
		catch (Exception)
		{

			throw;
		}
    }
}