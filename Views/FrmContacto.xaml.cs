namespace epugaTaller3.Views;

public partial class FrmContacto : ContentPage
{
	public FrmContacto()
	{
		InitializeComponent();
	}

    private async  void btnEnviar_Clicked(object sender, EventArgs e)
    {
		try
		{
            string tipoIdentificacion = pckTipoIdentificacion.SelectedIndex == -1 ? "" : pckTipoIdentificacion.Items[pckTipoIdentificacion.SelectedIndex].ToString();
            string identificacion = txtIdentificacion.Text?.Trim() ?? "";
            string nombres = txtNombres.Text?.Trim() ?? "" ;
            string apellidos = txtApellidos.Text?.Trim() ?? "";
            string fecha = dtFecha.ToString().Trim() ?? "";
            string correo = txtCorreo.Text?.Trim() ?? "";
            int salario = Convert.ToInt32(txtSalario.Text);

            bool datosValidos = await verificarDatosRequeridos(tipoIdentificacion, identificacion, nombres, apellidos, fecha, correo, salario);

            if (datosValidos)
            {
                double aporteIESS = salario * 0.0945;

			    Navigation.PushAsync(new DetalleFrmContacto(tipoIdentificacion, identificacion, nombres, apellidos, fecha, correo, salario, aporteIESS));
            }
		}
		catch (Exception)
		{

			throw;
		}
    }

	public async Task<bool> verificarDatosRequeridos(string tipoIdentificacion, string identificacion, string nombres, string apellidos, string fecha, string correo, int salario)
	{
        string mensaje = "";

        if (string.IsNullOrWhiteSpace(tipoIdentificacion))
            mensaje += "El tipo de identificaci�n no puede estar vac�o.\n";

        if (string.IsNullOrWhiteSpace(identificacion))
            mensaje += "La identificaci�n no puede estar vac�a.\n";

        if (string.IsNullOrWhiteSpace(nombres))
            mensaje += "El nombre no puede estar vac�o.\n";

        if (string.IsNullOrWhiteSpace(apellidos))
            mensaje += "El apellido no puede estar vac�o.\n";

        if (string.IsNullOrWhiteSpace(fecha))
            mensaje += "La fecha no puede estar vac�a.\n";

        if (string.IsNullOrWhiteSpace(correo))
            mensaje += "El correo no puede estar vac�o.\n";

        // Validaci�n seg�n tipo de identificaci�n
        if (tipoIdentificacion == "CI")
        {
            if (identificacion.Length != 10 || !identificacion.All(char.IsDigit))
                mensaje += "La c�dula debe tener exactamente 10 d�gitos num�ricos.\n";
        }

        if (tipoIdentificacion == "RUC")
        {
            if (identificacion.Length != 13 || !identificacion.All(char.IsDigit))
                mensaje += "El RUC debe tener exactamente 13 d�gitos num�ricos.\n";
        }

        if (salario <= 0)
            mensaje += "El salario debe ser mayor que 0.\n";

        // Mostrar alertas si hay errores
        if (!string.IsNullOrEmpty(mensaje))
        {
            await Application.Current.MainPage.DisplayAlert("VALIDACI�N", mensaje, "ACEPTAR");
            return false;
        }

        return true;
    }
}