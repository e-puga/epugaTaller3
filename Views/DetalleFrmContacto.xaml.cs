namespace epugaTaller3.Views;

public partial class DetalleFrmContacto : ContentPage
{
    public DetalleFrmContacto()
    {
        InitializeComponent();
    }

    public DetalleFrmContacto(string tipoIdentificacion, string identificacion, string nombres, string apellidos, string fecha, string correo, int salario, double aporteIESS)
	{
		InitializeComponent();
        lblTipoIdentificacion.Text = tipoIdentificacion;
        lblIdentificacion.Text = identificacion;
        lblNombres.Text = nombres;
        lblApellidos.Text = apellidos;
        lblFecha.Text = fecha;
        lblCorreo.Text = correo;
        lblSalario.Text = Convert.ToString(salario);
        lblAporteIESS.Text = Convert.ToString(aporteIESS);
    }

    private void btnExportar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string tipoIdentificacion = lblTipoIdentificacion.Text;
            string identificacion = lblIdentificacion.Text;
            string nombres = lblNombres.Text;
            string apellidos = lblApellidos.Text;
            string fecha = lblFecha.Text;
            string correo = lblCorreo.Text;
            string salario = lblSalario.Text;
            string aporteIESS = lblAporteIESS.Text;

            string contenido =
            $"Tipo de Identificación: {tipoIdentificacion}\n" +
            $"Identificación: {identificacion}\n" +
            $"Nombres: {nombres}\n" +
            $"Apellidos: {apellidos}\n" +
            $"Fecha: {fecha}\n" +
            $"Correo: {correo}\n" +
            $"Salario: {salario}\n" +
            $"AporteIESS: {aporteIESS}\n";
            
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(downloadsPath, "DatosExportados.txt");

            
            File.WriteAllText(filePath, contenido);

            
            DisplayAlert("Éxito", $"Archivo guardado en: {filePath}", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"No se pudo exportar el archivo: {ex.Message}", "OK");
        }
    }
}